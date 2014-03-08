namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        private const int RockOwnership = 0;

        public Rock(int hitPoints, Point position)
            : base(position, RockOwnership)
        {
            this.HitPoints = hitPoints;
        }

        public int Quantity
        {
            get { return this.HitPoints / 2; }
        }

        public ResourceType Type
        {
            get { return ResourceType.Stone; }
        }
    }
}
