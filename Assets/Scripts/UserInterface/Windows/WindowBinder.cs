﻿namespace UserInterface.Windows
{
    public class WindowBinder 
    {
        public void Bind(ObstaclesWindow obstaclesWindow, ObstaclesWindowData data)
        {
            obstaclesWindow.Bind(new ObstaclesWindowViewModel(data));
        }
    }
}