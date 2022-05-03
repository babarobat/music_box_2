namespace Models
{
    public interface IModel
    {
        void Apply(IModelVisitor visitor);
    }
}