using System;
using System.Collections.Generic;
using UnityEngine;
using UserInterface.Windows;

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
                public ObstaclesWindow ObstaclesWindow;
                
                public List<IWindow> All => new List<IWindow>
                {
                   ObstaclesWindow,
                };
            }
        }
    }
}

