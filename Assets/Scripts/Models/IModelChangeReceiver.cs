namespace Models
{
    public interface IModelChangeReceiver
    {
        void ApplyChange(ModelChange.ProjectsChange projects);
    }
}