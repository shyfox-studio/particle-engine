// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Numerics;
using ShyFox.ParticleEngine.Data;

namespace ShyFox.ParticleEngine.Modifiers.Interpolators;

public class VelocityInterpolator : Interpolator<Vector2>
{
    public override unsafe void Update(float amount, Particle* particle)
    {
        particle->Velocity[0] = (EndValue.X - StartValue.X) * amount + StartValue.X;
        particle->Velocity[1] = (EndValue.Y - StartValue.Y) * amount + StartValue.Y;
    }
}
