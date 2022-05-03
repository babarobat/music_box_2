namespace Models
{
    public interface IModelVisitor
    {
        void Apply(Model model);
        void Apply(ProjectModel model);
        void Apply(Projects model);
        void Apply(User model);
        void Apply(ObstacleMapModel model);
    }
}