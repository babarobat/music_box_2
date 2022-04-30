using System;
using Infrastructure.Services.Scenes;
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
            var game = new Game(this, this, new SceneLoader(this));
            game.State.Enter<BootstrapState>();
        }

        public event Action<float> OnTick;

        private void Update()
        {
            OnTick?.Invoke(Time.deltaTime);
        }
    }
}