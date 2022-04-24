namespace Models
{
    public interface IModelChangeReceiver
    {
        void ApplyChange(ModelChange.SoundPacks change);
        void ApplyChange(ModelChange.ObstaclesChange change);
    }
}