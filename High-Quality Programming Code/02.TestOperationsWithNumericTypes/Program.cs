namespace TestOperationsWithNumericTypes
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            GenericTester<int> _integer = new GenericTester<int>();
            GenericTester<long> _long = new GenericTester<long>();
            GenericTester<double> _double = new GenericTester<double>();
            GenericTester<float> _float = new GenericTester<float>();
            GenericTester<decimal> _decimal = new GenericTester<decimal>();

            _integer.TestType();
            _long.TestType();
            _double.TestType();
            _float.TestType();
            _decimal.TestType();
        }
    }
}