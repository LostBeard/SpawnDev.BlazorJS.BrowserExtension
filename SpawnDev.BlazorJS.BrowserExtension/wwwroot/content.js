// Todd Tanner
// 2024
// Tolerador
// Loads Blazor WASM app content.html into the extension "content" context of an existing webpage
// uses browser-polyfill - https://github.com/mozilla/webextension-polyfill
// tested in Chrome and Firefox on Windows
// not tested in other browsers
var initBlazorContent = async function () {
    var verboseMode = false;
    var consoleLog = function () {
        if (!verboseMode) return;
        console.log(...arguments);
    };
    // Blazor will fail to load due to ContentSecurityPolicy (CSP) restrictions on some websites
    // The error happens on the call to `WebAssembly.compileStreaming`
    // this will catch the error so that it does not become an uncaught Promise exception
    // the onSecurityPolicyViolation event will notify the background worker
    // the background worker can optionally patch the website's CSP rules to allow Blazor to run or do nothing
    var patchWebAssemblyCompileStreaming = true;
    var webAssemblyCompileStreamingOrig = null;
    async function WebAssemblyCompileStreaming() {
        var ret = null;
        var args = [...arguments];
        try {
            ret = await webAssemblyCompileStreamingOrig.apply(null, args);
            return ret;
        } catch (ex) {
            consoleLog('WebAssemblyCompileStreaming failed:', args, ex);
            // the onSecurityPolicyViolation event handler will notify the background worker
            // then just async hang here to prevent Blazor from throwing an error as it is up to the background worker now
            await new Promise(() => { });
        }
    }
    if (patchWebAssemblyCompileStreaming && typeof WebAssembly.compileStreaming == "function") {
        webAssemblyCompileStreamingOrig = WebAssembly.compileStreaming.bind(WebAssembly);
        WebAssembly.compileStreaming = WebAssemblyCompileStreaming;
    }
    // Some websites have ContentSecurityPolicies that prevent webassembly
    // This will cause Blazor loading to fail
    // The `securitypolicyviolation` event will fire when this error occurs
    // To work around the issue, we can message the background script and request a ContentSecurityPolicy modification to allow WebAssembly
    function onSecurityPolicyViolation(e) {
        // chrome - e.blockedURI === "wasm-eval"
        if ((e.blockedURI === "wasm-eval" || e.blockedURI === "wasm-unsafe-eval")
            && e.violatedDirective === "script-src"
            && e.originalPolicy.indexOf('wasm-unsafe-eval') === -1) {
            document.removeEventListener('securitypolicyviolation', onSecurityPolicyViolation);
            var cspViolation = {
                documentURI: e.documentURI,                 // document.location.href
                originalPolicy: e.originalPolicy,           // csp header value
                // atm only the above to vars are used in the background script. below are informative
                blockedURI: e.blockedURI,                   // "wasm-eval"
                disposition: e.disposition,                 // "enforce"
                effectiveDirective: e.effectiveDirective,   // "script-src"
                sourceFile: e.sourceFile,                   // "chrome-extension" (not sure on firefox, others)
                violatedDirective: e.violatedDirective,     // "script-src"
            };
            consoleLog('Blazor onSecurityPolicyViolation detected', cspViolation);
            browser.runtime.sendMessage({ cspViolation });
        }
    }
    document.addEventListener('securitypolicyviolation', onSecurityPolicyViolation);

    var blazorWebExtensionConfig = {
        // htmlPath - the html file, relative to the Blazor app base path, to load html elements from
        htmlPath: 'content.html',
    };
    var extensionAppBasePath = browser.runtime.getURL('/app/');
    consoleLog('extensionAppBasePath', extensionAppBasePath);
    consoleLog('document.baseURI', document.baseURI);
    consoleLog('location.href', location.href);
    function getAppURL(relativePath) {
        return new URL(relativePath, extensionAppBasePath).toString();
    }
    async function getText(href) {
        var response = await fetch(href);
        return await response.text();
    }
    var undefinedGets = {};
    function createProxiedObject(obj, useIfDefined) {
        var ret = new Proxy(obj, {
            get(target, key) {
                if (useIfDefined && typeof useIfDefined[key] !== 'undefined') {
                    return useIfDefined[key];
                }
                if (key === 'proxyJSObject') {
                    return useIfDefined;
                }
                if (key === 'proxiedJSObject') {
                    return obj;
                }
                var ret = target[key];
                var typeofProp = typeof ret;
                var propIsUndefined = typeofProp === 'undefined';
                var typeofKey = typeof key;
                var keyIsSymbolIterator = key == Symbol.iterator;
                var keyIsSymbol = typeofKey === 'symbol';
                var keyStr = keyIsSymbol ? key.toString() : key;
                consoleLog('get', target.constructor?.name, keyStr, ret && ret.constructor ? ret.constructor.name : typeofProp, typeofProp !== 'function' ? ret : '(){ ... }');
                if (propIsUndefined) {
                    var getKey = (target.constructor?.name ?? '') + '.' + keyStr;
                    if (!undefinedGets[getKey]) {
                        undefinedGets[getKey] = {};
                        consoleLog('undefined: ', getKey);
                    }
                }
                return ret;
            },
            ownKeys(target) {
                consoleLog('ownKeys', target.constructor?.name);
                var targetKeys = Reflect.ownKeys(target);
                if (!useIfDefined) return targetKeys;
                var useIfDefinedKeys = Reflect.ownKeys(useIfDefined);
                var keys = useIfDefinedKeys.concat(targetKeys.filter(function (i) {
                    return useIfDefinedKeys.indexOf(i) == -1;
                }));
                return keys;
            },
            has(target, key) {
                consoleLog('has', target.constructor?.name, key);
                if (useIfDefined) {
                    let ret = Reflect.has(useIfDefined, key);
                    if (ret) return ret;
                }
                return Reflect.has(target, key);
            },
            getOwnPropertyDescriptor(target, key) {
                consoleLog('getOwnPropertyDescriptor', target, key);
                if (useIfDefined) {
                    let ret = Reflect.getOwnPropertyDescriptor(useIfDefined, key);
                    if (ret) return ret;
                }
                return Reflect.getOwnPropertyDescriptor(target, key);
            },
            set(target, key, value) {
                if (true || typeof target[key] === 'undefined') {
                    consoleLog('set', target.constructor?.name, key);
                }
                if (key === 'environmentVariables') {
                    var nmtt = true;
                }
                if (useIfDefined) {
                    useIfDefined[key] = value;
                    return true;
                }
                try {
                    target[key] = value;
                } catch (ex) {
                    console.log('Set failed', target, key);
                    useIfDefined = {};
                    useIfDefined[key] = value;
                }
                return true;
            },
            deleteProperty(target, key) {
                consoleLog('deleteProperty', target.constructor?.name, key);
                if (useIfDefined) {
                    if (key in useIfDefined) {
                        delete useIfDefined[key];
                        return true;
                    }
                }
                if (!(key in target)) {
                    return false;
                }
                delete target[key];
                return true;
            },
            defineProperty(target, key, descriptor) {
                consoleLog('defineProperty', target, key, descriptor);
                //if (descriptor && "value" in descriptor) {
                //    target[key] = descriptor.value;
                //}
                if (useIfDefined) {
                    return Reflect.defineProperty(useIfDefined, key, descriptor);
                }
                return Reflect.defineProperty(target, key, descriptor);
            },
        });
        return ret;
    }
    var xrayWrapped = globalThis.window && globalThis !== globalThis.window && !globalThis.constructor.name;
    if (xrayWrapped) {
        consoleLog("XrayWrapped SandBox detected. Patching window and globalThis. Fetch will also be patched.");
        // Bring the globalThis.constructor.name inline with Chrome extension content scripts
        globalThis.constructor.name = 'Window';
        // Blazor will try to use globalThis.addEventListener, point it at window's
        globalThis.addEventListener = globalThis.window.addEventListener.bind(globalThis.window);
        // Create a proxy window that maps all writes to globalThis, and reads from globalThis first then window
        Object.defineProperty(globalThis, 'window', {
            value: createProxiedObject(globalThis.window, globalThis)
        });
    }
    // patch fetch
    let fetchOrig = globalThis.fetch;
    globalThis.fetch = async function (resource, options) {
        consoleLog("webWorkersFetch", typeof resource, resource, options);
        var resp;
        if (typeof resource === 'string') {
            // resource is a string
            let newUrl = getAppURL(resource);
            resp = await fetchOrig(newUrl, options);
        } else {
            // resource is a Request object
            // currently not modified. could cause issues if a relative path was used to create the Request object.
            resp = await fetchOrig(resource, options);
        }
        if (xrayWrapped) {
            // In Firefox extension content mode, the object returned from Response.json is xraywrapped and will throw an exception if modified,
            // which Blazor will do when starting up.
            // To fix this return unwrapped version.
            var jsonOrig = resp.json.bind(resp);
            var blobOrig = resp.blob.bind(resp);
            var arrayBufferOrig = resp.arrayBuffer.bind(resp);
            Object.defineProperties(resp, {
                json: {
                    value: async function () {
                        consoleLog('fetch.json', resource);
                        var json = await jsonOrig();
                        return json.wrappedJSObject ? json.wrappedJSObject : json;
                    }
                },
                blob: {
                    value: async function () {
                        consoleLog('fetch.blob', resource);
                        var blob = await blobOrig();
                        return blob.wrappedJSObject ? blob.wrappedJSObject : blob;
                    }
                },
                arrayBuffer: {
                    value: async function () {
                        consoleLog('fetch.arrayBuffer', resource);
                        var arrayBuffer = await arrayBufferOrig();
                        return arrayBuffer.wrappedJSObject ? arrayBuffer.wrappedJSObject : arrayBuffer;
                    }
                }
            });
        }
        return resp;
    };
    // create blazorConfig which is used by the patched Blazor framework
    globalThis.blazorConfig = {};
    globalThis.blazorConfig.autoStart = false;
    //globalThis.blazorConfig.webAssemblyConfig = {
    //    loadBootResource: function (type, name, defaultUri, integrity) {
    //        var newUrl = getAppURL(`_framework/${name}`);
    //        consoleLog(`Loading: '${type}', '${name}', '${defaultUri}', '${newUrl}'`);
    //        return newUrl;
    //    },
    //};
    globalThis.blazorConfig.blazorBaseURI = extensionAppBasePath;
    let blazorHtmlURL = getAppURL(blazorWebExtensionConfig.htmlPath);
    consoleLog('Loading Blazor content', blazorHtmlURL);
    try {
        var indexHtmlSrc = await getText(blazorHtmlURL);
        var parser = new DOMParser();
        var parsedDocument = parser.parseFromString(indexHtmlSrc, 'text/html');
        var importedTagNames = ['DIV', 'LINK', 'SCRIPT'];
        async function processElement(el, parent) {
            if (importedTagNames.indexOf(el.tagName) !== -1) {
                switch (el.tagName) {
                    case 'LINK':
                        if (el.attributes.rel.value !== 'stylesheet') {
                            return;
                        }
                        if (el.href) {
                            el.href = getAppURL(el.attributes.href.value);
                            consoleLog('Modified', el.tagName, el.href);
                        }
                        break;
                    case 'SCRIPT':
                        if (el.src) {
                            el.src = getAppURL(el.attributes.src.value);
                            consoleLog('Modified', el.tagName, el.src);
                            await import(el.src);
                            return;
                        }
                        break;
                    default:
                        consoleLog('Adding', el.tagName, el);
                        break;
                }
                consoleLog('Final append', el.tagName, el);
                let elFrag = document.createRange().createContextualFragment(el.outerHTML);
                parent.appendChild(elFrag);
            } else {
                consoleLog('Skipping', el.tagName, el);
            }
        }
        for (var el of parsedDocument.head.children) {
            await processElement(el, document.head);
        }
        for (var el of parsedDocument.body.children) {
            await processElement(el, document.body);
        }
        await Blazor.start(globalThis.blazorConfig.webAssemblyConfig);
        consoleLog('Loaded Blazor content', blazorHtmlURL);
    } catch (ex) {
        consoleLog('Blazor content load failed...', ex);
    }
};
initBlazorContent();

// Add a custom event that dispatches when the window's location changes
// The extension can listen for this to know when the page has changed location without reloading
// BrowserExtensionService will listen for this
function watchBody() {
    var oldHref = document.location.href;
    var observer = new MutationObserver(function () {
        if (oldHref != document.location.href) {
            oldHref = document.location.href;
            globalThis.window.dispatchEvent(new CustomEvent("locationChange", { detail: oldHref }));
        }
    });
    observer.observe(document.querySelector("body"), { childList: true, subtree: true });
}
if (document.readyState === 'complete') watchBody();
else window.addEventListener('load', () => watchBody());
