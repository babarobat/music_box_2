using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace Models
{
    public abstract class ModelChange
    {
        public abstract void Apply(IModelChangeReceiver receiver);

        public class ProjectsChange : ModelChange
        {
            public class ProjectDTO
            {
                public List<(Obstacle Data, Vector3 Position, Vector3 Rotation)> Obstacles;
                public string Name;
            }
            
            public IEnumerable<ProjectDTO> Projects;
            public override void Apply(IModelChangeReceiver receiver) => receiver.ApplyChange(this);
        }
    }


}