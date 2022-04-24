namespace Models
{
    public class Model : IModelChangeReceiver
    {
        public User User = new User();
    
        public void ApplyChange(ModelChange.SoundPacks change)
        {
            User.Update(change);
        }
        public void ApplyChange(ModelChange.ObstaclesChange change)
        {
            User.Update(change);
        }
    }
}