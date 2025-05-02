// Copyright (c) ShyFox Studio. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Numerics;
using System.Text.Json.Serialization;

namespace ShyFox.ParticleEngine;

public class ParticleEffect : IDisposable
{
    public string Name;
    public Vector2 Position;
    public float Rotation;
    public Vector2 Scale;
    public List<ParticleEmitter> Emitters;

    [JsonIgnore]
    public bool IsDisposed { get; private set; }

    [JsonIgnore]
    public int ActiveParticles => Emitters.Sum(t => t.ActiveParticles);

    public ParticleEffect(string name)
    {
        Name = name;
        Position = Vector2.Zero;
        Rotation = 0.0f;
        Scale = Vector2.One;
        Emitters = new List<ParticleEmitter>();
    }

    ~ParticleEffect() => Dispose(false);

    public void FastForward(Vector2 position, float seconds, float triggerPeriod)
    {
        float time = 0.0f;
        while (time < seconds)
        {
            Update(triggerPeriod);
            Trigger(position);
            time += triggerPeriod;
        }
    }

    public void Update(float elapsedSeconds)
    {
        ObjectDisposedException.ThrowIf(IsDisposed, typeof(ParticleBuffer));

        for (int i = 0; i < Emitters.Count; i++)
        {
            Emitters[i].Update(elapsedSeconds, Position);
        }
    }

    public void Trigger() => Trigger(Position);
    public void Trigger(Vector2 position, float layerDepth = 0)
    {
        ObjectDisposedException.ThrowIf(IsDisposed, typeof(ParticleBuffer));

        for (int i = 0; i < Emitters.Count; i++)
        {
            Emitters[i].Trigger(position, layerDepth);
        }
    }

    public void Trigger(LineSegment line, float layerDepth)
    {
        ObjectDisposedException.ThrowIf(IsDisposed, typeof(ParticleBuffer));

        for (int i = 0; i < Emitters.Count; i++)
        {
            Emitters[i].Trigger(line, layerDepth);
        }
    }

    public static ParticleEffect FromFile(string path)
    {
        throw new NotImplementedException();
    }

    public static ParticleEffect FromStream(Stream stream)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (IsDisposed) { return; }

        if (disposing)
        {
            for (int i = 0; i < Emitters.Count; i++)
            {
                Emitters[i].Dispose();
            }
        }

        IsDisposed = true;

    }

    public override string ToString() => Name;
}
