using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.BrowserExtension.Services
{
    /// <summary>
    /// ContentBridgeService lets the Blazor App running in an Extension Content mode, which has an isolated Javascript scope,
    /// access the web page's Javascript scope via proxies<br/>
    /// </summary>
    public class ContentBridgeService : IAsyncBackgroundService
    {
        public Task Ready => _Ready ??= InitAsync();
        private Task? _Ready = null;
        string MessageKey = Guid.NewGuid().ToString();
        string instanceId = "";
        string remoteInstanceId = "";
        BrowserExtensionService BrowserExtensionService;
        /// <summary>
        /// ContentBridge Dispatcher
        /// </summary>
        public ExtensionContentBridge? SyncDispatcher { get; private set; }
        BlazorJSRuntime JS;
        public ContentBridgeService(BlazorJSRuntime js, BrowserExtensionService browserExtensionService)
        {
            JS = js;
            instanceId = $"{MessageKey}-a";
            remoteInstanceId = $"{MessageKey}-b";
            BrowserExtensionService = browserExtensionService;
            if (BrowserExtensionService.ExtensionMode == ExtensionMode.Content)
            {
                SyncDispatcher = new ExtensionContentBridge(new ExtensionContentBridgeOptions(instanceId, remoteInstanceId));
                JS.Set("_syncDispatcher", SyncDispatcher);
            }
        }
        async Task InitAsync()
        {
            if (BrowserExtensionService.ExtensionMode == ExtensionMode.Content)
            {
                // This loads the other side of the content-bridge into the website
                await ContentSiteContextScriptLoader("_content/SpawnDev.BlazorJS.BrowserExtension/content-bridge.js");
                await ContentSiteContextScriptLoader($"_content/SpawnDev.BlazorJS.BrowserExtension/content-bridge-loader.js?instanceId={remoteInstanceId}&remoteInstanceId={instanceId}");
            }
        }
        async Task ContentSiteContextScriptLoader(string jsFile)
        {
            var fileUrl = BrowserExtensionService.GetURL(jsFile);
            var document = JS.Get<Document>("document");
            using var scriptEl = document.CreateElement<HTMLScriptElement>("script");
            scriptEl.Type = "text/javascript";
            scriptEl.Src = fileUrl;
            using var head = document.Head;
            if (head != null)
            {
                head.AppendChild(scriptEl);
            }
            else
            {
                using var body = document.Body;
                if (body != null)
                {
                    body.AppendChild(scriptEl);
                }
                else
                {
                    using var html = document.DocumentElement;
                    html!.AppendChild(scriptEl);
                }
            }
            await scriptEl.OnLoadAsync();
            scriptEl.Remove();
        }
    }
}
