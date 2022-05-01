using Infrastructure.Scenes;
using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine State { get; }

        public Game(ILoop loop, SceneLoader sceneLoader)
        {
            State = new GameStateMachine(loop, sceneLoader);
        }
    }
}