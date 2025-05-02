// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using ShyFox.ParticleEngine.Data;

namespace ShyFox.ParticleEngine.Modifiers;

public class RotationModifier : Modifier
{
    public float RotationRate;

    public override unsafe void Update(float elapsedSeconds, Particle* particle, int count)
    {
        float rotationRateDelta = RotationRate * elapsedSeconds;

        while (count-- > 0)
        {
            particle->Rotation += rotationRateDelta;
            particle++;
        }
    }
}
