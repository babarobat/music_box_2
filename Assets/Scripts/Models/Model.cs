namespace Models
{
    public class Model : IModelChangeReceiver
    {
        public readonly User User = new User();
        public void ApplyChange(ModelChange.ProjectsChange projects)
        {
            User.Update(projects);
        }
    }
}