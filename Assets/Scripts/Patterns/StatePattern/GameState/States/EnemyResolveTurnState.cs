public class EnemyResolveTurnState : State
{
    private readonly ICommandProcessor enemyProcessor;
    private readonly IHealth enemyHealth;

    public EnemyResolveTurnState(
        IStateController controller,
        ICommandProcessor enemyProcessor,
        IHealth enemyHealth
        ) : base(controller)
    {
        this.enemyProcessor = enemyProcessor;
        this.enemyHealth = enemyHealth;
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log($"Enter {typeof(EnemyResolveTurnState)}");

        if (enemyHealth.CurrentHealth <= 0)
        {
            controller.SwitchState<EndResolveTurnState>();
        }
        else
        {
            enemyProcessor.RunNext();

            TimeManager.Instance.WaitForSeconds(0.6f, () => ResolveTurn());
        }
    }

    public override void Exit()
    {
        UnityEngine.Debug.Log($"Exit {typeof(EnemyResolveTurnState)}");
    }

    private void ResolveTurn()
    {
        controller.SwitchState<PlayerResolveTurnState>();
    }
}