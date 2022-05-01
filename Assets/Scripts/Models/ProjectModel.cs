using System.Collections.Generic;

namespace Models
{
    public class ProjectModel
    {
        public string Name;
        public List<ObstacleMapModel> Obstacles = new List<ObstacleMapModel>();
    }
}