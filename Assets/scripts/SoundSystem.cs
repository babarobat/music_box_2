using System;
using UnityEngine;

public class SoundSystem
{
    public event Action<AudioClip> OnPlaySound;

    public void HandlePlaySound(AudioClip data)
    {
        OnPlaySound?.Invoke(data);
    }
}