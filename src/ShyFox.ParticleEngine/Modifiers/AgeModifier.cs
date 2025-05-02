// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using ShyFox.ParticleEngine.Data;
using ShyFox.ParticleEngine.Modifiers.Interpolators;

namespace ShyFox.ParticleEngine.Modifiers;

public class AgeModifier : Modifier
{
    public List<Interpolator> Interpolators { get; set; } = new List<Interpolator>();

    public override unsafe void Update(float elapsedSeconds, Particle* particle, int count)
    {
        while (count-- > 0)
        {
            for (var i = 0; i < Interpolators.Count; i++)
            {
                Interpolator interpolator = Interpolators[i];
                interpolator.Update(particle->Age, particle);
            }

            particle++;
        }
    }
}
