// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using ShyFox.ParticleEngine.Data;
using ShyFox.ParticleEngine.Modifiers;

namespace ShyFox.ParticleEngine.Tests;

internal sealed class AssertionModifier : Modifier
{
    private readonly Predicate<Particle> _predicate;

    public AssertionModifier(Predicate<Particle> predicate)
    {
        _predicate = predicate;
    }

    public override unsafe void Update(float elapsedSeconds, Particle* particle, int count)
    {
        while (count-- > 0)
        {
            Assert.True(_predicate(*particle));
            particle++;
        }
    }
}
