using System;
using System.Linq;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Locator;
using Sound;
using UnityEngine;
using UserInterface.Windows;

namespace Infrastructure
{
    [Obsolete("should be deleted")]
    public class GameController : IService
    {
        private readonly IConfigsService _configs;
        public SoundSystem Sound { get; }
        
    
        public GameController(IConfigsService configs)
        {
            _configs = configs;
            Sound = new SoundSystem();
        }

        public void HandleCollide(AudioClip data)
        {
            Sound.HandlePlaySound(data);
        }
    
        public void OpenObstaclesWindow()
        {
            ObstaclesWindow.Open(new ObstaclesWindowData
            {
                Title = "Choose obstacle",
                Obstacles = _configs.Obstacles.ToList(),
            });
        }
    }
}