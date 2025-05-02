// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using ShyFox.ParticleEngine.Data;

namespace ShyFox.ParticleEngine.Modifiers;

public sealed class OpacityFastFadeModifier : Modifier
{
    public override unsafe void Update(float elapsedSeconds, Particle* particle, int count)
    {
        while (count-- > 0)
        {
            particle->Opacity = 1.0f - particle->Age;
            particle++;
        }
    }
}
