// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace ShyFox.ParticleEngine.Modifiers.Interpolators;

public abstract class Interpolator<T> : Interpolator where T : struct
{
    public T StartValue;
    public T EndValue;
}
