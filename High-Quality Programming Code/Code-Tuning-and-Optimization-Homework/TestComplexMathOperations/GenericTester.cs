namespace TestComplexMathOperations
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class GenericTester<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>
    {
        private readonly int numberOfOperations = 10000;
        private Stopwatch timer = new Stopwatch();

        public Stopwatch Timer
        {
            get { return this.timer; }

            set { this.timer = value; }
        }

        public void TestType()
        {
            var result = new StringBuilder();

            result.AppendFormat("Adding of {0}: {1}\n\r", typeof(T), this.TestSquareRoot());
            result.AppendFormat("Subtract of {0}: {1}\n\r", typeof(T), this.TestLogarithm());
            result.AppendFormat("Increment of {0}: {1}\n\r", typeof(T), this.TestSinuns());
            
            Console.WriteLine(result.ToString());
        }

        private TimeSpan TestSquareRoot()
        {
            this.Timer.Reset();
            this.Timer.Start();

            for (int i = 4; i <= this.numberOfOperations; i += 4)
            {
                double result = Math.Sqrt(i);
            }

            this.Timer.Stop();

            TimeSpan timeElapsed = this.Timer.Elapsed;

            return timeElapsed;
        }

        private TimeSpan TestLogarithm()
        {
            this.Timer.Reset();
            this.Timer.Start();

            for (int i = 1; i <= this.numberOfOperations; i++)
            {
                double result = Math.Log(i);
            }

            this.Timer.Stop();

            TimeSpan timeElapsed = this.Timer.Elapsed;

            return timeElapsed;
        }

        private TimeSpan TestSinuns()
        {
            this.Timer.Reset();
            this.Timer.Start();
            for (int i = 1; i <= this.numberOfOperations; i++)
            {
                double result = Math.Sin(i);
            }

            this.Timer.Stop();

            TimeSpan timeElapsed = this.Timer.Elapsed;

            return timeElapsed;
        }
    }
}
