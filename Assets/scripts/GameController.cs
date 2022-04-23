using UnityEngine;

public class GameController : IService
{
    public SoundSystem Sound { get; }
    public GameController()
    {
        Sound = new SoundSystem();
    }

    public void HandleCollide(AudioClip data)
    {
        Sound.HandlePlaySound(data);
    }
}