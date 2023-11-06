using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Rules
{
    public class PairRule : IRule
    {
        public RuleResult GetRuleResult(string[] hand)
        {
            List<char> existingPairs = new();

            foreach (var card in hand) {
                // 2,3,...,J,Q,K,A..
                char gradeIdentifier = card[0];
                foreach(string aCard in hand)
                {
                    if(aCard == card)
                    {
                        continue; // we are iterating on the same card.
                    }
                    char otherCardGradeIdentifier = aCard[0];

                    if(gradeIdentifier == otherCardGradeIdentifier)
                    {
                        // Could be done in a better way..
                        if(!existingPairs.Contains(card[0]))
                        {
                            // This is equivalent to Grades (of GameConstants).
                            existingPairs.Add(card[0]);
                        }
                    }
                }
            }

            List<string> additionalGrades = GetRemainingGrades(hand, existingPairs);

            // Get the list of index (linked to the list of grades) than take the max index (the best grade).
            int maxIndex = existingPairs.Select(x => GameConstants.Grades.IndexOf(x.ToString())).Max();

            if (maxIndex != -1)
            {
                return new RuleResult()
                {
                    Composition = Composition.Pair,
                    Grades = new string[] { GameConstants.Grades[maxIndex] },
                    RemainingGrades = additionalGrades
                };
            }
            else
            {
                return new() { Composition = Composition.None };
            }
        }


        /// <summary>
        /// Get all the grades (without duplication that don't have be put in the list already).
        /// </summary>
        private List<string> GetRemainingGrades(string[] hand, List<char> existingPairs)
        {
            List<string> additionalGrades = new();

            foreach (var card in hand)
            {
                // 2,3,...,J,Q,K,A..
                char gradeIdentifier = card[0];
                if (!existingPairs.Contains(gradeIdentifier) && !additionalGrades.Contains(gradeIdentifier.ToString()))
                {
                    additionalGrades.Add(gradeIdentifier.ToString());
                }
            }
            return additionalGrades;
        }


        public WinningState GetFirstPlayerState(string[] firstHand, string[] secondHand)
        {
            return WinningState.Tie; // TODO
        }
    }
}
