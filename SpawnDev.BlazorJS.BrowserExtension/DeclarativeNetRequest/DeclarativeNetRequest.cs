﻿using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.BrowserExtension
{
    /// <summary>
    /// This API enables extensions to specify conditions and actions that describe how network requests should be handled. These declarative rules enable the browser to evaluate and modify network requests without notifying extensions about individual network requests.<br/>
    /// https://developer.mozilla.org/en-US/docs/Mozilla/Add-ons/WebExtensions/API/declarativeNetRequest<br/>
    /// https://developer.chrome.com/docs/extensions/reference/api/declarativeNetRequest
    /// </summary>
    public partial class DeclarativeNetRequest : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public DeclarativeNetRequest(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the number of static rules an extension can enable before the global static rule limit is reached.
        /// </summary>
        /// <returns></returns>
        public Task<int> GetAvailableStaticRuleCount() => JSRef!.CallAsync<int>("getAvailableStaticRuleCount");
        /// <summary>
        /// Returns the IDs of the disabled rules in a static ruleset.
        /// </summary>
        /// <returns></returns>
        public Task<int[]> GetDisabledRuleIds() => JSRef!.CallAsync<int[]>("getDisabledRuleIds");
        /// <summary>
        /// Returns the IDs of the disabled rules in a static ruleset.
        /// </summary>
        /// <returns></returns>
        public Task<int[]> GetDisabledRuleIds(GetDisabledRuleIdsOptions options) => JSRef!.CallAsync<int[]>("getDisabledRuleIds", options);
        /// <summary>
        /// Returns the set of dynamic rules for the extension.
        /// </summary>
        public Task<Array<Rule>> GetDynamicRules() => JSRef!.CallAsync<Array<Rule>>("getDynamicRules");
        /// <summary>
        /// Returns the set of dynamic rules for the extension.
        /// </summary>
        public Task<Array<Rule>> GetDynamicRules(GetRulesFilter filter) => JSRef!.CallAsync<Array<Rule>>("getDynamicRules", filter);
        /// <summary>
        /// Returns the IDs for the set of enabled static rulesets.
        /// </summary>
        /// <returns></returns>
        public Task<string[]> GetEnabledRulesets() => JSRef!.CallAsync<string[]>("getEnabledRulesets");
        /// <summary>
        /// Returns all the rules matched for the extension.
        /// </summary>
        /// <returns></returns>
        public Task<RulesMatchedDetails> GetMatchedRules() => JSRef!.CallAsync<RulesMatchedDetails>("getMatchedRules");
        /// <summary>
        /// Returns all the rules matched for the extension.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Task<RulesMatchedDetails> GetMatchedRules(MatchedRulesFilter filter) => JSRef!.CallAsync<RulesMatchedDetails>("getMatchedRules", filter);
        /// <summary>
        /// Returns the set of session rules for the extension.
        /// </summary>
        public Task<Array<Rule>> GetSessionRules() => JSRef!.CallAsync<Array<Rule>>("getSessionRules");
        /// <summary>
        /// Returns the set of session rules for the extension.
        /// </summary>
        public Task<Array<Rule>> GetSessionRules(GetRulesFilter filter) => JSRef!.CallAsync<Array<Rule>>("getSessionRules", filter);
        /// <summary>
        /// Checks if a regular expression is supported as a declarativeNetRequest.RuleCondition.regexFilter rule condition.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<IsRegexSupportedResult> IsRegexSupported(RegexOptions options) => JSRef!.CallAsync<IsRegexSupportedResult>("isRegexSupported", options);
        /// <summary>
        /// Configures how the action count for tabs are handled.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task SetExtensionActionOptions(ExtensionActionOptions options) => JSRef!.CallVoidAsync("setExtensionActionOptions", options);
        /// <summary>
        /// Checks if any of the extension's declarativeNetRequest rules would match a hypothetical request.
        /// </summary>
        /// <returns></returns>
        public Task<TestMatchOutcomeResult> TestMatchOutcome(TestMatchRequestDetails options) => JSRef!.CallAsync<TestMatchOutcomeResult>("testMatchOutcome", options);
        /// <summary>
        /// Modifies the active set of dynamic rules for the extension.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task UpdateDynamicRules(UpdateRuleOptions options) => JSRef!.CallVoidAsync("updateDynamicRules", options);
        /// <summary>
        /// Updates the set of active static rulesets for the extension.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task UpdateEnabledRulesets(UpdateRulesetOptions options) => JSRef!.CallVoidAsync("updateEnabledRulesets", options);
        /// <summary>
        /// Modifies the set of session-scoped rules for the extension.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task UpdateSessionRules(UpdateRuleOptions options) => JSRef!.CallVoidAsync("updateSessionRules", options);
        /// <summary>
        /// Modifies the enabled state of rules in a static ruleset. The number of rules that can be disabled in a ruleset is limited to the value of MAX_NUMBER_OF_DISABLED_STATIC_RULES.<br/>
        /// Rules can be enabled and disabled while the ruleset containing them is disabled. Any changes become effective when the ruleset is enabled.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task UpdateStaticRules(UpdateStaticRulesOptions options) => JSRef!.CallVoidAsync("updateStaticRules", options);
        /// <summary>
        /// Fired when a rule is matched with a request. Only available for unpacked extensions with the "declarativeNetRequestFeedback" permission as this is intended to be used for debugging purposes only.
        /// </summary>
        public ActionEvent<MatchedRuleInfo> OnRuleMatchedDebug { get => JSRef!.Get<ActionEvent<MatchedRuleInfo>>("onRuleMatchedDebug"); set { } }
    }
}
