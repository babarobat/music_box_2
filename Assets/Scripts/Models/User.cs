using System.Collections.Generic;
using System.Linq;
using Configs;
using UnityEngine;

namespace Models
{
    public class User
    {
        public IEnumerable<ProjectModel> Projects => _projects;
        private List<ProjectModel> _projects = new List<ProjectModel>();

        public void Update(ModelChange.ProjectsChange change)
        {
            _projects = change.Projects.Select(CreateModel).ToList();
        }

        private ProjectModel CreateModel(ModelChange.ProjectsChange.ProjectDTO dto)
        {
            return new ProjectModel
            {
                Name = dto.Name,
                Obstacles = dto.Obstacles.Select(CreateModel).ToList(),
            };
        }

        private ObstacleMapModel CreateModel((Obstacle Data, Vector3 Position, Vector3 Rotation) arg)
        {
            return new ObstacleMapModel
            {
                Data = arg.Data,
                Position = arg.Position,
                Rotation = arg.Rotation,
            };
        }
    }

    public class ProjectModel
    {
        public string Name;
        public List<ObstacleMapModel> Obstacles = new List<ObstacleMapModel>();
    }

    public class ObstacleMapModel
    {
        public Obstacle Data;
        public Vector3 Position;
        public Vector3 Rotation;
    }
}