// 1. Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed). You are not allowed to edit any existing class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ChaoticParticle : Particle
    {
        protected readonly Random randomGenerator;

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator, int maxSpeedCoords)
            : base(position, speed)
        {
            this.randomGenerator = randomGenerator;
            this.MaxSpeedCoords = maxSpeedCoords;
        }

        public int MaxSpeedCoords { get; private set; }

        public override IEnumerable<Particle> Update()
        {
            MatrixCoords accPower = GenerateRandomSpeed() - this.Speed;         // - this.Speed, because I want to null the current speed and generate brand new.

            this.Accelerate(accPower);

            return base.Update();
        }

        protected MatrixCoords GenerateRandomSpeed()
        {
            int rowSpeed = this.randomGenerator.Next(-this.MaxSpeedCoords, this.MaxSpeedCoords + 1);
            int colSpeed = this.randomGenerator.Next(-this.MaxSpeedCoords, this.MaxSpeedCoords + 1);

            return new MatrixCoords(rowSpeed, colSpeed);
        }
    }
}
