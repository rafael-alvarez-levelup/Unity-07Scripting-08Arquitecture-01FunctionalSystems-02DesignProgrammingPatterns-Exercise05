// TODO: Could use update to implement a timer

public class LevelSetupState : State
{
    private readonly ISetInteractable[] playerButtons;

    public LevelSetupState(IStateController controller, ISetInteractable[] playerButtons) : base(controller)
    {
        this.playerButtons = playerButtons;
    }

    public override void Enter()
    {
        // Implement events or behaviours
        // Suscribe to events

        UnityEngine.Debug.Log($"Enter {typeof(LevelSetupState)}");

        foreach (var button in playerButtons)
        {
            button.SetInteractable(false);
        }

        LevelManager.Instance.IncrementLevel();

        // Instantiate new enemy
        UnityEngine.Debug.Log("Instantiate new enemy");

        // Wait for enemy animation
        TimeManager.Instance.WaitForSeconds(1.5f, () => SwitchState());
    }

    public override void Exit()
    {
        // Implement events
        // Unsuscribe from events

        UnityEngine.Debug.Log($"Exit {typeof(LevelSetupState)}");
    }

    private void SwitchState()
    {
        controller.SwitchState<PlayerTurnState>();
    }
}