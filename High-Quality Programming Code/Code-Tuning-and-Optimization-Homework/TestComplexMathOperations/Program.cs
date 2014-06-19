namespace TestComplexMathOperations
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            GenericTester<double> _double = new GenericTester<double>();
            GenericTester<float> _float = new GenericTester<float>();
            GenericTester<decimal> _decimal = new GenericTester<decimal>();

            _double.TestType();
            _float.TestType();
            _decimal.TestType();
        }
    }
}
