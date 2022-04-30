namespace Infrastructure
{
    public interface IPayloadState<in TPayload> : IStateBase
    {
        public void Enter(TPayload payload);
    }
}