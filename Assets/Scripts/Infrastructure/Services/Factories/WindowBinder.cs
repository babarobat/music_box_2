using System;
using Infrastructure.Services.UI.Windows;
using UserInterface.Windows;

namespace Infrastructure.Services.Factories
{
    public class WindowBinder
    {
        public void Bind<TWindow, TWindowData>(TWindow window, TWindowData data)
            where TWindow : WindowBase<TWindow, TWindowData>
        {
            switch (window)
            {
                case ObstaclesWindow obstaclesWindow: Bind(obstaclesWindow, data as ObstaclesWindowData); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void Bind(ObstaclesWindow obstaclesWindow, ObstaclesWindowData data)
        {
            obstaclesWindow.Bind(new ObstaclesWindowViewModel(data));
        }
    }
}