public class Model : IModelChangeReceiver
{
    public User User = new User();
    
    public void ApplyChange(ModelChange.SoundPacks soundPacks)
    {
        User.Update(soundPacks);
    }
}