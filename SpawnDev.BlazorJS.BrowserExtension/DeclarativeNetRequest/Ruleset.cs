namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-Ruleset
    /// </summary>
    public class Ruleset
    {
        /// <summary>
        /// Whether the ruleset is enabled by default.
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// A non-empty string uniquely identifying the ruleset. IDs beginning with '_' are reserved for internal use.
        /// </summary>
        public string Id{ get; set; }
        /// <summary>
        /// The path of the JSON ruleset relative to the extension directory.
        /// </summary>
        public string Path { get; set; }
    }
}
