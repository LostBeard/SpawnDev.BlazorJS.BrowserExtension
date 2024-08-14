using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// An object describing how to add, remove, or replace query key-value pairs. Cannot be specified if 'query' is specified.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/declarativeNetRequest/URLTransform#querytransform
    /// </summary>
    public class QueryTransform
    {
        /// <summary>
        /// An array of objects describing the list of query key-value pairs to be added or replaced.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AddOrReplaceParam[]? AddOrReplaceParams { get; set; }
        /// <summary>
        /// An array of string. The list of query keys to be removed.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? RemoveParams { get; set; }
    }
}
