using System;
using UnityEngine;

public class GameController : IService
{
    public GameController()
    {
        Sound = new SoundSystem();
    }

    public void HandleCollide(AudioClip data)
    {
        Sound.HandlePlaySound(data);
    }

    public SoundSystem Sound { get; }
}

public class SoundSystem
{
    public event Action<AudioClip> OnPlaySound;

    public void HandlePlaySound(AudioClip data)
    {
        OnPlaySound?.Invoke(data);
    }
}