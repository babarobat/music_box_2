using Infrastructure.States;
using Input;

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