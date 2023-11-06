using PokerHands.Rules;
using System.Data;

namespace PokerHands
{
    public class GameManager
    {
        private readonly RulesService _rulesService;
        private readonly Dictionary<Composition, IRule> _associatedRuleService = new();

        public GameManager()
        {
            _rulesService = new RulesService();
            // soliD => dependencies inversion
            // The parent knows what he want for his 'child'.
            // Allows => + changing behaviour very quickly and easily
            //           + make unit tests possible!
            //           + improve reuse.

            _associatedRuleService.Add(Composition.HighCard, new HighCardRule());
            _associatedRuleService.Add(Composition.Pair, new PairRule());

            foreach (var rule in _associatedRuleService.Values)
            {
                _rulesService.AddRuleToRules(rule);
            }
        }

        public string ComputeGameInput(string input)
        {
            string[] playersInfos = input.Split("  ");

            // Export the string computation in a responsible class (helper).
            // this helper can also be unit tested easily.
            string[] blackHand = HandHelper.GetHand(playersInfos[0]);
            string[] whiteHand = HandHelper.GetHand(playersInfos[1]);

            RuleResult blackRuleResult = _rulesService.ComputesHand(blackHand);
            RuleResult whiteRuleResult = _rulesService.ComputesHand(whiteHand);

            if (blackRuleResult.Composition > whiteRuleResult.Composition)
            {
                // TODO: to improve map composition to formatted string keyword. same for Grade (or with an extension method).
                // TODO: the last part of the sentence is not okay for multiples grades returns. (two pair, etc..)
                return string.Concat("Black wins. - with ", blackRuleResult.Composition, ":", blackRuleResult.Grades[0]);
            }
            else if (blackRuleResult.Composition < whiteRuleResult.Composition)
            {
                //same
                return string.Concat("White wins. - with ", whiteRuleResult.Composition, ":", whiteRuleResult.Grades[0]);
            }
            else
            {
                // All the logic is implement here! for all the rules this code is not going to move anymore :)
                WinningState blackWinningState = _associatedRuleService[blackRuleResult.Composition].GetFirstPlayerState(blackHand, whiteHand);

                if (blackWinningState == WinningState.Win)
                {
                    return string.Concat("Black wins. - with ", blackRuleResult.Composition, ":", blackRuleResult.Grades[0]);
                }
                else if (blackWinningState == WinningState.Lose)
                {
                    return string.Concat("White wins. - with ", whiteRuleResult.Composition, ":", whiteRuleResult.Grades[0]);
                }
                else
                {
                    return string.Concat("Tie");
                }
            }
        }
    }
}
