using Input;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine State { get; }

        public Game(ILoop loop)
        {
            State = new GameStateMachine(loop);
        }
    }
}