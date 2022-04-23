using UnityEngine;

public class GameController : IService
{
    public SoundSystem Sound { get; }
    public Model Model { get; }
    public GameController(Model model)
    {
        Model = model;
        
        Sound = new SoundSystem();
    }

    public void HandleCollide(AudioClip data)
    {
        Sound.HandlePlaySound(data);
    }
}