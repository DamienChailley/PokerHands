namespace PokerHands
{
    internal class RulesService : IRulesService
    {
        /** Rules of the game **/
        private List<IRule> _rules = new();

        public RulesService() { }

        public void AddRuleToRules(IRule rule)
        {
            _rules.Add(rule);
        }

        public RuleResult ComputesHand(string[] hand)
        {
            _rules.Reverse(); // get the most important rules first..

            foreach (var rule in _rules)
            {
                RuleResult ruleResult = rule.GetRuleResult(hand);
                if (ruleResult.Composition != Composition.None)
                {
                    return ruleResult; // returns the first ruleResult that isn't None..
                }
            }
            _rules.Reverse(); // a bit dirty..

            return new() { Composition = Composition.None }; // Not possible, exepted if we didn't add rules.
        }
    }
}
