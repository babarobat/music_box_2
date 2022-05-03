using Newtonsoft.Json;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User : IModel
    {
        [JsonProperty("projects")] public Projects Projects { get; set; } = new Projects();

        public void Apply(IModelVisitor visitor) => visitor.Apply(this);
    }
}