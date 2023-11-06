namespace PokerHands
{
    internal interface IRule
    {
        public RuleResult GetRuleResult(string[] hand);

        public WinningState GetFirstPlayerState(string[] firstHand, string[] secondHand);
    }
}
