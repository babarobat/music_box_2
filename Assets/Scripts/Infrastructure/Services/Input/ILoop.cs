using System;

namespace Infrastructure.Services.Input
{
    public interface ILoop
    {
        event Action<float> OnTick;
    }
}