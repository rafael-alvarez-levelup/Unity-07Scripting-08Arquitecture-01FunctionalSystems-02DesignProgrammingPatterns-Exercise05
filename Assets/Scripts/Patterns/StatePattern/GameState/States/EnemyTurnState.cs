using UnityEngine;

public class EnemyTurnState : State
{
    private readonly ISelectActions actionSelector;

    public EnemyTurnState(IStateController controller,
        ISelectActions actionSelector
        ) : base(controller)
    {
        this.actionSelector = actionSelector;
    }

    public override void Enter()
    {
        Debug.Log($"Enter {typeof(EnemyTurnState)}");

        actionSelector.SelectActions();

        controller.SwitchState<EnemyResolveTurnState>();
    }

    public override void Exit()
    {
        Debug.Log($"Exit {typeof(EnemyTurnState)}");
    }
}