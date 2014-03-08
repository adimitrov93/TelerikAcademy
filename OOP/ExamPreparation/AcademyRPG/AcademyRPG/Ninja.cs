namespace AcademyRPG
{
    using System.Collections.Generic;

    public class Ninja : Character, IFighter, IGatherer
    {
        private const int NinjasHitPoints = 1;
        private const int InitialAttackPoints = 0;

        private int attackPoints;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.AttackPoints = InitialAttackPoints;
            this.HitPoints = NinjasHitPoints;
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
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int result = -1;
            int highestHitPoints = int.MinValue;

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (availableTargets[i].HitPoints > highestHitPoints)
                    {
                        highestHitPoints = availableTargets[i].HitPoints;
                        result = i;
                    }
                }
            }

            return result;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.attackPoints += resource.Quantity;

                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints += (resource.Quantity * 2);

                return true;
            }

            return false;
        }
    }
}
