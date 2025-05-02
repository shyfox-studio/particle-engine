// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using ShyFox.ParticleEngine.Data;

namespace ShyFox.ParticleEngine.Modifiers;

public abstract class Modifier
{
    private const float DEFAULT_MODIFIER_FREQUENCY = 60.0f;

    private int _particlesUpdatedThisCycle;

    public string Name;
    public float Frequency;

    protected Modifier()
    {
        Name = GetType().Name;
        Frequency = DEFAULT_MODIFIER_FREQUENCY;
    }

    public abstract unsafe void Update(float elapsedSeconds, Particle* particle, int count);

    internal unsafe void InternalUpdate(float elapsedSeconds, Particle* buffer, int count)
    {
        float cycleTime = 1.0f / Frequency;
        int particlesRemaining = count - _particlesUpdatedThisCycle;
        int particlesToUpdate = Math.Min(particlesRemaining, (int)Math.Ceiling((elapsedSeconds / cycleTime) * count));

        if (particlesToUpdate > 0)
        {
            Update(cycleTime, buffer + _particlesUpdatedThisCycle, particlesToUpdate);
            _particlesUpdatedThisCycle += particlesToUpdate;
        }

        if (_particlesUpdatedThisCycle >= count)
        {
            _particlesUpdatedThisCycle = 0;
        }
    }
}
