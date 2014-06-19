namespace Poker
{
    public interface IHand
    {
        ICard[] Cards { get; }
        void Sort();
        string ToString();
    }
}
