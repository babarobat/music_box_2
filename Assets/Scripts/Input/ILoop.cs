using System;

namespace Input
{
    public interface ILoop
    {
        event Action<float> OnTick;
    }
}