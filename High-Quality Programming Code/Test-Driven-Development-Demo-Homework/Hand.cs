namespace Poker
{
    using System;
    using System.Collections.Generic;
    using Poker.Enums;

    public class Hand : IHand
    {
        private static Dictionary<string, CardRank> cardRanks;

        private static Dictionary<char, CardSuit> cardSuits;

        static Hand()
        {
            cardRanks = new Dictionary<string, CardRank>();
            cardRanks["2"] = CardRank.Two;
            cardRanks["3"] = CardRank.Three;
            cardRanks["4"] = CardRank.Four;
            cardRanks["5"] = CardRank.Five;
            cardRanks["6"] = CardRank.Six;
            cardRanks["7"] = CardRank.Seven;
            cardRanks["8"] = CardRank.Eight;
            cardRanks["9"] = CardRank.Nine;
            cardRanks["10"] = CardRank.Ten;
            cardRanks["J"] = CardRank.Jack;
            cardRanks["K"] = CardRank.King;
            cardRanks["Q"] = CardRank.Queen;
            cardRanks["A"] = CardRank.Ace;

            cardSuits = new Dictionary<char, CardSuit>();
            cardSuits['♣'] = CardSuit.Clubs;
            cardSuits['♦'] = CardSuit.Diamonds;
            cardSuits['♥'] = CardSuit.Hearts;
            cardSuits['♠'] = CardSuit.Spades;
        }

        public Hand(ICard[] cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("cards", "cards cannot be null.");
            }

            this.Cards = cards;
        }

        public Hand(string cardNames)
        {
            if (string.IsNullOrWhiteSpace(cardNames))
            {
                throw new ArgumentException("cardNames cannot be null or empty.", "cardNames");
            }

            string[] names = cardNames.Trim().Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            this.Cards = new ICard[names.Length];

            for (int i = 0; i < this.Cards.Length; i++)
            {
                int nameLength = names[i].Length;
                CardRank rank = cardRanks[names[i].Substring(0, nameLength - 1)];
                CardSuit suit = cardSuits[names[i][nameLength - 1]];
                this.Cards[i] = new Card(rank, suit);
            }
        }

        public ICard[] Cards { get; private set; }

        /// <summary>
        /// Sorts (the cards in) the hand in ascending order.
        /// </summary>
        public void Sort()
        {
            Array.Sort(this.Cards);
        }

        public override string ToString()
        {
            this.Sort();
            return string.Join<ICard>(" ", this.Cards);
        }
    }
}