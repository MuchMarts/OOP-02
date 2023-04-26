namespace CMP1903M_A02_2223;

interface Interfaces
{
    public interface IShuffle
    {
        public void Shuffle();
    }
    public interface IEquationBuilder
    {
        public decimal CalculateEquation();
        public string FormatEquation();
    }
}