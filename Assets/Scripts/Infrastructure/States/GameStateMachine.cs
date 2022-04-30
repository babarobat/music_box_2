using System;
using System.Collections.Generic;
using Infrastructure.Services.Scenes;

namespace Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IStateBase> _states;
        private IStateBase _current;

        public GameStateMachine(ILoop loop, ICoroutinesRunner coroutines, SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IStateBase>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, loop, coroutines),
                [typeof(LoadProjectState)] = new LoadProjectState(sceneLoader),
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