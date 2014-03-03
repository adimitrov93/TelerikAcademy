using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleAccelerator : Particle
    {
        public ParticleAccelerator(MatrixCoords position, MatrixCoords speed, int accelerationPower)
            : base(position, speed)
        {
            this.Power = accelerationPower;
        }

        public int Power { get; private set; }
    }
}
