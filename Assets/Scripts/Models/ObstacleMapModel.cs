using Newtonsoft.Json;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ObstacleMapModel : IModel
    {
        [JsonProperty("data_name")] public string ObstacleName;
        [JsonProperty("data_type")] public ObstacleType ObstacleType;
        [JsonProperty("position")] public Vector3Data PositionData;
        [JsonProperty("rotation")] public Vector3Data RotationData;
        
        public void Apply(IModelVisitor visitor) => visitor.Apply(this);
    }
}