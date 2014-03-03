/*
 * 5. Implement a ParticleRepeller class. A ParticleRepeller is a Particle, which pushes other particles away from it (i.e. accelerates them in a direction
 * opposite of the direction in which the repeller is). The repeller has an effect only on particles within a certain radius (see Euclidean distance)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleRepeller : ParticleAccelerator
    {
        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int repellationPower, int workRange)
            : base(position, speed, repellationPower)
        {
            this.WorkRange = workRange;
        }

        public int WorkRange { get; private set; }

        public override char[,] GetImage()
        {
            return new char[,] { { 'X' } };
        }
    }
}
