public class EndResolveTurnState : State
{
    private readonly IResetActions playerActionsReset;
    private readonly IResetActions enemyActionsReset;
    private readonly IHealth enemyHealth;

    public EndResolveTurnState(
        IStateController controller,
        IResetActions playerActionsReset,
        IResetActions enemyActionsReset,
        IHealth enemyHealth
        ) : base(controller)
    {
        this.playerActionsReset = playerActionsReset;
        this.enemyActionsReset = enemyActionsReset;
        this.enemyHealth = enemyHealth;
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log($"Enter {typeof(EndResolveTurnState)}");

        enemyActionsReset.ResetActions();
        playerActionsReset.ResetActions();

        if (enemyHealth.CurrentHealth <= 0)
        {
            controller.SwitchState<LevelSetupState>();
        }
        else
        {
            controller.SwitchState<PlayerTurnState>();
        }        
    }

    public override void Exit()
    {
        UnityEngine.Debug.Log($"Exit {typeof(EndResolveTurnState)}");
    }
}