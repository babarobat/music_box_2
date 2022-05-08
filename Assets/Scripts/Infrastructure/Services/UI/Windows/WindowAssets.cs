using System;
using System.Collections.Generic;
using UserInterface.Windows;

namespace Infrastructure.Services.UI.Windows
{
    public static class WindowAssets
    {
        public static Dictionary<Type, string> Map { get; }

        static WindowAssets()
        {
            Map = new Dictionary<Type, string>
            {
                [typeof(ObstaclesWindow)] = WindowAssetsPaths.ObstaclesWindow
            };
        }
    }
}