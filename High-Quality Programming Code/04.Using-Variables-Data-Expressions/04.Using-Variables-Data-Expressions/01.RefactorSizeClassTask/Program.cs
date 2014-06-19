namespace RefactorSizeClassTask
{
    using System;
    using System.Linq;

    public class Program
    {
        private static void Main(string[] args)
        {
        }

        public class Size
        {
            private double wight;
            private double height;

            public Size(double inputWidth, double inputHeight)
            {
                this.Width = inputWidth;
                this.Height = inputHeight;
            }

            public double Width
            {
                get
                {
                    return this.wight;
                }

                private set
                {
                    this.wight = value;
                }
            }
            public double Height
            {
                get
                {
                    return this.height;
                }

                private set
                {
                    this.height = value;
                }
            }

            public static Size GetRotatedSize(Size sizeInstance, double angle)
            {
                double sin = Math.Abs(Math.Sin(angle));
                double cos = Math.Abs(Math.Cos(angle));

                return new Size(
                    cos * sizeInstance.Width + sin * sizeInstance.Height,
                    sin * sizeInstance.Width + cos * sizeInstance.Height
                    );
            }
        }
    }
}

   