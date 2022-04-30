using System;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "create config/sound pack", fileName = "sound_pack")]
    public class SoundPack : Config
    {
        public Sprite Icon;
        public Internal.Visual Visual;
        public AudioClip C_1;
        public AudioClip C_Sharp_1;
        public AudioClip D_1;
        public AudioClip D_Sharp_1;
        public AudioClip E_1;
        public AudioClip F_1;
        public AudioClip F_Sharp_1;
        public AudioClip G_1;
        public AudioClip G_Sharp_1;
        public AudioClip A_1;
        public AudioClip A_Sharp_1;
        public AudioClip B_1;
        
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