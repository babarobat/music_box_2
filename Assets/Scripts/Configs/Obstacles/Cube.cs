using System;
using UnityEngine;

namespace Configs.Obstacles
{
    [CreateAssetMenu(menuName = "create config/obstacle/cube", fileName = "cube")]
    public class Cube : Obstacle
    {
        public Internal.Visual Visual;
        
        [Serializable]
        public class Internal
        {
            [Serializable]
            public class Visual
            {
                public string Name;
            }
        }
    }
}