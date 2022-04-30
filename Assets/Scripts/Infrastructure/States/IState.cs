namespace Infrastructure.States
{
    public interface IState : IStateBase
    {
        public void Enter();
    }
}