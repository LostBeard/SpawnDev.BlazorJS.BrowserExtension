using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// An object describing the list of query key-value pairs to be added or replaced.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-QueryKeyValue<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/declarativeNetRequest/URLTransform#addorreplaceparams
    /// </summary>
    public class QueryKeyValue
    {
        /// <summary>
        /// An array of integer. The IDs of the rules to return.
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// If true, the query key is replaced only if it's already present. Otherwise, the key is also added if it's missing. Defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ReplaceOnly { get; set; }
        /// <summary>
        /// An array of integer. The IDs of the rules to return.
        /// </summary>
        public string Value { get; set; }
    }
}
