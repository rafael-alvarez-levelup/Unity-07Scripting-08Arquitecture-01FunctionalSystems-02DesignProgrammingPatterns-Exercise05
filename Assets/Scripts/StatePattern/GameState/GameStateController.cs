using UnityEngine;

// TODO: Check improves, remove old

public class GameStateController : StateController
{
    [SerializeField] private ActionSelectorController playerActionSelector;
    [SerializeField] private ButtonEndController buttonEndController;
    [SerializeField] private PlayerButtonBehaviour[] playerButtons;
    [SerializeField] private ActionSelectorController enemyActionSelector;
    [SerializeField] private CommandProcessor playerProcessor;
    [SerializeField] private CommandProcessor enemyProcessor;
    [SerializeField] private HealthBehaviour playerHealth;
    [SerializeField] private HealthBehaviour enemyHealth;

    private IState levelSetupState;
    private IState playerTurnState;
    private IState enemyTurnState;

    // Old
    private IState turnResolutionState;
    private IState levelEndState;

    // Improve
    private IState enemyResolveTurnState;
    private IState playerResolveTurnState;
    private IState endResolveTurnState;

    private void Awake()
    {
        levelSetupState = new LevelSetupState(this, playerButtons);
        playerTurnState = new PlayerTurnState(this, playerActionSelector, buttonEndController, playerButtons);
        enemyTurnState = new EnemyTurnState(this, enemyActionSelector);

        // Old
        turnResolutionState = new TurnResolutionState(this, playerProcessor, enemyProcessor,
            playerActionSelector, enemyActionSelector);
        levelEndState = new LevelEndState(this, enemyHealth);

        // Improve
        enemyResolveTurnState = new EnemyResolveTurnState(this, enemyProcessor, enemyHealth);
        playerResolveTurnState = new PlayerResolveTurnState(this, playerProcessor, playerHealth);
        endResolveTurnState = new EndResolveTurnState(this, playerActionSelector, enemyActionSelector, enemyHealth);

        states.Add(typeof(LevelSetupState), levelSetupState);
        states.Add(typeof(PlayerTurnState), playerTurnState);
        states.Add(typeof(EnemyTurnState), enemyTurnState);

        // Old
        states.Add(typeof(TurnResolutionState), turnResolutionState);
        states.Add(typeof(LevelEndState), levelEndState);

        // Improve
        states.Add(typeof(EnemyResolveTurnState), enemyResolveTurnState);
        states.Add(typeof(PlayerResolveTurnState), playerResolveTurnState);
        states.Add(typeof(EndResolveTurnState), endResolveTurnState);
    }

    private void Start()
    {
        // Initial state
        SwitchState<LevelSetupState>();
    }
}