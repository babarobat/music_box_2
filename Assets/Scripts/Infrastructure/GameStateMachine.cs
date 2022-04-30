using System;
using System.Collections.Generic;
using Input;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private Dictionary<Type, IStateBase> _states;
        private IStateBase _current;

        public GameStateMachine(ILoop loop)
        {
            _states = new Dictionary<Type, IStateBase>
            {
                [typeof(BootstrapState)] = new BootstrapState(loop),
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