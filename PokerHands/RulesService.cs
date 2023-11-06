namespace PokerHands
{
    internal class RulesService : IRulesService
    {
        /** Rules of the game **/
        private readonly List<IRule> _rules = new();

        public RulesService() { }

        public void AddRuleToRules(IRule rule)
        {
            _rules.Add(rule);
        }
    }
}
