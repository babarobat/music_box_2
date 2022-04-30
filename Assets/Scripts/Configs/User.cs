using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "create config/default user", fileName = "user")]
    public class User : Config
    {
        public Level DefaultLevel;
    }
}