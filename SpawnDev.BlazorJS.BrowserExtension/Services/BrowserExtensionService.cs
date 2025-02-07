using Microsoft.AspNetCore.Components;
using System.Web;

namespace SpawnDev.BlazorJS.BrowserExtension.Services
{
    public class BrowserExtensionService : IBackgroundService, IDisposable
    {
        private static BlazorJSRuntime _JS => BlazorJSRuntime.JS;
        // chrome
        private static Lazy<Browser?> _Browser = new Lazy<Browser?>(() =>
        {
            if (!_JS.IsUndefined("browser?.runtime")) return _JS.Get<Browser?>("browser");
            else if (!_JS.IsUndefined("chrome?.runtime")) return _JS.Get<Browser?>("chrome");
            return null;
        });
        private static Lazy<Runtime?> _Runtime = new Lazy<Runtime?>(() => _Browser.Value?.Runtime);
        // extension id
        private static Lazy<string> _ExtensionId = new Lazy<string>(() => _Runtime.Value?.Id ?? "");
        // extension mode
        private static Lazy<ExtensionMode> _ExtensionMode = new Lazy<ExtensionMode>(() => GetExtensionMode(_JS.Get<string>("location.href"), _ExtensionId.Value, _JS.GlobalScope));
        private BlazorJSRuntime JS;
        private NavigationManager NavigationManager;
        /// <summary>
        /// Static method for accessing the extension mode
        /// </summary>
        /// <returns></returns>
        public static ExtensionMode GetExtensionMode() => _ExtensionMode.Value;
        /// <summary>
        /// Static method for accessing the extension id if there is one
        /// </summary>
        /// <returns></returns>
        public static string GetExtensionId() => _ExtensionId.Value;
        /// <summary>
        /// The current extension mode
        /// </summary>
        public ExtensionMode ExtensionMode { get; private set; } = ExtensionMode.None;
        /// <summary>
        /// Returns the extension id 
        /// </summary>
        public string ExtensionId => _ExtensionId.Value;
        /// <summary>
        /// The global instance of chrome or null
        /// </summary>
        public Browser? Browser => _Browser.Value;
        /// <summary>
        /// chrome.runtime or null
        /// </summary>
        public Runtime? Runtime => _Runtime.Value;
        /// <summary>
        /// The base uri of this Blazor app
        /// </summary>
        public string BlazorBaseURI { get; private set; }
        /// <summary>
        /// The current location of the page as a string
        /// </summary>
        public string Location { get; private set; } = "";
        /// <summary>
        /// The current location of the page as a Uri
        /// </summary>
        public Uri LocationUri { get; private set; }
        /// <summary>
        /// When running in ExtensionMode.Content mode, Fires when a content page location changes
        /// </summary>
        public event Action<Uri> OnLocationChanged;
        public BrowserExtensionService(BlazorJSRuntime js, NavigationManager navigationManager)
        {
            JS = js;
            NavigationManager = navigationManager;
            Location = JS.Get<string>("location.href");
            LocationUri = new Uri(Location);
            // Get the base uri of the Blazor app
            BlazorBaseURI = _GetURL("/app/") ?? NavigationManager.BaseUri;
            // 
            ExtensionMode = _ExtensionMode.Value;
#if DEBUG && true
            JS.Log($"Location: {Location}");
            JS.Log("BlazorBaseURI", BlazorBaseURI);
            JS.Log("NavigationManager.BaseUri", NavigationManager.BaseUri);
            JS.Log($"ExtensionMode: {ExtensionMode}");
            JS.Log("ExtensionId", ExtensionId);
#endif
            if (ExtensionMode == ExtensionMode.Content)
            {
                // Window
                using var window = JS.Get<BlazorJS.JSObjects.Window>("window");
                //Document = JS.Get<Document>("document");
                // listen to the custom event dispatched by the content-loader when the page location changes
                window.AddEventListener<LocationChangeEvent>("locationChange", Window_LocationChange);
            }
        }
        string? _GetURL(string path) => Runtime?.GetURL(path);
        void Window_LocationChange(LocationChangeEvent locationChangeEvent)
        {
            Location = locationChangeEvent.Detail;
            LocationUri = new Uri(Location);
            OnLocationChanged?.Invoke(LocationUri);
        }
        /// <summary>
        /// Gets the full url to a path relative to the Blazor app root path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetURL(string path) => new Uri(new Uri(BlazorBaseURI), path).ToString();
        /// <summary>
        /// Returns true if the context is valid
        /// </summary>
        /// <returns></returns>
        public bool CheckContextValid()
        {
            return Runtime?.Id != null;
        }
        /// <summary>
        /// Returns true if the context was valid and has been invalidated
        /// </summary>
        /// <returns></returns>
        public bool CheckContextInvalided()
        {
            return !string.IsNullOrEmpty(ExtensionId) && Runtime?.Id == null;
        }
        /// <summary>
        /// Returns the extension mode.
        /// </summary>
        /// <returns></returns>
        private static ExtensionMode GetExtensionMode(string loadLocation, string? extensionId, GlobalScope globalScope)
        {
            var ret = ExtensionMode.None;
            var locationUri = new Uri(loadLocation);
            // below needs to be changed to work in other browsers
            var ExtensionScheme = locationUri.Scheme.Contains("-extension");
            // ExtensionMode
            if (!string.IsNullOrEmpty(extensionId))
            {
                var filename = locationUri.AbsolutePath.Split('/').Last();
                var parsed = HttpUtility.ParseQueryString(locationUri.Query);
                var pageValue = "";
                if (filename == "index.html")
                {
                    pageValue = parsed["page"] ?? "index";
                }
                else if (filename.EndsWith(".html"))
                {
                    pageValue = filename.Substring(0, filename.LastIndexOf(".html"));
                }
                // background
                if (ExtensionScheme && pageValue == "background")
                {
                    // Background page - Firefox
                    ret = ExtensionMode.Background;
                }
                else if (ExtensionScheme && globalScope == GlobalScope.ServiceWorker)
                {
                    // Background ServiceWorker - Chrome
                    ret = ExtensionMode.Background;
                }
                else if (globalScope == GlobalScope.Window && !ExtensionScheme)
                {
                    ret = ExtensionMode.Content;
                }
                //else if (globalScope == GlobalScope.Window && ExtensionScheme && pageValue == "options")
                //{
                //    ret = ExtensionMode.Options;
                //}
                //else if (globalScope == GlobalScope.Window && ExtensionScheme && pageValue == "popup")
                //{
                //    ret = ExtensionMode.Popup;
                //}
                //else if (globalScope == GlobalScope.Window && ExtensionScheme && pageValue == "installed")
                //{
                //    ret = ExtensionMode.Installed;
                //}
                else if (globalScope == GlobalScope.Window && ExtensionScheme)
                {
                    ret = ExtensionMode.ExtensionPage;
                }
                else
                {
                    Console.WriteLine("!!!!!!!!!!!!! Unknown Extension mode !!!!!!!!!!!!!!");
                }
            }
            return ret;
        }
        /// <summary>
        /// Disposes resources
        /// </summary>
        public void Dispose()
        {
            if (ExtensionMode == ExtensionMode.Content)
            {
                // Window
                using var window = JS.Get<BlazorJS.JSObjects.Window>("window");
                //Document = JS.Get<Document>("document");
                // listen to the custom event dispatched by the content-loader when the page location changes
                window.RemoveEventListener<LocationChangeEvent>("locationChange", Window_LocationChange);
            }
        }
    }
}
