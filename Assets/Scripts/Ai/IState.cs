namespace DefaultNamespace.Ai
{
    public interface IState
    {
        void Tick();
        IState GetNextState();
    }
}