namespace PokerHands
{
    public class RuleResult
    {
        public Composition Composition { get; set; }
        public string[] Grades { get; set; } = new string[0];

        // Used in case the Composition and the Grades are equal.
        public List<string> RemainingGrades { get; set; } = new();
    }
}
