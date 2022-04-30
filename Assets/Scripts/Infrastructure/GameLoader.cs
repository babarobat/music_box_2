using System;
using Configs;
using Infrastructure.Services.Input;
using Infrastructure.States;
using UnityEngine;

namespace Infrastructure
{
    public class GameLoader : MonoBehaviour, ILoop, ICoroutinesRunner
    {
        [SerializeField] private Library _library;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            var game = new Game(this, this);
            game.State.Enter<BootstrapState, Library>(_library);
        }

        public event Action<float> OnTick;

        private void Update()
        {
            OnTick?.Invoke(Time.deltaTime);
        }
    }
}