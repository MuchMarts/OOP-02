namespace CMP1903M_A02_2223;

interface Interfaces
{
    public interface IShuffle
    {
        public void Shuffle();
    }
    public interface IEquationBuilder
    {
        public void CalculateEquation(Card[] cards);
        public string FormatEquation(Card[] cards);
    }
}