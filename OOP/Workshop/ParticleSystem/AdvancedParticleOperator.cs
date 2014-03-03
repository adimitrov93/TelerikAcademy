using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class AdvancedParticleOperator : ParticleUpdater
    {
        List<ParticleAttractor> attractors = new List<ParticleAttractor>();
        List<ParticleRepeller> repellers = new List<ParticleRepeller>();
        List<Particle> particles = new List<Particle>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var attractorCandidate = p as ParticleAttractor;

            if (attractorCandidate == null)
            {
                var repellerCandidate = p as ParticleRepeller;

                if (repellerCandidate == null)
                {
                    this.particles.Add(p);
                }
                else
                {
                    this.repellers.Add(repellerCandidate);
                }
            }
            else
            {
                this.attractors.Add(attractorCandidate);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var attractor in this.attractors)
            {
                foreach (var particle in this.particles)
                {
                    var currVector = attractor.Position - particle.Position;
                    var currAcceleration = GetAccelerationFromParticleFromAccelerator(currVector, attractor);

                    particle.Accelerate(currAcceleration);
                }
            }

            foreach (var repeller in this.repellers)
            {
                foreach (var particle in this.particles)
                {
                    if (GetEuclideanDistance(repeller.Position, particle.Position) < repeller.WorkRange)
                    {
                        var currVector = particle.Position - repeller.Position;
                        var currAcceleration = GetAccelerationFromParticleFromAccelerator(currVector, repeller);

                        particle.Accelerate(currAcceleration);
                    }
                }
            }

            this.attractors.Clear();
            this.repellers.Clear();
            this.particles.Clear();
            base.TickEnded();
        }

        private static MatrixCoords GetAccelerationFromParticleFromAccelerator(MatrixCoords currVector, ParticleAccelerator accelerator)
        {
            int pToAttrRow = currVector.Row;
            pToAttrRow = DecreaseVectorCoordToPower(accelerator, pToAttrRow);

            int pToAttrCol = currVector.Col;
            pToAttrCol = DecreaseVectorCoordToPower(accelerator, pToAttrCol);

            var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);
            return currAcceleration;
        }

        private static int DecreaseVectorCoordToPower(ParticleAccelerator accelerator, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > accelerator.Power)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * accelerator.Power;
            }
            return pToAttrCoord;
        }

        private static int GetEuclideanDistance(MatrixCoords accelerator, MatrixCoords particle)
        {
            double rowSubstractionSquare = (accelerator.Row - particle.Row) * (accelerator.Row - particle.Row);
            double colSubstractionSquare = (accelerator.Col - particle.Col) * (accelerator.Col - particle.Col);

            double result = Math.Sqrt(rowSubstractionSquare + colSubstractionSquare);

            return (int)result;
        }
    }
}
