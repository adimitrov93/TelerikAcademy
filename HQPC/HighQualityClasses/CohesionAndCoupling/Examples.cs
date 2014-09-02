namespace CohesionAndCoupling
{
    using System;

    public class Examples
    {
        public static void Main()
        {
            // I remove this line because it contains invalid filename without file extension in most cases.
            // Console.WriteLine(FileNameOperations.GetFileExtension("example"));
            Console.WriteLine(FileNameOperations.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameOperations.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameOperations.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameOperations.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameOperations.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", OperationsIn2d.CalcDistance(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", OperationsIn3d.CalcDistance(5, 2, -1, 3, -6, 4));

            Console.WriteLine("Diagonal XY = {0:f2}", OperationsIn2d.CalcDiagonalXY(3, 4));
            Console.WriteLine("Diagonal XZ = {0:f2}", OperationsIn2d.CalcDiagonalXZ(3, 5));
            Console.WriteLine("Diagonal YZ = {0:f2}", OperationsIn2d.CalcDiagonalYZ(4, 5));

            Console.WriteLine("Volume = {0:f2}", OperationsIn3d.CalcVolume(3, 4, 5));
            Console.WriteLine("Diagonal XYZ = {0:f2}", OperationsIn3d.CalcDiagonalXYZ(3, 4, 5));
        }
    }
}
