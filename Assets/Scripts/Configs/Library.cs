using System;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "create library", fileName = "library")]
    public class Library : ScriptableObject
    {
        public Internal.Windows Windows;

        [Serializable]
        public class Internal
        {
            [Serializable]
            public class Windows
            {
                

            }
        }
    }
}

