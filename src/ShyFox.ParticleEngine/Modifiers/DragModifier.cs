// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using ShyFox.ParticleEngine.Data;

namespace ShyFox.ParticleEngine.Modifiers;

public class DragModifier : Modifier
{
    public float DragCoefficient = 0.47f;
    public float Density = .5f;

    public override unsafe void Update(float elapsedSeconds, Particle* particle, int count)
    {
        while (count-- > 0)
        {
            var drag = -DragCoefficient * Density * particle->Mass * elapsedSeconds;

            particle->Velocity[0] = particle->Velocity[0] + particle->Velocity[0] * drag;
            particle->Velocity[1] = particle->Velocity[1] + particle->Velocity[1] * drag;

            particle++;
        }
    }
}
