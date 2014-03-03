/*
 * 3. Create a ChickenParticle class. The ChickenParticle class moves like a ChaoticParticle, but randomly stops at different positions for several simulation ticks and,
 * for each of those stops, creates (lays) a new ChickenParticle. You are not allowed to edit any existing class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ChickenParticle : ChaoticParticle
    {
        private const int defaultMaxWalkTicks = 20;
        private const int defaultMaxLayTicks = 5;

        private readonly int maxWalkTicks;
        private readonly int maxLayTicks;

        private int walkTicks;
        private int layTicks;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator, int maxSpeedCoords, int maxWalkTicks = 0, int maxLayTicks = 0)
            : base(position, speed, randomGenerator, maxSpeedCoords)
        {
            this.maxWalkTicks = maxWalkTicks == 0 ? ChickenParticle.defaultMaxWalkTicks : maxWalkTicks;
            this.maxLayTicks = maxLayTicks == 0 ? ChickenParticle.defaultMaxLayTicks : maxLayTicks;

            RandomizeWaitTicks();
        }

        private void RandomizeWaitTicks()
        {
            this.walkTicks = this.randomGenerator.Next(0, this.maxWalkTicks);
            this.layTicks = this.randomGenerator.Next(0, this.maxLayTicks);
        }

        public override IEnumerable<Particle> Update()
        {
            if (this.walkTicks > 0)
            {
                this.walkTicks--;
                return base.Update();
            }
            else if (this.layTicks > 0)
            {
                this.layTicks--;
                return new List<Particle>();
            }
            else
            {
                RandomizeWaitTicks();

                return new List<Particle>()
                {
                    new ChickenParticle(this.Position, this.GenerateRandomSpeed(), this.randomGenerator, this.MaxSpeedCoords, this.maxWalkTicks, this.maxLayTicks)
                };
            }
        }
    }
}