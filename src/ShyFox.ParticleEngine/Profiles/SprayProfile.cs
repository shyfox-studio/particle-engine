// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Numerics;

namespace ShyFox.ParticleEngine.Profiles;

public sealed class SprayProfile : Profile
{
    public Vector2 Direction;
    public float Spread;

    public override unsafe void GetOffsetAndHeading(Vector2* offset, Vector2* heading)
    {
        offset->X = offset->Y = 0.0f;

        float angle = MathF.Atan2(Direction.Y, Direction.X);
        angle = FastRandom.NextSingle(angle - Spread * 0.5f, angle + Spread * 0.5f);

        heading->X = MathF.Cos(angle);
        heading->Y = MathF.Sin(angle);
    }
}
