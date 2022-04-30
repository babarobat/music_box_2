using System;
using System.Collections.Generic;

namespace UserInterface.Windows
{
    public static class WindowAssets
    {
        public static Dictionary<Type, string> Map { get; }

        static WindowAssets()
        {
            Map = new Dictionary<Type, string>
            {
                [typeof(ObstaclesWindow)] = AssetsPaths.ObstaclesWindow
            };
        }
    }
}