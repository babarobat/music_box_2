using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "create library", fileName = "lybrary")]
public class Lybrary : ScriptableObject
{
    public List<SoundPack> Packs;

    public List<IWindow> AllWindows => new List<IWindow>
    {
        Windows.ObstaclesWindow,
    };

    public Internal.Windows Windows;

    [Serializable]
    public class Internal
    {
        [Serializable]
        public class Windows
        {
            public ObstaclesWindow ObstaclesWindow;
        }
    }
}

