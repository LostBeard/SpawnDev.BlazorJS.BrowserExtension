using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-TestMatchRequestDetails
    /// </summary>
    public class TestMatchRequestDetails
    {
        /// <summary>
        /// A string. The initiator URL (if any) for the hypothetical request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Initiator { get; set; }
        /// <summary>
        /// Standard HTTP method of the hypothetical request. Defaults to "get" for HTTP requests and is ignored for non-HTTP requests.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<RequestMethod>? Method { get; set; }
        /// <summary>
        /// A number. The ID of the tab the hypothetical request takes place in. Does not need to correspond to a real tab ID. Default is -1, meaning that the request isn't related to a tab.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// The resource type of the hypothetical request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<ResourceType>? Type { get; set; }
        /// <summary>
        /// The URL of the hypothetical request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Url { get; set; }
    }
}
