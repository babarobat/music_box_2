using System;
using System.Linq;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Locator;
using Infrastructure.Services.UI;
using Infrastructure.Services.UI.Windows;
using Sound;
using UnityEngine;
using UserInterface.Windows;

namespace Infrastructure
{
    public class GameController : IService
    {
        private IConfigsService _configs;
        private IUIService _ui;
        public SoundSystem Sound { get; private set; }

        public void HandleCollide(AudioClip data)
        {
            Sound.HandlePlaySound(data);
        }

        public void OpenObstaclesWindow()
        {
            _ui.At<WindowsManager>().Open<ObstaclesWindow, ObstaclesWindowData>(new ObstaclesWindowData
            {
                Title = "Choose obstacle",
                Obstacles = _configs.Obstacles.ToList(),
            });
        }

        public void Connect(IConfigsService configs, IUIService ui)
        {
            _configs = configs;
            _ui = ui;
            
            Sound = new SoundSystem();
        }
    }
}