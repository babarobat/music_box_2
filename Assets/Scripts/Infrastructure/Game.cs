using Infrastructure.Services.Scenes;
using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine State { get; }

        public Game(ILoop loop, ICoroutinesRunner coroutines, SceneLoader sceneLoader)
        {
            State = new GameStateMachine(loop, coroutines, sceneLoader);
        }
    }
}