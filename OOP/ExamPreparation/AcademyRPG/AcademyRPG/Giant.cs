namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private const int GiantOwnership = 0;
        private const int InitialAttackPoints = 150;

        private int attackPoints;

        public Giant(string name, Point position)
            : base(name, position, GiantOwnership)
        {
            this.HitPoints = 200;
            this.AttackPoints = InitialAttackPoints;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            private set
            {
                this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(System.Collections.Generic.List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (this.attackPoints == InitialAttackPoints)
                {
                    this.attackPoints += 100;
                }

                return true;
            }

            return false;
        }
    }
}
