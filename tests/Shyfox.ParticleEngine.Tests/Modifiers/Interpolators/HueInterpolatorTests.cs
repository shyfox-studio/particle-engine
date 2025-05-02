// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using ShyFox.ParticleEngine.Data;
using ShyFox.ParticleEngine.Modifiers.Interpolators;

namespace ShyFox.ParticleEngine.Tests.Modifiers.Interpolators;

public sealed class HueInterpolatorTests
{
    [Fact]
    public void Update_WhenAmountIsZero_SetsStartValue()
    {
        Particle particle = new Particle();

        HueInterpolator interpolator = new HueInterpolator();
        interpolator.StartValue = 1.0f;
        interpolator.EndValue = 0.0f;

        unsafe
        {
            interpolator.Update(0.0f, &particle);

            Assert.Equal(1.0f, particle.Color[0], 0.000001f);
        }
    }

    [Fact]
    public void Update_WhenAmountIsOne_SetsEndValue()
    {
        Particle particle = new Particle();

        HueInterpolator interpolator = new HueInterpolator();
        interpolator.StartValue = 1.0f;
        interpolator.EndValue = 0.0f;

        unsafe
        {
            interpolator.Update(1.0f, &particle);

            Assert.Equal(0.0f, particle.Color[0], 0.000001f);
        }
    }

    [Fact]
    public void Update_WhenAmountIsHalf_SetHalfValue()
    {
        Particle particle = new Particle();

        HueInterpolator interpolator = new HueInterpolator();
        interpolator.StartValue = 1.0f;
        interpolator.EndValue = 0.0f;

        unsafe
        {
            interpolator.Update(0.5f, &particle);

            Assert.Equal(0.5f, particle.Color[0], 0.000001f);
        }
    }
}
