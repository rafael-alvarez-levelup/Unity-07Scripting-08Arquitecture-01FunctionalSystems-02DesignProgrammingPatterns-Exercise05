using UnityEngine;

public class EnemyTurnState : State
{
    private readonly ISelectActions actionSelector;

    public EnemyTurnState(IStateController controller, ISelectActions actionSelector) : base(controller)
    {
        this.actionSelector = actionSelector;
    }

    public override void Enter()
    {
        // Start enemy selection coroutine
        // Needs a monobehaviour for the coroutine
        // When finished, switch to turn resolution state

        Debug.Log($"Enter {typeof(EnemyTurnState)}");

        actionSelector.SelectActions();

        controller.SwitchState<EnemyResolveTurnState>();
    }

    public override void Exit()
    {
        Debug.Log($"Exit {typeof(EnemyTurnState)}");
    }
}