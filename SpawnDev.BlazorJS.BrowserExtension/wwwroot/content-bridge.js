
class ExtensionContentBridge {
    #wrappedObjects = {};
    #wrappedObjectIdIndex = 0;
    #waitingIndex = 0;
    #waiting = {};
    #proxies = {};
    #instanceId;
    #remoteInstanceId;
    #eventElement;
    #serve = false;
    #wrapArrays = true;
    constructor(options) {
        this.#instanceId = options.instanceId;
        this.#remoteInstanceId = options.remoteInstanceId;
        this.#eventElement = options.eventElement ?? globalThis.window ?? globalThis;
        this.#eventElement.addEventListener(this.#instanceId, this.#onMessage.bind(this));
        this.#serve = !!options.serve;
    }
    get instanceId() {
        return this.#instanceId;
    }
    get serve() {
        return this.#serve;
    }
    set serve(value) {
        this.#serve = value;
    }
    get remoteInstanceId() {
        return this.#remoteInstanceId;
    }
    makeQuerySelector(element, pathSplit = ' > ') {
        // Selector
        let selector = '';
        // Loop flag
        let foundRoot;
        // Element handler
        let currentElement = element;
        // Do action until we reach html element
        do {
            // Get element tag name 
            const tagName = currentElement.tagName.toLowerCase();
            if (tagName.toLowerCase() === 'html') {
                return 'html';
            }
            // Get parent element
            const parentElement = currentElement.parentElement;
            // Count children
            if (parentElement.childElementCount > 1) {
                // Get children of parent element
                const parentsChildren = [...parentElement.children];
                // Count current tag 
                let tag = [];
                parentsChildren.forEach(child => {
                    if (child.tagName.toLowerCase() === tagName) tag.push(child) // Append to tag
                })
                // Is only of type
                if (tag.length === 1) {
                    // Append tag to selector
                    selector = `${pathSplit}${tagName}${selector}`;
                } else {
                    // Get position of current element in tag
                    const position = tag.indexOf(currentElement) + 1;
                    // Append tag to selector
                    selector = `${pathSplit}${tagName}:nth-child(${position})${selector}`;
                }
            } else {
                //* Current element has no siblings
                // Append tag to selector
                selector = `${pathSplit}${tagName}${selector}`;
            }
            // Set parent element to current element
            currentElement = parentElement;
            // Is root  
            foundRoot = parentElement.tagName.toLowerCase() === 'html';
            // Finish selector if found root element
            if (foundRoot) selector = `html${selector}`;
        }
        while (foundRoot === false);
        // Return selector
        return selector;
    }
    #createProxiedContentObject(wrappedObject) {
        var dispatcher = this;
        var targetSrc = wrappedObject.__typeof === 'function' ? (() => { }) : {};
        var wrappedObjectId = wrappedObject.__wrappedObjectId;
        var ignoreKeys = ['__internalId', '_callbackId', '__wrappedJSObject', '__undefinedref__'];
        var release = function () {
            return dispatcher.release(wrappedObjectId);
        };
        var decon = function () {
            return dispatcher.decon(wrappedObject);
        };
        var direct = function () {
            return dispatcher.direct(wrappedObject);
        };
        var ret = new Proxy(targetSrc, {
            apply(target, thisArg, argumentsList) {
                //console.log('proxy.apply', argumentsList);
                return dispatcher.call(wrappedObject, null, argumentsList);
            },
            get(target, key) {
                //console.log('proxy.get', key);
                // special properties
                if (ignoreKeys.indexOf(key) !== -1) {
                    return;
                }
                if (key === '__wrappedObjectDispatcherId') {
                    return dispatcher.instanceId;
                } else if (key === '__wrappedObject') {
                    return wrappedObject;
                } else if (key === '__wrappedObjectRelease') {
                    return release;
                } else if (key === '__wrappedObjectDecon') {
                    return decon;
                } else if (key === '__wrappedObjectDirect') {
                    return direct;
                }
                //console.log('proxy.get', key);
                return dispatcher.get(wrappedObject, key);
            },
            set(target, key, value) {
                //console.log('proxy.set', key);
                dispatcher.set(wrappedObject, key, value);
                return true;
            },
            deleteProperty(target, key) {
                //console.log('proxy.deleteProperty', key);
                return dispatcher.delete(wrappedObject, key);
            },
            ownKeys(target) {
                console.log('proxy.ownKeys');
                return dispatcher.ownKeys(wrappedObject);
            },
            has(target, key) {
                if (ignoreKeys.indexOf(key) !== -1) {
                    //console.log('proxy.has IGNORING', key);
                    return false;
                }
                //console.log('proxy.has', key);
                return dispatcher.has(wrappedObject, key);
            },
            construct(target, argumentsList, newTarget) {
                console.log('proxy.construct');
            },
            defineProperty(target, key, descriptor) {
                console.log('proxy.defineProperty', key);
                return false;
            },
            getOwnPropertyDescriptor(target, key) {
                if (ignoreKeys.indexOf(key) !== -1) {
                    //console.log('proxy.getOwnPropertyDescriptor IGNORING', key);
                    return;
                }
                console.log('proxy.getOwnPropertyDescriptor', key);
                var hasIt = dispatcher.has(wrappedObject, key);
                if (hasIt) {
                    let tmp = {};
                    tmp[key] = null;
                    return Object.getOwnPropertyDescriptor(tmp, key);
                } else {
                    return;
                }
            },
            getPrototypeOf(target) {
                //console.log('proxy.getPrototypeOf');
                return Object.getPrototypeOf(target);
            },
            setPrototypeOf(target, prototype) {
                //console.log('proxy.setPrototypeOf');
                // TODO - check remote
                return false;
            },
            isExtensible(target) {
                //console.log('proxy.isExtensible');
                // TODO - check remote
                return true;
            },
            preventExtensions(target) {
                //console.log('proxy.preventExtensions');
                // TODO - check remote
                return false;
            },
        });
        return ret;
    }
    #randAlphaStr(length) {
        let result = '';
        const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz';
        const charactersLength = characters.length;
        let counter = 0;
        while (counter < length) {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
            counter += 1;
        }
        return result;
    }
    #onMessage(e) {
        //console.log('onMessage', this.#instanceId, e);
        var detail = e.detail;
        var args = [...detail];
        var cmd = args.shift();
        if (typeof cmd !== 'string' || cmd.indexOf('_') !== 0 || cmd.indexOf('__') === 0) {
            console.warn('onMessage cmd is invalid', cmd);
        }
        var rid = args.shift();
        switch (cmd) {
            case '_defer':
                {
                    this._defer(rid);
                }
                break;
            case '_response':
                {
                    // cmd - command
                    // rid - unique request id
                    // err
                    // result
                    var err = args.shift();
                    var result = args.shift();
                    this._response(rid, err, result);
                }
                break;
            default:
                {
                    // cmd - command
                    // rid - unique request id or empty if no response requested
                    // ...args
                    var err = '';
                    var result = null;
                    var unwrapArgs = true;
                    var wrapResult = true;
                    if (['_release'].indexOf(cmd) !== -1) {
                        unwrapArgs = false;
                    }
                    if (['_decon', '_direct'].indexOf(cmd) !== -1) {
                        wrapResult = false;
                    }
                    try {
                        // if not serve, check if the cmd is allowed
                        if (!this.#serve && ['_release'].indexOf(cmd) === -1) {
                            err = 'Command not not available';
                        } else if (!this.#serve) {
                            // running commands is not allowed by this instance
                            err = 'Command not not available';
                        } else if (!this[cmd]) {
                            err = 'Command not found';
                        } else {
                            // normal call
                            if (unwrapArgs) args = this.#unwrapArgs(args);
                            result = this[cmd].apply(this, args);
                        }
                    } catch (ex) {
                        console.warn('Calling rpc command failed', cmd, ex);
                        err = 'Cmd failed' + ex;
                        result = null;
                    }
                    if (rid) {
                        if (!err) {
                            if (result instanceof Promise) {
                                // Promise (async result)
                                result.then(function (result) {
                                    if (wrapResult) result = this.#wrapArg(result);
                                    this.#post(['_response', rid, null, result])
                                }.bind(this)).catch(function (err) {
                                    this.#post(['_response', rid, err ?? 'Unknown error', null])
                                }.bind(this));
                                // report that we need to defer the result
                                this.#post(['_defer', rid])
                            }
                            else {
                                // sync result
                                if (wrapResult) result = this.#wrapArg(result);
                                this.#post(['_response', rid, null, result])
                            }
                        } else {
                            this.#post(['_response', rid, err, null])
                        }
                    }
                }
                break;
        }
    }
    #post(detail) {
        //console.log('#post', this.#instanceId, detail)
        this.#eventElement.dispatchEvent(new CustomEvent(this.#remoteInstanceId, { detail: detail }));
    }
    #postRun(cmd, args) {
        this.#waitingIndex++;
        var rid = this.#waitingIndex + '';
        var waiting = {
            result: null,
            err: null,
            deferred: false,
            done: false,
            resolve: null,
            reject: null,
        };
        args = !args ? [] : this.#wrapArgs(args);
        this.#waiting[rid] = waiting;
        // the request will be deferred or fulfilled before the next line completes because synchronous event handling is used as the relay mechanism
        this.#post([cmd, rid, ...args]);
        // if deferred, return a Promise
        if (waiting.deferred) {
            // return Promise 
            let ret = new Promise((resolve, reject) => {
                waiting.resolve = function (result) {
                    result = this.#unwrapArg(result);
                    resolve(result);
                }.bind(this);
                waiting.reject = function (err) {
                    reject(err);
                }.bind(this);
            });
            return ret;
        } else if (waiting.done) {
            if (waiting.err) {
                console.log('cmd errored');
                throw new Error(waiting.err);
            }
            let result = waiting.result;
            result = this.#unwrapArg(result);
            return result;
        } else {
            delete this.#waiting[rid];
            throw new Error('Could not deliver message');
        }
    }
    #pathObjectInfo(rootObject, path) {
        if (rootObject === null || rootObject === void 0) {
            // callers must call with the globalThis if they wish to use it as the rootObject.
            throw new Error('pathObjectInfo error: rootObject cannot be null');
        }
        var parent = rootObject;
        var target;
        var propertyName;
        if (path === null || path === void (0)) {
            // undefined and null can actually be property keys but that fact is ignored here atm
            target = parent;
            parent = null;
        } else if (typeof path === 'string' && typeof parent[path] === 'undefined') {
            var parts = path.split('.');
            propertyName = parts[parts.length - 1];
            for (var i = 0; i < parts.length - 1; i++) {
                parent = parent[parts[i]];
            }
            target = parent[propertyName];
        }
        else {
            propertyName = path;
            target = parent[propertyName];
        }
        var targetType = typeof target;
        var exists = targetType !== 'undefined' || (parent && propertyName in parent);
        return {
            parent,         // may be null even if target exists (Ex. if no path was given)
            propertyName,   // may be null even if target exists (Ex. if no path was given)
            target,         // may be undefined if it does not currently exist
            targetType,     // will always be a string of the target type (Ex. 'undefined', 'object', 'string', 'number')
            exists,         // will always be a bool value (true or false)
        };
    }
    #pathToTarget(rootObject, path) {
        return this.#pathObjectInfo(rootObject, path).target;
    }
    #pathToParent(rootObject, path) {
        return this.#pathObjectInfo(rootObject, path).parent;
    }
    #unwrapArg(arg) {
        //console.log('#unwrapArg', arg);
        if (arg === null || arg === void 0) {
            //
            return arg;
        }
        var typeOfArg = typeof arg;
        if (Array.isArray(arg)) {
            return this.#unwrapArgs(arg)
        } else if (typeOfArg === 'object') {
            if (typeof arg.__wrappedObjectId === 'string') {
                let wrappedObjectId = arg.__wrappedObjectId;
                if (arg.__instanceId === this.#instanceId) {
                    return this.#getWrappedObject(wrappedObjectId);
                } else {
                    // this wrapped object is owned by another instance
                    // create a Proxy object to represent it in this scope
                    let proxyInfo = this.#proxies[wrappedObjectId];
                    if (!proxyInfo) {
                        proxyInfo = {
                            proxy: this.#createProxiedContentObject(arg),
                            wrappedContentObject: arg,
                        };
                        this.#proxies[wrappedObjectId] = proxyInfo;
                    }
                    return proxyInfo.proxy;
                }
            }
        }
        return arg;
    }
    #getPassableData(data) {
        try {
            return JSON.parse(JSON.stringify(data));
        } catch { }
        return this.#wrapObject(ret);
    }
    #mustCreateReference(data) {
        try {
            JSON.parse(JSON.stringify(data));
            return false;
        } catch {
            return true;
        }
    }
    #now(ms) {
        return new Date().getTime();
    }
    #wrapArg(arg) {
        //console.log('#wrapArg', arg);
        if (arg === void 0 || arg === null) {
            return arg;
        } else if (Array.isArray(arg) && (!this.#wrapArrays || !this.#serve)) {
            return this.#wrapArgs(arg)
        } else if (typeof arg === 'object' || typeof arg === 'function') {
            //console.log('typeof arg', typeof arg);
            // check if wrappedObject wrappedObject
            if (arg.__wrappedObjectId && arg.__instanceId == this.#remoteInstanceId) {
                // wrappedObject
                //sconsole.log('wrappedObject typeof arg', typeof arg);
                return arg;
            }
            // check if wrappedObject proxy
            let wrappedObject = arg.__wrappedObject;
            if (wrappedObject && wrappedObject.__wrappedObjectId && wrappedObject.__instanceId == this.#remoteInstanceId) {
                //console.log('unproxified wrappedObject typeof arg', typeof arg);
                return wrappedObject;
            }
            if (this.#serve) {
                // every other object
                return this.#wrapObject(arg);
            }
        }
        return arg;
    }
    #unwrapArgs(args) {
        return args.map(this.#unwrapArg.bind(this));
    }
    #wrapArgs(args) {
        return args.map(this.#wrapArg.bind(this));
    }
    #wrapObject(obj) {
        if (!this.#serve || (Array.isArray(obj) && !this.#wrapArrays)) {
            // sending wrapped objects is disabled
            return obj;
        }
        if (obj === null || obj === void 0) return obj;
        var ret = {};
        this.#wrappedObjectIdIndex++;
        var wrappedObjectId = this.#wrappedObjectIdIndex + '';
        this.#wrappedObjects[wrappedObjectId] = obj;
        ret.__wrappedObjectId = wrappedObjectId;
        ret.__instanceId = this.#instanceId;
        ret.__constructorName = obj.constructor?.name ?? '';
        ret.__typeof = typeof obj;
        return ret;
    }
    #getWrappedObject(wrappedObjectId) {
        return this.#wrappedObjects[wrappedObjectId];
    }
    _response(rid, err, result) {
        var waiting = this.#waiting[rid];
        if (waiting) {
            delete this.#waiting[rid];
            waiting.done = true;
            if (waiting.resolve && waiting.reject) {
                if (err) {
                    waiting.reject(err);
                } else {
                    waiting.resolve(result);
                }
            } else {
                waiting.err = err;
                waiting.result = result;
            }
        } else {
            console.warn('rid not found in #waiting');
        }
    }
    _defer(rid) {
        console.log('_defer recvd... todo, find callback and invoke it', rid);
        var waiting = this.#waiting[rid];
        if (waiting) {
            waiting.deferred = true;
        }
    }
    // instance
    _call(obj, identifier, args) {
        //console.log('_call', identifier, args);
        var ret = null;
        if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
        var { target, parent, targetType, propertyName } = this.#pathObjectInfo(obj, identifier);
        if (targetType === "function") {
            ret = target(...args);
        } else {
            throw new Error('call target is not a function');
        }
        return ret;
    }
    _get(obj, identifier) {
        //console.log('_get called', obj, identifier);
        var ret = null;
        if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
        var { target, parent, targetType } = this.#pathObjectInfo(obj, identifier);
        if (targetType === "function") {
            ret = target.bind(parent);
        } else {
            ret = target;
        }
        return ret;
    }
    _set(obj, identifier, value) {
        if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
        var pathInfo = this.#pathObjectInfo(obj, identifier);
        return Reflect.set(pathInfo.parent, value);
    }
    _delete(obj, name) {
        var info = this.#pathObjectInfo(obj, name);
        return Reflect.deleteProperty(info.parent, info.propertyName);
    }
    _decon(obj) {
        if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
        return JSON.parse(JSON.stringify(obj));
    }
    _direct(obj) {
        if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
        return obj;
    }
    _ownKeys(obj) {
        if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
        var pathInfo = this.#pathObjectInfo(obj);
        return Reflect.ownKeys(pathInfo.target);
    }
    _has(obj, key) {
        if (obj === void 0 || obj === null) throw new Error('obj null or undefined');
        var pathInfo = this.#pathObjectInfo(obj, key);
        return Reflect.has(pathInfo.parent, pathInfo.propertyName)
    }
    _release(wrappedObject) {
        var wrappedObjectId = typeof wrappedObject === 'string' ? wrappedObject : wrappedObject.__wrappedObjectId;
        var fnd = !!this.#wrappedObjects[wrappedObjectId];
        if (fnd) {
            delete this.#wrappedObjects[wrappedObjectId];
        }
        return fnd;
    }
    call(obj, identifier, args) {
        return this.#postRun('_call', [obj, identifier, args]);
    }
    get(obj, identifier) {
        return this.#postRun('_get', [obj, identifier]);
    }
    set(obj, identifier, value) {
        return this.#postRun('_set', [obj, identifier, value]);
    }
    delete(obj, identifier) {
        return this.#postRun('_delete', [obj, identifier]);
    }
    ownKeys(obj) {
        return this.#postRun('_ownKeys', [obj]);
    }
    decon(obj) {
        return this.#postRun('_decon', [obj]);
    }
    direct(obj) {
        return this.#postRun('_direct', [obj]);
    }
    has(obj, identifier) {
        return this.#postRun('_has', [obj, identifier]);
    }
    release(wrappedObject) {
        return this.#postRun('_release', [wrappedObject]);
    }
    // global
    _callGlobal(identifier, args) {
        return this._call(globalThis, identifier, args);
    }
    _getGlobal(identifier) {
        return this._get(globalThis, identifier);
    }
    _setGlobal(identifier, value) {
        return this._set(globalThis, identifier, value);
    }
    _deleteGlobal(name) {
        return this._delete(globalThis, name);
    }
    callGlobal(identifier, args) {
        return this.#postRun('_callGlobal', [identifier, args]);
    }
    getGlobal(identifier) {
        return this.#postRun('_getGlobal', [identifier]);
    }
    setGlobal(identifier, value) {
        return this.#postRun('_setGlobal', [identifier, value]);
    }
    deleteGlobal(identifier) {
        return this.#postRun('_deleteGlobal', [identifier]);
    }
    getGlobalThis() {
        return this.getGlobal('globalThis');
    }
    getWindow() {
        return this.getGlobal('window');
    }
}
// attach to global scope
globalThis.ExtensionContentBridge = ExtensionContentBridge;
