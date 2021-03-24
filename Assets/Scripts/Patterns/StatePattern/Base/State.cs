public abstract class State : IState
{
    protected readonly IStateController controller;

    public State(IStateController controller)
    {
        this.controller = controller;
    }

    public abstract void Enter();

    public abstract void Exit();
}