// TODO: Do an action and reset it?
// Break in two (player and enemy)
// Old

public class TurnResolutionState : State
{
    private readonly ICommandProcessor playerProcessor;
    private readonly ICommandProcessor enemyProcessor;
    private readonly IResetActions playerReset;
    private readonly IResetActions enemyReset;

    public TurnResolutionState(IStateController controller, ICommandProcessor playerProcessor,
        ICommandProcessor enemyProcessor, IResetActions playerReset,
        IResetActions enemyReset) : base(controller)
    {
        this.playerProcessor = playerProcessor;
        this.enemyProcessor = enemyProcessor;
        this.playerReset = playerReset;
        this.enemyReset = enemyReset;
    }

    public override void Enter()
    {
        // Start command processor coroutine
        // When finished, switch to level end state

        UnityEngine.Debug.Log($"Enter {typeof(TurnResolutionState)}");

        while (playerProcessor.GetCommandQueueCount() != 0 || enemyProcessor.GetCommandQueueCount() != 0)
        {
            enemyProcessor.RunNext();
            playerProcessor.RunNext();
        }

        controller.SwitchState<LevelEndState>();
    }

    public override void Exit()
    {
        enemyReset.ResetActions();
        playerReset.ResetActions();

        UnityEngine.Debug.Log($"Exit {typeof(TurnResolutionState)}");
    }
}