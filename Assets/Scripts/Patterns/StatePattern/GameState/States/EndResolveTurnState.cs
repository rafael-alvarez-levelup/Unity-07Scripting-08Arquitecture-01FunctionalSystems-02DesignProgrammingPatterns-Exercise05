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
            // TODO: Wait for enemy death animation. Redundant code -> DRY
            // Switch to LevelSetupState when is notified about enemy death event
            TimeManager.Instance.WaitForSeconds(1.5f, () => SwitchToLevelSetupState());
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

    private void SwitchToLevelSetupState()
    {
        controller.SwitchState<LevelSetupState>();
    }
}