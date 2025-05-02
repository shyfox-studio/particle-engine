// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Numerics;

namespace ShyFox.ParticleEngine.Profiles;

public sealed class PointProfile : Profile
{
    public override unsafe void GetOffsetAndHeading(Vector2* offset, Vector2* heading)
    {
        offset->X = 0.0f;
        offset->Y = 0.0f;
        FastRandom.NextUnitVector(heading);
    }
}
