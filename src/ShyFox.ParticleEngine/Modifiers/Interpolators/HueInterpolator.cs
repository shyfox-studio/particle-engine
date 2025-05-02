// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using ShyFox.ParticleEngine.Data;

namespace ShyFox.ParticleEngine.Modifiers.Interpolators;

public class HueInterpolator : Interpolator<float>
{
    public override unsafe void Update(float amount, Particle* particle)
    {
        float h = StartValue + (EndValue - StartValue) * amount;
        particle->Color[0] = h;
    }
}
