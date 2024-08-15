using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// Details of the condition that determines whether a rule matches a request, as the condition property of a declarativeNetRequest.Rule.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/declarativeNetRequest/RuleCondition
    /// </summary>
    public class RuleCondition
    {
        /// <summary>
        /// A string. Specifies whether the network request is first-party or third-party. The request is considered first-party if it's for the same domain as the document or subdocument that initiates the request. Otherwise, it's considered third-party. If omitted, all requests are accepted. Possible values are "firstParty" and "thirdParty".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DomainType { get; set; }
        /// <summary>
        /// An array of string. The rule only matches network requests originating from this list of domains. If the list is omitted, the rule is applied to requests from all domains. An empty list is not allowed. A canonical domain should be used. This matches against the request initiator and not the request URL.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? InitiatorDomains { get; set; }
        /// <summary>
        /// An array of string. The rule does not match network requests originating from this list of domains. If the list is empty or omitted, no domains are excluded. This takes precedence over initiatorDomains. A canonical domain should be used. This matches against the request initiator and not the request URL.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? ExcludedInitiatorDomains { get; set; }
        /// <summary>
        /// A boolean. Whether the urlFilter or regexFilter (whichever is specified) is case sensitive. While there is consensus on defaulting to false across browsers in WECG issue 269, the value used to be true in (older) versions of Chrome and Safari. See Browser compatibility for details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsUrlFilterCaseSensitive { get; set; }
        /// <summary>
        /// A string. Regular expression to match against the network request URL. Note that:<br/>
        /// - The supported format is not stable and varies across browsers, see "Regular expressions in DNR API (regexFilter)" in WECG issue 344 for details.<br/>
        /// - Only one of urlFilter or regexFilter can be specified.<br/>
        /// - The regexFilter must be composed of only ASCII characters. This is matched against a URL where the host is encoded in the punycode format (in case of internationalized domains) and any other non-ascii characters are percent-encoded in UTF-8.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RegexFilter { get; set; }
        /// <summary>
        /// An array of string. The rule only matches network requests when the domain matches one from this list. If the list is omitted, the rule is applied to requests from all domains. An empty list is not allowed. A canonical domain should be used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? RequestDomains { get; set; }
        /// <summary>
        /// An array of string. The rule does not match network requests when the domains matches one from this list. If the list is empty or omitted, no domains are excluded. This takes precedence over requestDomains. A canonical domain should be used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? ExcludedRequestDomains { get; set; }
        /// <summary>
        /// An array of string. List of HTTP request methods that the rule matches. An empty list is not allowed. Specifying a requestMethods rule condition also excludes non-HTTP(s) requests, whereas specifying excludedRequestMethods does not.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? RequestMethods { get; set; }
        /// <summary>
        /// An array of string. List of request methods that the rule does not match on. Only one of requestMethods and excludedRequestMethods should be specified. If neither of them is specified, all request methods are matched.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? ExcludedRequestMethods { get; set; }
        /// <summary>
        /// An array of declarativeNetRequest.ResourceType. List of resource types that the rule matches with. An empty list is not allowed. This must be specified for "allowAllRequests" rules and may only include the "sub_frame" and "main_frame" resource types.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? ResourceTypes { get; set; }
        /// <summary>
        /// An array of declarativeNetRequest.ResourceType. List of resource types that the rule does not match on. Only one of resourceTypes and excludedResourceTypes should be specified. If neither of them is specified, all resource types except "main_frame" are blocked.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? ExcludedResourceTypes { get; set; }
        /// <summary>
        /// An array of number. List of tabs.Tab.id that the rule should match. An ID of tabs.TAB_ID_NONE matches requests that don't originate from a tab. An empty list is not allowed. Only supported for session-scoped rules.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int[]? TabIds { get; set; }
        /// <summary>
        /// An array of number. List of tabs.Tab.id that the rule should not match. An ID of tabs.TAB_ID_NONE excludes requests that do not originate from a tab. Only supported for session-scoped rules.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int[]? ExcludedTabIds { get; set; }
        /// <summary>
        /// A string. The pattern that is matched against the network request URL. Supported constructs:<br/>
        /// - * : Wildcard: Matches any number of characters.<br/>
        /// - | : Left or right anchor: If used at either end of the pattern, specifies the beginning or end of the URL respectively.<br/>
        /// - || : Domain name anchor: If used at the beginning of the pattern, specifies the start of a (sub-)domain of the URL.<br/>
        /// - ^ : Separator character: This matches anything except a letter, a digit, or one of _, -, ., or %. The last ^ may also match the end of the URL instead of a separator character.<br/>
        /// urlFilter is composed of the following parts: (optional left/domain name anchor) + pattern + (optional right anchor). If omitted, all URLs are matched. An empty string is not allowed. A pattern beginning with ||* is not allowed. Use * instead. Note that:<br/>
        /// - Only one of urlFilter or regexFilter can be specified.<br/>
        /// - The urlFilter must be composed of only ASCII characters. This is matched against a URL where the host is encoded in the punycode format (in case of internationalized domains) and any other non-ASCII characters are percent-encoded in UTF-8. For example, when the request URL is http://abc.рф?q=ф, the urlFilter is matched against the URL http://abc.xn--p1ai/?q=%D1%84.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UrlFilter { get; set; }
    }
}
