namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-IsRegexSupportedResult
    /// </summary>
    public class IsRegexSupportedResult
    {
        /// <summary>
        /// boolean Whether the regular expression is supported.
        /// </summary>
        public bool IsSupported { get; set; }
        /// <summary>
        /// string Specifies the reason why the regular expression is not supported. Possible values are "syntaxError" and "memoryLimitExceeded". Only provided if isSupported is false.
        /// </summary>
        public string? Reason { get; set; }
    }
}
