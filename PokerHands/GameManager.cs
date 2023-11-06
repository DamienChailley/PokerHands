namespace PokerHands
{
    public class GameManager
    {

        public GameManager() {
        
        }

        public void ComputeGameInput(string input)
        {
            string[] playersInfos = input.Split("  ");
            string[] blackHand = playersInfos[0].Split(":")[1].Split(" ");
            string[] whiteHand = playersInfos[1].Split(":")[1].Split(" ");

        }

        private void CompareHands()
        {

        }

        public string ExposeResult() {
            return string.Empty;
        }
    }
}
