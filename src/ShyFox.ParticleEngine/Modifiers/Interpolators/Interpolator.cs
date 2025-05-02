// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using ShyFox.ParticleEngine.Data;

namespace ShyFox.ParticleEngine.Modifiers.Interpolators;

public abstract class Interpolator
{
    public string Name;

    protected Interpolator()
    {
        Name = GetType().Name;
    }

    public abstract unsafe void Update(float amount, Particle* particle);
}
