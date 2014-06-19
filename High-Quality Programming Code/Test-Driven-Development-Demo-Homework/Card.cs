namespace Poker
{
    using Poker.Enums;

    public class Card : ICard
    {
        private static readonly string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        // http://en.wikipedia.org/wiki/Alt_code
        private static readonly char[] Suits = { '♣', '♦', '♥', '♠' };

        public Card(CardRank rank, CardSuit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public CardRank Rank { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            return Ranks[(int)this.Rank - 2] + Suits[(int)this.Suit];
        }

        public int CompareTo(ICard other)
        {
            return this.Rank.CompareTo(other.Rank);
        }

        public bool Equals(ICard other)
        {
            return this.Rank == other.Rank && this.Suit == other.Suit;
        }
    }
}