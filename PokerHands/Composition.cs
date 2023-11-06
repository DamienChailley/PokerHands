namespace PokerHands
{

    /// <summary>
    /// Enumeration of the posible result of a rule.
    /// A rule can have either None or One of the following types. (can have more than one).
    /// </summary>
    public enum Composition
    {
        None, // equivalent to the no composition find.
        HighCard,
        Pair,
        TwoPair,
        ThreeOfKind,
        Flush,
        FullHouse,
        FourOfKind,
        StraightFlush
    }
}
