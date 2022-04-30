using System;

namespace Infrastructure
{
    public interface ILoop
    {
        event Action<float> OnTick;
    }
}