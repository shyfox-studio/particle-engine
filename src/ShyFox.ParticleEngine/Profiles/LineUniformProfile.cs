// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Numerics;

namespace ShyFox.ParticleEngine.Profiles;

public sealed class LineProfile : Profile
{
    public Vector2 Axis;
    public float Length;

    public override unsafe void GetOffsetAndHeading(Vector2* offset, Vector2* heading)
    {
        float value = FastRandom.NextSingle(Length * -0.5f, Length * 0.5f);
        offset->X = Axis.X * value;
        offset->Y = Axis.Y * value;
        FastRandom.NextUnitVector(heading);
    }
}
