using System.Collections.Generic;
using Configs;
using Extensions;
using Newtonsoft.Json;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ProjectModel : IModel
    {
        [JsonProperty("name")] public string Name;
        [JsonProperty("map_obstacles")] public List<ObstacleMapModel> Obstacles = new();

        public void AddObstacles(List<Level.Internal.Obstacle> obstacles)
        {
            foreach (var obstacle in obstacles)
            {
                AddObstacle(obstacle);
            }
        }

        public void AddObstacle(Level.Internal.Obstacle obstacle)
        {
            var model = new ObstacleMapModel
            {
                ObstacleName = obstacle.Data.Name,
                ObstacleType = obstacle.Data.GetObstacleType(),
                PositionData = obstacle.Position.ToVector3Data(),
                RotationData = obstacle.Rotation.ToVector3Data(),
            };

            Obstacles.Add(model);
        }

        public void Apply(IModelVisitor visitor) => visitor.Apply(this);
    }
}