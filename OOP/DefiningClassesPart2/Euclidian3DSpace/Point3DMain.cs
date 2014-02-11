namespace Euclidian3DSpace
{
    using System;
    using System.Collections.Generic;

    public class Point3DMain
    {
        const string inputPath = "C:\\inputPath.txt";
        const string outputPath = "C:\\outputPath.txt";

        public static void Main()
        {
            Point3D a = new Point3D(3, 5, 6);
            Point3D b = new Point3D()
            {
                X = 3,
                Y = 9,
                Z = 1
            };

            Console.WriteLine("Distance between ({0},{1},{2}) and ({3},{4},{5}) is {6:F2}", 
                a.X, a.Y, a.Z, b.X, b.Y, b.Z, Distance.CalcDistance(a, b));
            Console.WriteLine("Distance between ({0},{1},{2}) and ({3},{4},{5}) is {6:F2}", 
                a.X, a.Y, a.Z, Point3D.Start.X, Point3D.Start.Y, Point3D.Start.Z, Distance.CalcDistance(a, Point3D.Start));

            Path path = new Path();
            List<Point3D> newPath = new List<Point3D>();
            newPath.Add(new Point3D(1, 2, 3));
            newPath.Add(new Point3D(4, 5, 6));
            newPath.Add(new Point3D(7, 8, 9));

            path.PathOfPoints = newPath;

            foreach (var item in path.PathOfPoints)
            {
                Console.WriteLine("({0},{1},{2})", item.X, item.Y, item.Z);
            }

            PathStorage.Save(path.PathOfPoints, outputPath);
            path.PathOfPoints = PathStorage.Load(inputPath);

            foreach (var item in path.PathOfPoints)
            {
                Console.WriteLine("({0},{1},{2})", item.X, item.Y, item.Z);
            }
        }
    }
}