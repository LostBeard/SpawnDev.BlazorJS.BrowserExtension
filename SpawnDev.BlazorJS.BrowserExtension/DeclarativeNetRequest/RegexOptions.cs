using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-RegexOptions
    /// </summary>
    public class RegexOptions
    {
        /// <summary>
        /// Whether the regex specified is case sensitive. Default is true.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsCaseSensitive { get; set; }
        /// <summary>
        /// The regular expresson to check.
        /// </summary>
        public string Regex{ get; set; }
        /// <summary>
        /// Whether the regex specified requires capturing. Capturing is only required for redirect rules which specify a regexSubstition action. The default is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RequireCapturing { get; set; }
    }
}
