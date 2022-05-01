namespace Models
{
    public class User
    {
        public readonly Projects Projects;

        public User()
        {
            Projects = new Projects();
        }

        public void Update(ModelChange.ProjectsChange change)
        {
            Projects.Update(change);
        }
    }
}