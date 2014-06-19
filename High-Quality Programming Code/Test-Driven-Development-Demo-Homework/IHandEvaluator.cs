namespace Poker
{
    using Poker.Enums;

    public interface IHandEvaluator
    {
        bool IsValid(IHand hand);

        HandCategory GetCategory(IHand hand);

        int CompareHands(IHand hand1, IHand hand2);
    }
}
