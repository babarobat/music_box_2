using System;
using UnityEngine;

namespace Configs.Obstacles
{
    [CreateAssetMenu(menuName = "create config/obstacle/cylinder", fileName = "cylinder")]
    public class Cylinder : Obstacle
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