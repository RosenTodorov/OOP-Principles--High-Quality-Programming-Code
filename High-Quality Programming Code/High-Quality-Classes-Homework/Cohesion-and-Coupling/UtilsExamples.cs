namespace CohesionAndCoupling
{
    using System;
    public class UtilsExamples
    {
        private static void Main()
        {
            Console.WriteLine(FileNameUtilities.GetFileExtension("example"));
            Console.WriteLine(FileNameUtilities.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtilities.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtilities.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtilities.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtilities.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                GeometricalUtilities.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                GeometricalUtilities.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Cube exampleCube = new Cube() { Width = 3, Height = 4, Depth = 5 };
            Console.WriteLine("Volume = {0:f2}", exampleCube.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", exampleCube.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", exampleCube.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", exampleCube.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", exampleCube.CalcDiagonalYZ());
        }
    }
}
