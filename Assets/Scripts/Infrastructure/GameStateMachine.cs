using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private IStateBase _current;
        private Dictionary<Type, IStateBase> _states;

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