using PokerHands;
using PokerHands.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsUnitTests
{
    internal class RulesUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH")]
        public void Test_HighCardRule(string gameInput)
        {
            // Arrange
            HighCardRule rule = new HighCardRule();

            string[] blackHand = HandHelper.GetHand(gameInput.Split("  ")[0]);
            string[] whiteHand = HandHelper.GetHand(gameInput.Split("  ")[1]);

            // Action and asserts.
            Assert.That(Composition.HighCard == rule.GetRuleResult(blackHand).Composition);
            Assert.That("K" == rule.GetRuleResult(blackHand).Grades[0]);

            Assert.That(Composition.HighCard == rule.GetRuleResult(whiteHand).Composition);
            Assert.That("A" == rule.GetRuleResult(whiteHand).Grades[0]);
        }

        [TestCase("Black: 2H 2D 5S 9C KD  White: AC 3H 4S 8C AH")]
        public void Test_Pair(string gameInput)
        {
            PairRule rule = new();

            string[] blackHand = HandHelper.GetHand(gameInput.Split("  ")[0]);
            string[] whiteHand = HandHelper.GetHand(gameInput.Split("  ")[1]);

            // Action and asserts.
            Assert.That(Composition.Pair == rule.GetRuleResult(blackHand).Composition);
            Assert.That("2" == rule.GetRuleResult(blackHand).Grades[0]);

            Assert.That(Composition.Pair == rule.GetRuleResult(whiteHand).Composition);
            Assert.That("A" == rule.GetRuleResult(whiteHand).Grades[0]);
        }
    }
}
