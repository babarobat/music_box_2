namespace Models
{
    public class Model : IModel
    {
        public readonly User User = new User();
        public void ApplyChange(ModelChange.ProjectsChange projects)
        {
            User.Update(projects);
        }
    }
}