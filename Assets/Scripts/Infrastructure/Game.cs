using Infrastructure.Scenes;
using Infrastructure.Services;
using Infrastructure.Services.Locator;
using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        public GameStateMachine State { get; }

        public Game(ILoop loop, SceneLoader sceneLoader, ServiceLocator serviceLocator)
        {
            State = new GameStateMachine(loop, sceneLoader, serviceLocator);
        }
    }
}