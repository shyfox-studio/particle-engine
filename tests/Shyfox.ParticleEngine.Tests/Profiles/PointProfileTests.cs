// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Numerics;
using ShyFox.ParticleEngine.Profiles;

namespace ShyFox.ParticleEngine.Tests.Profiles;

public sealed class PointProfileTests
{
    [Fact]
    public void GetOffsetAndHeading_ReturnsZeroOffset()
    {
        PointProfile profile = new PointProfile();
        float[] values = new float[4];

        unsafe
        {
            fixed (float* offset = &values[0])
            {
                fixed (float* heading = &values[2])
                {
                    profile.GetOffsetAndHeading((Vector2*)offset, (Vector2*)heading);

                    Assert.Equal(0.0f, offset[0]);
                    Assert.Equal(0.0f, offset[1]);
                }
            }
        }
    }

    [Fact]
    public void GetOffsetAndHeading_ReturnsHeadingAsUnitVector()
    {
        PointProfile profile = new PointProfile();
        float[] values = new float[4];

        unsafe
        {
            fixed (float* offset = &values[0])
            {
                fixed (float* heading = &values[2])
                {
                    profile.GetOffsetAndHeading((Vector2*)offset, (Vector2*)heading);

                    float length = MathF.Sqrt((heading[0] * heading[0] + (heading[1] * heading[1])));
                    Assert.Equal(1.0f, length, 0.000001f);
                }
            }
        }
    }
}
