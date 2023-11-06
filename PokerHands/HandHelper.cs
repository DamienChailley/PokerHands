namespace PokerHands
{
    public static class HandHelper
    {
        public static string[] GetHand(string playerInput)
        {
            string[] splittedInput = playerInput.Split(":");

            if (splittedInput.Length > 0 )
            {
                // we skip the first index since it's always " " item.
                return splittedInput[1].Split(" ").Skip(1).ToArray();
            }
            throw new Exception("Input is incorrect");
        }
    }
}
