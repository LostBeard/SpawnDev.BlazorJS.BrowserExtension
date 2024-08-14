using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// This API enables extensions to specify conditions and actions that describe how network requests should be handled. These declarative rules enable the browser to evaluate and modify network requests without notifying extensions about individual network requests.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/declarativeNetRequest<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-GetRulesFilter
    /// </summary>
    public partial class DeclarativeNetRequest : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public DeclarativeNetRequest(IJSInProcessObjectReference _ref) : base(_ref) { }

        public Task<Array<Rule>> GetDynamicRules() => JSRef!.CallAsync<Array<Rule>>("getDynamicRules");
    }
    public class QueryTransform
    {

    }
    /// <summary>
    /// 
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest#type-GetRulesFilter
    /// </summary>
    public class GetRulesFilter
    {

    }
}
