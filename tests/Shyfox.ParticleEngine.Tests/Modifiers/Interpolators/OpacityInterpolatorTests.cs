// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using ShyFox.ParticleEngine.Data;
using ShyFox.ParticleEngine.Modifiers.Interpolators;

namespace ShyFox.ParticleEngine.Tests.Modifiers.Interpolators;

public sealed class OpacityInterpolatorTests
{
    [Fact]
    public void Update_WhenAmountIsZero_SetsStartValue()
    {
        Particle particle = new Particle();

        OpacityInterpolator interpolator = new OpacityInterpolator();
        interpolator.StartValue = 1.0f;
        interpolator.EndValue = 0.0f;

        unsafe
        {
            interpolator.Update(0.0f, &particle);

            Assert.Equal(1.0f, particle.Opacity, 0.000001f);
        }
    }

    [Fact]
    public void Update_WhenAmountIsOne_SetsEndValue()
    {
        Particle particle = new Particle();

        OpacityInterpolator interpolator = new OpacityInterpolator();
        interpolator.StartValue = 1.0f;
        interpolator.EndValue = 0.0f;

        unsafe
        {
            interpolator.Update(1.0f, &particle);

            Assert.Equal(0.0f, particle.Opacity, 0.000001f);
        }
    }

    [Fact]
    public void Update_WhenAmountIsHalf_SetHalfValue()
    {
        Particle particle = new Particle();

        OpacityInterpolator interpolator = new OpacityInterpolator();
        interpolator.StartValue = 1.0f;
        interpolator.EndValue = 0.0f;

        unsafe
        {
            interpolator.Update(0.5f, &particle);

            Assert.Equal(0.5f, particle.Opacity, 0.000001f);
        }
    }
}
