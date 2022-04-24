using System;
using UnityEngine;

namespace Sound
{
    public class SoundSystem
    {
        public event Action<AudioClip> OnPlaySound;

        public void HandlePlaySound(AudioClip data)
        {
            OnPlaySound?.Invoke(data);
        }
    }
}