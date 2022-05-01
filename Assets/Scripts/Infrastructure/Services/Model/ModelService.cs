namespace Infrastructure.Services.Model
{
    public class ModelService : IModelService
    {
        public Models.Model Model { get; }

        public ModelService(Models.Model model)
        {
            Model = model;
        }

        public void Init()
        {
            //load progress
        }
    }
}