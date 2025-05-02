// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Numerics;
using ShyFox.ParticleEngine.Data;

namespace ShyFox.ParticleEngine.Modifiers;

public class LinearGravityModifier : Modifier
{
    public Vector2 Direction;
    public float Strength;

    public override unsafe void Update(float elapsedSeconds, Particle* particle, int count)
    {
        Vector2 vector = Direction * (Strength * elapsedSeconds);

        while (count-- > 0)
        {
            particle->Velocity[0] = particle->Velocity[0] + vector.X * particle->Mass;
            particle->Velocity[1] = particle->Velocity[1] + vector.Y * particle->Mass;

            particle++;
        }
    }
}
