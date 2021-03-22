public class PlayerTurnState : State, IObserver
{
    private readonly ISelectActions actionSelector;
    private readonly ISubject playerTurnEnder;
    private readonly ISetInteractable[] playerButtons;

    public PlayerTurnState(IStateController controller, ISelectActions actionSelector,
        ISubject playerTurnEnder, ISetInteractable[] playerButtons) : base(controller)
    {
        this.actionSelector = actionSelector;
        this.playerTurnEnder = playerTurnEnder;
        this.playerButtons = playerButtons;
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log($"Enter {typeof(PlayerTurnState)}");

        playerTurnEnder.Add(this);

        foreach (var button in playerButtons)
        {
            button.SetInteractable(true);
        }
    }

    public override void Exit()
    {
        // This change the iterator in the observers list while it is still iterating => use for loop
        playerTurnEnder.Remove(this);

        foreach (var button in playerButtons)
        {
            button.SetInteractable(false);
        }

        UnityEngine.Debug.Log($"Exit {typeof(PlayerTurnState)}");
    }

    public void OnNotify()
    {
        actionSelector.SelectActions();

        controller.SwitchState<EnemyTurnState>();
    }
}