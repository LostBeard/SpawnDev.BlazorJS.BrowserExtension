namespace SpawnDev.BlazorJS.BrowserExtension.JSObjects
{
    /// <summary>
    /// Details passed to the event handler for Runtime.OnPerformanceWarning<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/runtime/onPerformanceWarning#details
    /// </summary>
    public class OnPerformanceWarningDetails
    {
        /// <summary>
        /// runtime.OnPerformanceWarningCategory. The category of the warning.
        /// </summary>
        public EnumString<OnPerformanceWarningCategory> Category { get; set; }
        /// <summary>
        /// runtime.OnPerformanceWarningSeverity. The severity of the warning.
        /// </summary>
        public EnumString<OnPerformanceWarningSeverity> Severity { get; set; }
        /// <summary>
        /// integer. The ID of the tab that the performance warning relates to, if any.
        /// </summary>
        public int? TabId { get; set; }
        /// <summary>
        /// string. An explanation of what the warning means, possibly with information on how to address it.
        /// </summary>
        public string Description { get; set; }
    }
}
