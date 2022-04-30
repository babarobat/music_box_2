namespace Infrastructure
{
    public interface IState : IStateBase
    {
        public void Enter();
    }
}