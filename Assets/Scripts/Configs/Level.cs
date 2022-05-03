using System;
using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "create config/level", fileName = "level")]
    public class Level : Config
    {
        [Serializable]
        public class Internal
        {
            [Serializable]
            public class Visual
            {
                public string Name;
            }
            
            [Serializable]
            public class Obstacle
            {
                public Vector3 Position;
                public Vector3 Rotation;
                public Obstacles.Obstacle Data;
            }
        }

        public Internal.Visual Visual;
        public List<Internal.Obstacle> Obstacles = new List<Internal.Obstacle>();
    }
}