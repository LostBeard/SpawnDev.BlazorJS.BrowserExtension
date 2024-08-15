using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// This describes whether the request is first or third party to the frame in which it originated. A request is said to be first party if it has the same domain (eTLD+1) as the frame in which the request originated.<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-DomainType
    /// </summary>
    public enum DomainType
    {
        /// <summary>
        /// FirstParty
        /// </summary>
        [JsonPropertyName("firstParty")]
        FirstParty,
        /// <summary>
        /// ThirdParty
        /// </summary>
        [JsonPropertyName("thirdParty")]
        ThirdParty,
    }
}
