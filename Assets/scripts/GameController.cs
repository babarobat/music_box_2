using System;

public class GameController : IService
{
    public GameController()
    {
        Sound = new SoundSystem();
    }

    public void HandleCollide(SoundData data)
    {
        Sound.HandlePlaySound(data);
    }

    public SoundSystem Sound { get; }
}

public class SoundSystem
{
    public event Action<SoundData> OnPlaySound;

    public void HandlePlaySound(SoundData data)
    {
        OnPlaySound?.Invoke(data);
    }
}