using System;
using System.Collections.Generic;
using Infrastructure.Scenes;
using Infrastructure.Services.Configs;
using Infrastructure.Services.Factories;
using Infrastructure.Services.Locator;
using Infrastructure.Services.Models;

namespace Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IStateBase> _states;
        private IStateBase _current;

        public GameStateMachine(ILoop loop, SceneLoader sceneLoader, ServiceLocator serviceLocator)
        {
            _states = new Dictionary<Type, IStateBase>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, loop, serviceLocator),
                [typeof(InitState)] = new InitState(this,serviceLocator.Get<IModelService>(),
                    serviceLocator.Get<IConfigsService>()),
                [typeof(LoadProjectState)] = new LoadProjectState(sceneLoader, serviceLocator.Get<IFactoriesService>()),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            _current?.Exit();
            var current = (TState)_states[typeof(TState)];
            current.Enter();
            _current = current;
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            _current?.Exit();
            var current = (TState)_states[typeof(TState)];
            current.Enter(payload);
            _current = current;
        }
    }
}