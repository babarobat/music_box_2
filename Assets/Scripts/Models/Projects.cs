using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Projects : IModel
    {
        [JsonProperty("projects")] public List<ProjectModel> All { get; private set; } = new List<ProjectModel>();
        public bool IsEmpty => !All.Any();

        public ProjectModel Create(string name)
        {
            var model = new ProjectModel
            {
                Name = name,
            };
            
            All.Add(model);
            return model;
        }

        public void Apply(IModelVisitor visitor) => visitor.Apply(this);
    }
}