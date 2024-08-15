using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Tab reload properties<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/tabs#parameters_20
    /// </summary>
    public class ReloadProperties
    {
        /// <summary>
        /// Whether to bypass local caching. Defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BypassCache { get; set; }
    }
}
