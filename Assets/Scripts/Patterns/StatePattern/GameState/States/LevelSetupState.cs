using UnityEngine;

// TODO: Organize folders based on entities. For example: Enemy -> EnemyControllers, EnemyBehaviours, EnemyStates...

public class LevelSetupState : State
{
    private readonly ISetInteractable[] playerButtons;
    private readonly IFactory<EnemyBase> enemyFactory;
    private readonly IResetHealth enemyHealthReset;

    public LevelSetupState(
        IStateController controller,
        ISetInteractable[] playerButtons,
        IFactory<EnemyBase> enemyFactory,
        IResetHealth enemyHealthReset
        ) : base(controller)
    {
        this.playerButtons = playerButtons;
        this.enemyFactory = enemyFactory;
        this.enemyHealthReset = enemyHealthReset;
    }

    public override void Enter()
    {
        // Implement events or behaviours
        // Suscribe to events

        Debug.Log($"Enter {typeof(LevelSetupState)}");

        foreach (var button in playerButtons)
        {
            button.SetInteractable(false);
        }

        LevelManager.Instance.IncrementLevel();

        // Instantiate new enemy
        // TODO: Get enemy properties after instantiating it
        int[] ids = enemyFactory.GetIDs();
        enemyFactory.Create(ids[Random.Range(0, ids.Length)]);

        // TODO: Here I'm assuming all the enemies have the same properties
        // Reset enemy health
        enemyHealthReset.ResetHealth();

        controller.SwitchState<PlayerTurnState>();
    }

    public override void Exit()
    {
        // Implement events
        // Unsuscribe from events

        Debug.Log($"Exit {typeof(LevelSetupState)}");
    }
}