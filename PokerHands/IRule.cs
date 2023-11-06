namespace PokerHands
{
    internal interface IRule
    {
        public RuleResult GetRuleResult(string[] hand);
    }
}
