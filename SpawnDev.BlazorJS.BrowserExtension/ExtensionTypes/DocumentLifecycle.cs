using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// The document lifecycle of the frame.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/extensionTypes#type-DocumentLifecycle
    /// </summary>
    public enum DocumentLifecycle
    {
        /// <summary>
        /// Prerender
        /// </summary>
        [JsonPropertyName("perender")]
        Prerender,
        /// <summary>
        /// Active
        /// </summary>
        [JsonPropertyName("active")]
        Active,
        /// <summary>
        /// Cached
        /// </summary>
        [JsonPropertyName("cached")]
        Cached,
        /// <summary>
        /// PendingDeletion
        /// </summary>
        [JsonPropertyName("pending_deletion")]
        PendingDeletion,
    }
}
