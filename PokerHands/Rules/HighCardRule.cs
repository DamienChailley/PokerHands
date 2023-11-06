using System.Data;

namespace PokerHands.Rules
{
    // With the following technique, we can as many rules as we want without modifying the existing code.
    public class HighCardRule : IRule
    {
        public RuleResult GetRuleResult(string[] hand)
        {
            int bestCardLevel = -1;
            string bestCardName = string.Empty;

            foreach (string card in hand)
            {
                int level = GameConstants.Grades.IndexOf(card[0].ToString());

                if (level > bestCardLevel)
                {
                    // we found a new best card.
                    bestCardLevel = level;
                    bestCardName = card;
                }
            }

            return new()
            {
                Composition = Composition.HighCard,
                Grades = new string[1] { bestCardName[0].ToString() }
            };

        }

        public WinningState GetFirstPlayerState(string[] firstHand, string[] secondHand)
        {
            RuleResult firstPlayerResult = GetRuleResult(firstHand);
            RuleResult secondPlayerResult = GetRuleResult(secondHand);

            int firstPlayerIndex = GameConstants.Grades.IndexOf(firstPlayerResult.Grades[0]);
            int secondPlayerIndex = GameConstants.Grades.IndexOf(secondPlayerResult.Grades[0]);

            if (firstPlayerIndex > secondPlayerIndex)
            {
                return WinningState.Win;
            }
            else if (firstPlayerIndex < secondPlayerIndex)
            {
                return WinningState.Win;
            }
            else
            {
                return WinningState.Tie;
            }
        }
    }
}
