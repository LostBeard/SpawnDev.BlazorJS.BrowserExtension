﻿using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// The object describing the actions to take for matching requests. These can be specified in the static rule resources linked by the manifest.json's declarative_net_request key, or more dynamically through the declarativeNetRequest.updateDynamicRules or declarativeNetRequest.updateSessionRules methods.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/declarativeNetRequest/Rule
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// declarativeNetRequest.RuleAction. The action to take if this rule is matched.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RuleAction? Action { get; set; }
        /// <summary>
        /// declarativeNetRequest.RuleCondition. The condition under which this rule is triggered.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RuleCondition? Condition { get; set; }
        /// <summary>
        /// number. An ID that uniquely identifies a rule within a ruleset. Mandatory and should be >= 1.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? Id { get; set; }
        /// <summary>
        /// number. Rule priority. Defaults to 1. When specified, should be >= 1. See Matching precedents for details on how priority affects which rules are applied.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? Priority { get; set; }
    }
}
