using Newtonsoft.Json;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Model : IModel
    {
        [JsonProperty("user")] public User User { get; set; } = new();
        
        public void Apply(IModelVisitor visitor) => visitor.Apply(this);

    }
}