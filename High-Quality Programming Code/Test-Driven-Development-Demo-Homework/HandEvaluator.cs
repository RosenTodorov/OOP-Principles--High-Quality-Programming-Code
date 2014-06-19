namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Poker.Enums;

    /// <summary>
    /// Defines methods which evaluate poker hands.
    /// </summary>
    /// <seealso cref="http://nsayer.blogspot.com/2007/07/algorithm-for-evaluating-poker-hands.html"/>
    public class HandEvaluator : IHandEvaluator
    {
        public const int HandSize = 5;

        private Dictionary<CardRank, int> histogram = new Dictionary<CardRank, int>();

        private CardRank[] cardRanks = new CardRank[]
        {
            CardRank.Two,
            CardRank.Three,
            CardRank.Four,
            CardRank.Five,
            CardRank.Six,
            CardRank.Seven,
            CardRank.Eight,
            CardRank.Nine,
            CardRank.Ten,
            CardRank.Jack,
            CardRank.Queen,
            CardRank.King,
            CardRank.Ace
        };

        public HandEvaluator()
        {
            this.ClearHistogram();
        }

        public bool IsValid(IHand hand)
        {
            if (hand == null)
            {
                return false;
            }

            ICard[] cards = hand.Cards;

            if (cards.Length != HandSize)
            {
                return false;
            }

            for (int i = 0; i < cards.Length - 1; i++)
            {
                for (int j = i + 1; j < cards.Length; j++)
                {
                    if (cards[i].Equals(cards[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public HandCategory GetCategory(IHand hand)
        {
            if (!this.IsValid(hand))
            {
                string message =
                    string.Format("Invalid hand. A hand always consists of {0} different cards.", HandSize);
                throw new ArgumentException(message, "hand");
            }

            var cardRanksOrderedByCountDescending = this.GetCardRanksOrderedByCountDescending(hand);

            if (cardRanksOrderedByCountDescending[0].Value == 4)
            {
                return HandCategory.FourOfAKind;
            }

            if (cardRanksOrderedByCountDescending[0].Value == 3 &&
                cardRanksOrderedByCountDescending[1].Value == 2)
            {
                return HandCategory.FullHouse;
            }

            if (cardRanksOrderedByCountDescending[0].Value == 3 &&
                cardRanksOrderedByCountDescending[1].Value == 1)
            {
                return HandCategory.ThreeOfAKind;
            }

            if (cardRanksOrderedByCountDescending[0].Value == 2 &&
                cardRanksOrderedByCountDescending[1].Value == 2)
            {
                return HandCategory.TwoPair;
            }

            if (cardRanksOrderedByCountDescending[0].Value == 2 &&
                cardRanksOrderedByCountDescending[1].Value == 1 &&
                cardRanksOrderedByCountDescending[2].Value == 1)
            {
                return HandCategory.OnePair;
            }

            bool flush = this.CheckFlush(hand);

            bool straight = this.CheckStraight(hand);

            if (straight && flush)
            {
                return HandCategory.StraightFlush;
            }

            if (straight)
            {
                return HandCategory.Straight;
            }

            if (flush)
            {
                return HandCategory.Flush;
            }

            return HandCategory.HighCard;
        }

        public int CompareHands(IHand hand1, IHand hand2)
        {
            HandCategory category1 = this.GetCategory(hand1);
            HandCategory category2 = this.GetCategory(hand2);

            if (category1 < category2)
            {
                // hand1 ranks lower than hand2
                return -1;
            }

            if (category1 > category2)
            {
                // hand1 ranks above hand2
                return 1;
            }

            hand1.Sort();
            hand2.Sort();

            // hand1 and hand2 are of the same type
            switch (category1)
            {
                case HandCategory.StraightFlush:
                case HandCategory.Straight:
                    {
                        return this.CompareStraightHands(hand1, hand2);
                    }

                case HandCategory.FourOfAKind:
                    {
                        return this.CompareFourOfAKindHands(hand1, hand2);
                    }

                case HandCategory.FullHouse:
                    {
                        return this.CompareFullHouseHands(hand1, hand2);
                    }

                case HandCategory.Flush:
                    {
                        return this.CompareHighCardHands(hand1, hand2);
                    }

                case HandCategory.ThreeOfAKind:
                    {
                        return this.CompareThreeOfAKindHands(hand1, hand2);
                    }

                case HandCategory.TwoPair:
                    {
                        return this.CompareTwoPairHands(hand1, hand2);
                    }

                case HandCategory.OnePair:
                    {
                        return this.CompareOnePairHands(hand1, hand2);
                    }

                default:
                    {
                        return this.CompareHighCardHands(hand1, hand2);
                    }
            }
        }

        private int CompareOnePairHands(IHand sortedHand1, IHand sortedHand2)
        {
            ICard hand1PairFirstCard;
            ICard hand1HighestKicker;
            ICard hand1MiddleKicker;
            ICard hand1LowestKicker;

            this.GetCardsInOnePair(
                sortedHand1,
                out hand1PairFirstCard,
                out hand1HighestKicker,
                out hand1MiddleKicker,
                out hand1LowestKicker);

            ICard hand2PairFirstCard;
            ICard hand2HighestKicker;
            ICard hand2MiddleKicker;
            ICard hand2LowestKicker;

            this.GetCardsInOnePair(
                sortedHand2,
                out hand2PairFirstCard,
                out hand2HighestKicker,
                out hand2MiddleKicker,
                out hand2LowestKicker);

            int pairCompareResult = hand1PairFirstCard.CompareTo(hand2PairFirstCard);
            if (pairCompareResult != 0)
            {
                return pairCompareResult;
            }

            int highestKickerCompareResult = hand1HighestKicker.CompareTo(hand2HighestKicker);
            if (highestKickerCompareResult != 0)
            {
                return highestKickerCompareResult;
            }

            int middleKickerCompareResult = hand1MiddleKicker.CompareTo(hand2MiddleKicker);
            if (middleKickerCompareResult != 0)
            {
                return middleKickerCompareResult;
            }

            return hand1LowestKicker.CompareTo(hand2LowestKicker);
        }

        private void GetCardsInOnePair(IHand sortedHand, out ICard pairFirstCard, out ICard highestKicker, out ICard middleKicker, out ICard lowestKicker)
        {
            pairFirstCard = sortedHand.Cards[0];
            int pairFirstCardIndex = 0;
            for (int i = 1; i < sortedHand.Cards.Length - 1; i++)
            {
                if (sortedHand.Cards[i].CompareTo(sortedHand.Cards[i + 1]) == 0)
                {
                    pairFirstCard = sortedHand.Cards[i];
                    pairFirstCardIndex = i;
                    break;
                }
            }

            highestKicker = sortedHand.Cards[4];
            int highestKickerIndex = 4;
            if (pairFirstCardIndex == 3)
            {
                highestKicker = sortedHand.Cards[2];
                highestKickerIndex = 2;
            }

            if (highestKickerIndex == 4)
            {
                middleKicker = sortedHand.Cards[3];
                if (pairFirstCardIndex == 2)
                {
                    middleKicker = sortedHand.Cards[1];
                }
            }
            else
            {
                middleKicker = sortedHand.Cards[1];
            }

            lowestKicker = sortedHand.Cards[0];
            if (pairFirstCardIndex == 0)
            {
                lowestKicker = sortedHand.Cards[2];
            }
        }

        private int CompareTwoPairHands(IHand sortedHand1, IHand sortedHand2)
        {
            ICard hand1Kicker;
            ICard hand1HigherPairFirstCard;
            ICard hand1LowerPairFirstCard;
            this.GetCardsInTwoPair(sortedHand1, out hand1Kicker, out hand1HigherPairFirstCard, out hand1LowerPairFirstCard);

            ICard hand2Kicker;
            ICard hand2HigherPairFirstCard;
            ICard hand2LowerPairFirstCard;
            this.GetCardsInTwoPair(sortedHand2, out hand2Kicker, out hand2HigherPairFirstCard, out hand2LowerPairFirstCard);

            int higherPairCompareResult = hand1HigherPairFirstCard.CompareTo(hand2HigherPairFirstCard);
            if (higherPairCompareResult != 0)
            {
                return higherPairCompareResult;
            }

            int lowerPairCompareResult = hand1LowerPairFirstCard.CompareTo(hand2LowerPairFirstCard);
            if (lowerPairCompareResult != 0)
            {
                return lowerPairCompareResult;
            }

            return hand1Kicker.CompareTo(hand2Kicker);
        }

        private void GetCardsInTwoPair(IHand sortedHand, out ICard kicker, out ICard higherPairFirstCard, out ICard lowerPairFirstCard)
        {
            kicker = sortedHand.Cards[0];
            int kickerIndex = 0;

            if (kicker.CompareTo(sortedHand.Cards[1]) == 0)
            {
                kicker = sortedHand.Cards[2];
                kickerIndex = 2;
                if (kicker.CompareTo(sortedHand.Cards[3]) == 0)
                {
                    kicker = sortedHand.Cards[4];
                    kickerIndex = 4;
                }
            }

            if (kickerIndex == 0)
            {
                higherPairFirstCard = sortedHand.Cards[3];
                lowerPairFirstCard = sortedHand.Cards[1];
            }
            else if (kickerIndex == 2)
            {
                higherPairFirstCard = sortedHand.Cards[3];
                lowerPairFirstCard = sortedHand.Cards[0];
            }
            else
            {
                higherPairFirstCard = sortedHand.Cards[2];
                lowerPairFirstCard = sortedHand.Cards[0];
            }
        }

        private int CompareThreeOfAKindHands(IHand sortedHand1, IHand sortedHand2)
        {
            // Cards[2] in a sorted hand is guaranteed to be one of the group of three
            int groupOfThreeCompareResult = sortedHand1.Cards[2].CompareTo(sortedHand2.Cards[2]);

            if (groupOfThreeCompareResult != 0)
            {
                return groupOfThreeCompareResult;
            }

            ICard hand1HigherUnmatchedCard;
            ICard hand1LowerUnmatchedCard;
            this.GetUnmatchedCardsInThreeOfAKind(sortedHand1, out hand1HigherUnmatchedCard, out hand1LowerUnmatchedCard);

            ICard hand2HigherUnmatchedCard;
            ICard hand2LowerUnmatchedCard;
            this.GetUnmatchedCardsInThreeOfAKind(sortedHand2, out hand2HigherUnmatchedCard, out hand2LowerUnmatchedCard);

            int higherUnmatchedCardCompareResult = hand1HigherUnmatchedCard.CompareTo(hand2HigherUnmatchedCard);
            if (higherUnmatchedCardCompareResult != 0)
            {
                return higherUnmatchedCardCompareResult;
            }

            return hand1LowerUnmatchedCard.CompareTo(hand2LowerUnmatchedCard);
        }

        private void GetUnmatchedCardsInThreeOfAKind(IHand sortedHand, out ICard higherUnmatchedCard, out ICard lowerUnmatchedCard)
        {
            int groupOfThreeEndIndex = 2;

            if (sortedHand.Cards[3].CompareTo(sortedHand.Cards[2]) == 0)
            {
                groupOfThreeEndIndex = 3;
            }

            if (sortedHand.Cards[4].CompareTo(sortedHand.Cards[2]) == 0)
            {
                groupOfThreeEndIndex = 4;
            }

            if (groupOfThreeEndIndex == 2)
            {
                higherUnmatchedCard = sortedHand.Cards[4];
                lowerUnmatchedCard = sortedHand.Cards[3];
            }
            else if (groupOfThreeEndIndex == 3)
            {
                higherUnmatchedCard = sortedHand.Cards[4];
                lowerUnmatchedCard = sortedHand.Cards[0];
            }
            else
            {
                higherUnmatchedCard = sortedHand.Cards[1];
                lowerUnmatchedCard = sortedHand.Cards[0];
            }
        }

        private int CompareHighCardHands(IHand sortedHand1, IHand sortedHand2)
        {
            for (int i = sortedHand1.Cards.Length - 1; i >= 0; i--)
            {
                int compareResult = sortedHand1.Cards[i].CompareTo(sortedHand2.Cards[i]);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }

            return 0;
        }

        private int CompareFullHouseHands(IHand sortedHand1, IHand sortedHand2)
        {
            // Cards[2] in a sorted hand is guaranteed to be one of the group of three
            int groupOfThreeCompareResult = sortedHand1.Cards[2].CompareTo(sortedHand2.Cards[2]);

            if (groupOfThreeCompareResult != 0)
            {
                return groupOfThreeCompareResult;
            }

            ICard hand1PairFirstCard = sortedHand1.Cards[3];

            if (hand1PairFirstCard.CompareTo(sortedHand1.Cards[2]) == 0)
            {
                hand1PairFirstCard = sortedHand1.Cards[0];
            }

            ICard hand2PairFirstCard = sortedHand2.Cards[3];

            if (hand2PairFirstCard.CompareTo(sortedHand2.Cards[2]) == 0)
            {
                hand2PairFirstCard = sortedHand2.Cards[0];
            }

            return hand1PairFirstCard.CompareTo(hand2PairFirstCard);
        }

        private int CompareFourOfAKindHands(IHand sortedHand1, IHand sortedHand2)
        {
            // Cards[1] in a sorted hand is guaranteed to be one of the quad
            int quadCompareResult = sortedHand1.Cards[1].CompareTo(sortedHand2.Cards[1]);
            if (quadCompareResult != 0)
            {
                return quadCompareResult;
            }

            ICard hand1UnmatchedCard = sortedHand1.Cards[0];

            if (hand1UnmatchedCard.CompareTo(sortedHand1.Cards[1]) == 0)
            {
                hand1UnmatchedCard = sortedHand1.Cards[4];
            }

            ICard hand2UnmatchedCard = sortedHand2.Cards[0];

            if (hand2UnmatchedCard.CompareTo(sortedHand2.Cards[1]) == 0)
            {
                hand2UnmatchedCard = sortedHand2.Cards[4];
            }

            return hand1UnmatchedCard.CompareTo(hand2UnmatchedCard);
        }

        private int CompareStraightHands(IHand sortedHand1, IHand sortedHand2)
        {
            CardRank hand1HighestRank = sortedHand1.Cards[4].Rank;

            if (sortedHand1.Cards[4].Rank == CardRank.Ace &&
                sortedHand1.Cards[3].Rank == CardRank.Five)
            {
                // a wheel
                hand1HighestRank = CardRank.Five;
            }

            CardRank hand2HighestRank = sortedHand2.Cards[4].Rank;

            if (sortedHand2.Cards[4].Rank == CardRank.Ace &&
                sortedHand2.Cards[3].Rank == CardRank.Five)
            {
                // a wheel
                hand2HighestRank = CardRank.Five;
            }

            return hand1HighestRank.CompareTo(hand2HighestRank);
        }

        private void ClearHistogram()
        {
            foreach (CardRank rank in this.cardRanks)
            {
                this.histogram[rank] = 0;
            }
        }

        private KeyValuePair<CardRank, int>[] GetCardRanksOrderedByCountDescending(IHand hand)
        {
            this.ClearHistogram();

            foreach (ICard card in hand.Cards)
            {
                this.histogram[card.Rank]++;
            }

            return this.histogram.OrderByDescending(pair => pair.Value).ToArray();
        }

        private bool CheckFlush(IHand hand)
        {
            ICard[] cards = hand.Cards;

            for (int i = 1; i < cards.Length; i++)
            {
                if (cards[0].Suit != cards[i].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckStraight(IHand hand)
        {
            hand.Sort();

            if ((hand.Cards[4].Rank - hand.Cards[0].Rank) == 4)
            {
                return true;
            }

            if (hand.Cards[4].Rank == CardRank.Ace &&
                hand.Cards[3].Rank == CardRank.Five)
            {
                // a wheel: A, 2, 3, 4, 5
                return true;
            }

            return false;
        }
    }
}









