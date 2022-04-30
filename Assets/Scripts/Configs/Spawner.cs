using System;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "create config/obstacle/spawner", fileName = "spawner")]
    public class Spawner : Obstacle
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