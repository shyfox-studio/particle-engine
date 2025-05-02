// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Numerics;

namespace ShyFox.ParticleEngine.Profiles;

public sealed class RingProfile : Profile
{
    public float Radius;
    public CircleRadiation Radiate;

    public override unsafe void GetOffsetAndHeading(Vector2* offset, Vector2* heading)
    {
        FastRandom.NextUnitVector(heading);

        switch (Radiate)
        {
            case CircleRadiation.In:
                offset->X = -heading->X * Radius;
                offset->Y = -heading->Y * Radius;
                break;

            case CircleRadiation.Out:
                offset->X = heading->X * Radius;
                offset->Y = heading->Y * Radius;
                break;

            case CircleRadiation.None:
                offset->X = heading->X * Radius;
                offset->Y = heading->Y * Radius;
                FastRandom.NextUnitVector(heading);
                break;

            default:
                throw new ArgumentOutOfRangeException($"{Radiate} is not supported");
        }
    }
}
