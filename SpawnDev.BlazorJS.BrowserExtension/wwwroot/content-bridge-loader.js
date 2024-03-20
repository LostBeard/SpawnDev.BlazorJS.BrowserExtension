// Loads an extension content bridge on the website side with serve enabled
(() => {
    var src = document.currentScript.src;
    var url = new URL(src);
    var instanceId = url.searchParams.get('instanceId');
    var remoteInstanceId = url.searchParams.get('remoteInstanceId');
    if (instanceId && remoteInstanceId) {
        globalThis._cdA = new ExtensionContentBridge({
            instanceId: instanceId,
            remoteInstanceId: remoteInstanceId,
            serve: true,
        });
    }
})();
