using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-RequestDetails
    /// </summary>
    public class RequestDetails
    {
        /// <summary>
        /// The unique identifier for the frame's document, if this request is for a frame.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DocumentId { get; set; }
        /// <summary>
        /// The lifecycle of the frame's document, if this request is for a frame.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<DocumentLifecycle>? DocumentLifecycle { get; set; }
        /// <summary>
        /// The value 0 indicates that the request happens in the main frame; a positive value indicates the ID of a subframe in which the request happens. If the document of a (sub-)frame is loaded (type is main_frame or sub_frame), frameId indicates the ID of this frame, not the ID of the outer frame. Frame IDs are unique within a tab.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int FrameId { get; set; }
        /// <summary>
        /// The type of the frame, if this request is for a frame.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<FrameType>? FrameType { get; set; }
        /// <summary>
        /// The origin where the request was initiated. This does not change through redirects. If this is an opaque origin, the string 'null' will be used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Initiator{ get; set; }
        /// <summary>
        /// Standard HTTP method.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Method { get; set; }
        /// <summary>
        /// ID of frame that wraps the frame which sent the request. Set to -1 if no parent frame exists.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ParentDocumentId { get; set; }
        /// <summary>
        /// The ID of the request. Request IDs are unique within a browser session.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RequestId { get; set; }
        /// <summary>
        /// The ID of the tab in which the request takes place. Set to -1 if the request isn't related to a tab.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
        /// <summary>
        /// The resource type of the request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<ResourceType>? Type { get; set; }
        /// <summary>
        /// The URL of the request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Url { get; set; }
    }
}
