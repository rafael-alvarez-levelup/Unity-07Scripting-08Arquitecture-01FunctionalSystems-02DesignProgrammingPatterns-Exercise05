// TODO: Old

public class LevelEndState : State
{
    private readonly IHealth enemyHealth;

    public LevelEndState(GameStateController controller, IHealth enemyHealth) : base(controller)
    {
        this.enemyHealth = enemyHealth;
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log($"Enter {typeof(LevelEndState)}");

        // If enemy is alive (!null), switch to player turn state
        // Else, switch to level setup state

        if (enemyHealth.CurrentHealth <= 0)
        {
            controller.SwitchState<LevelSetupState>();
        }
        else
        {
            controller.SwitchState<PlayerTurnState>();
        }

        // Handle player death
    }

    public override void Exit()
    {
        UnityEngine.Debug.Log($"Exit {typeof(LevelEndState)}");
    }
}