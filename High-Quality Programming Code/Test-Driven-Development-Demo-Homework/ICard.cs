namespace Poker
{
    using System;
    using Poker.Enums;

    public interface ICard : IComparable<ICard>, IEquatable<ICard>
    {
        CardRank Rank { get; }
        CardSuit Suit { get; }
        string ToString();
    }
}