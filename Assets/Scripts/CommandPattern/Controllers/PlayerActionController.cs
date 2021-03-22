using UnityEngine;
using UnityEngine.UI;

public class PlayerActionController : MonoBehaviour, IActionController, ICurrentAction
{
    // Get current action action points cost or 0 if it is the default action.
    public int CurrentActionActionPoints => currentAction ? currentAction.ActionPoints : 0;

    [SerializeField] private Sprite defaultIcon;

    private ActionBase[] actions;
    private ActionBase currentAction;
    private ISetIcon setIconBehaviour;
    private int index = 0;
    private Button button;
    private ISubject<ActionPointsArgs> actionPointsController;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => ChangeAction());

        setIconBehaviour = GetComponentInChildren<ISetIcon>();
        actions = GetComponents<ActionBase>();

        actionPointsController = GetComponentInParent<ISubject<ActionPointsArgs>>();
    }

    public void ChangeAction()
    {
        index = (index + 1) % actions.Length;
        currentAction = actions[index];
        setIconBehaviour.SetIcon(currentAction.Icon);

        actionPointsController.Notify();
    }

    public ICommand GetCurrentCommand()
    {
        return currentAction.Command;
    }

    public void ResetAction()
    {
        currentAction = null;
        index = 0;
        setIconBehaviour.SetIcon(defaultIcon);

        actionPointsController.Notify();
    }
}