using System.Collections.Generic;
using System.Linq;
using Configs;
using UnityEngine;

namespace Models
{
    public class Projects
    {
        public IEnumerable<ProjectModel> All => _projects;
        public bool IsEmpty => !_projects.Any();

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
}