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

            // Get the list of index (linked to the list of grades) than take the max index (the best grade).
            int maxIndex = existingPairs.Select(x => GameConstants.Grades.IndexOf(x.ToString())).Max();

            if (maxIndex != -1)
            {
                return new RuleResult()
                {
                    Composition = Composition.Pair,
                    Grades = new string[] { GameConstants.Grades[maxIndex] }
                };
            }
            else
            {
                return new() { Composition = Composition.None };
            }
        }
    }
}
