namespace Euclidian3DSpace
{
    using System.Collections.Generic;

    public class Path
    {
        // Fields
        private List<Point3D> pathOfPoints;

        // Counstructors
        public Path()
        {
            pathOfPoints = new List<Point3D>();
        }

        // Properties
        public List<Point3D> PathOfPoints
        {
            get
            {
                return new List<Point3D>(pathOfPoints);
            }
            internal set
            {
                this.pathOfPoints = value;
            }
        }

        // Methods
        public void Add(Point3D newPoint)
        {
            pathOfPoints.Add(newPoint);
        }

        public void Clear()
        {
            pathOfPoints.Clear();
        }
    }
}
