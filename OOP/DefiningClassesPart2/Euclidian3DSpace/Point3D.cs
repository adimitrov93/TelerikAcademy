namespace Euclidian3DSpace
{
    public struct Point3D
    {
        // Static fields
        private static readonly Point3D start = new Point3D(0, 0, 0);

        // Constructors
        public Point3D(int x, int y, int z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Static properties
        public static Point3D Start
        {
            get
            {
                return start;
            }
        }

        //Properties
        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        // Methods
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }
    }
}
