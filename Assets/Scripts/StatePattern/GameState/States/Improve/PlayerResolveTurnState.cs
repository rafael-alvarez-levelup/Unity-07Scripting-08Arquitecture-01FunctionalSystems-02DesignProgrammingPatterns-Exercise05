public class PlayerResolveTurnState : State
{
    private readonly ICommandProcessor playerProcessor;
    private readonly IHealth playerHealth;

    public PlayerResolveTurnState(
        IStateController controller,
        ICommandProcessor playerProcessor,
        IHealth playerHealth
        ) : base(controller)
    {
        this.playerProcessor = playerProcessor;
        this.playerHealth = playerHealth;
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log($"Enter {typeof(PlayerResolveTurnState)}");

        if (playerHealth.CurrentHealth <= 0)
        {
            // TODO: Game over
        }
        else
        {
            playerProcessor.RunNext();

            TimeManager.Instance.WaitForSeconds(1.5f, () => ResolveTurn());
        }        
    }

    public override void Exit()
    {
        UnityEngine.Debug.Log($"Exit {typeof(PlayerResolveTurnState)}");
    }

    private void ResolveTurn()
    {
        if (playerProcessor.GetCommandQueueCount() == 0)
        {
            controller.SwitchState<EndResolveTurnState>();
        }
        else
        {
            controller.SwitchState<EnemyResolveTurnState>();
        }
    }
}