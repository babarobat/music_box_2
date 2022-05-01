using System;
using Infrastructure.Scenes;
using Infrastructure.Services;
using Infrastructure.Services.Locator;
using Infrastructure.States;
using UnityEngine;

namespace Infrastructure
{
    public class GameLoader : MonoBehaviour, ILoop, ICoroutinesRunner
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            var game = new Game(this, new SceneLoader(this), ServiceLocator.Container);
            game.State.Enter<BootstrapState>();
        }

        public event Action<float> OnTick;

        private void Update()
        {
            OnTick?.Invoke(Time.deltaTime);
        }
    }
}