using Infrastructure.Services.Input;
using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine State { get; }

        public Game(ILoop loop, ICoroutinesRunner coroutines)
        {
            State = new GameStateMachine(loop, coroutines);
        }
    }
}