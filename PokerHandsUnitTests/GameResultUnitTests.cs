using PokerHands;

namespace PokerHandsUnitTests
{
    public class Tests
    {

        private GameManager _gameManager = new(); 

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH")]
        public void Test_GameResult(string gameInput)
        {
            // Arrange
            _gameManager.ComputeGameInput(gameInput);   
        
            // Action

            // Assert

        }
    }
}