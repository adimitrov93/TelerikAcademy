namespace Euclidian3DSpace
{
    using System;

    public static class Distance
    {
        public static double CalcDistance(Point3D a, Point3D b)
        {
            double xd = a.X - b.X;
            double yd = a.Y - b.Y;
            double zd = a.Z - b.Z;

            return (Math.Sqrt(xd * xd + yd * yd + zd * zd));
        }
    }
}
