using UnityEngine;

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
    [SerializeField] private EnemyFactory enemyFactory;

    private IState levelSetupState;
    private IState playerTurnState;
    private IState enemyTurnState;
    private IState enemyResolveTurnState;
    private IState playerResolveTurnState;
    private IState endResolveTurnState;

    private void Awake()
    {
        levelSetupState = new LevelSetupState(this, playerButtons, enemyFactory, enemyHealth);
        playerTurnState = new PlayerTurnState(this, playerActionSelector, buttonEndController, playerButtons);
        enemyTurnState = new EnemyTurnState(this, enemyActionSelector);
        enemyResolveTurnState = new EnemyResolveTurnState(this, enemyProcessor, enemyHealth);
        playerResolveTurnState = new PlayerResolveTurnState(this, playerProcessor, playerHealth);
        endResolveTurnState = new EndResolveTurnState(this, playerActionSelector, enemyActionSelector, enemyHealth);

        states.Add(typeof(LevelSetupState), levelSetupState);
        states.Add(typeof(PlayerTurnState), playerTurnState);
        states.Add(typeof(EnemyTurnState), enemyTurnState);
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