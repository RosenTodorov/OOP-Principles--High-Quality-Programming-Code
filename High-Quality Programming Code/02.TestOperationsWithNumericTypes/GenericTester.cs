namespace TestOperationsWithNumericTypes
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Numerics;
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

            result.AppendFormat("Adding of {0}: {1}\n\r", typeof(T), this.TestAdding());
            result.AppendFormat("Subtract of {0}: {1}\n\r", typeof(T), this.TestSubtract());
            result.AppendFormat("Increment of {0}: {1}\n\r", typeof(T), this.TestIncrement());
            result.AppendFormat("Multiply of {0}: {1}\n\r", typeof(T), this.TestMultiply());
            result.AppendFormat("Divide of {0}: {1}\n\r", typeof(T), this.TestDivide());
            Console.WriteLine(result.ToString());
        }

        private TimeSpan TestIncrement()
        {
            this.Timer.Reset();
            this.Timer.Start();
            BigInteger result = 0;
            for (int i = 1; i <= this.numberOfOperations; i++)
            {
                result++;
            }

            this.Timer.Stop();

            TimeSpan timeElapsed = this.Timer.Elapsed;

            return timeElapsed;
        }

        private TimeSpan TestMultiply()
        {
            this.Timer.Reset();
            this.Timer.Start();
            BigInteger result = 1;
            for (int i = 1; i <= this.numberOfOperations; i++)
            {
                result *= i;
            }

            this.Timer.Stop();

            TimeSpan timeElapsed = this.Timer.Elapsed;

            return timeElapsed;
        }

        private TimeSpan TestDivide()
        {
            this.Timer.Reset();
            this.Timer.Start();
            BigInteger result = this.numberOfOperations * 2;
            for (int i = 1; i <= this.numberOfOperations; i++)
            {
                result /= i;
            }

            this.Timer.Stop();

            TimeSpan timeElapsed = this.Timer.Elapsed;

            return timeElapsed;
        }

        private TimeSpan TestAdding()
        {
            this.Timer.Reset();
            this.Timer.Start();
            BigInteger result = 0;
            for (int i = 1; i <= this.numberOfOperations; i++)
            {
                result += i;
            }

            this.Timer.Stop();

            TimeSpan timeElapsed = this.Timer.Elapsed;

            return timeElapsed;
        }

        private TimeSpan TestSubtract()
        {
            this.Timer.Reset();
            this.Timer.Start();
            BigInteger result = this.numberOfOperations * 2;
            for (int i = 1; i <= this.numberOfOperations; i++)
            {
                result -= i;
            }

            this.Timer.Stop();

            TimeSpan timeElapsed = this.Timer.Elapsed;

            return timeElapsed;
        }
    }
}