using System;
using System.Linq;
using Infrastructure.Services;
using Models;
using Sound;
using UnityEngine;
using UserInterface.Windows;

namespace Infrastructure
{
    [Obsolete("should be deleted")]
    public class GameController : IService
    {
        public SoundSystem Sound { get; }
        public Model Model { get; }
    
        public GameController(Model model)
        {
            Model = model;
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
                Obstacles = Model.User.Obstacles.ToList(),
            });
        }
    }
}