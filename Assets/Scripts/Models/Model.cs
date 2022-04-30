namespace Models
{
    public class Model : IModelChangeReceiver
    {
        public User User = new User();
        public void ApplyChange(ModelChange.ProjectsChange projects)
        {
            User.Update(projects);
        }
    }
}