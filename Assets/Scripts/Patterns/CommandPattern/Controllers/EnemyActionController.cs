using UnityEngine;

public class EnemyActionController : MonoBehaviour, IActionController
{
    [SerializeField] private Sprite defaultIcon;

    private ActionBase[] actions;
    private ISetIcon setIconBehaviour;

    private void Awake()
    {
        setIconBehaviour = GetComponentInChildren<ISetIcon>();
        actions = GetComponents<ActionBase>();
    }

    public ICommand GetCurrentCommand()
    {
        ActionBase randomAction = actions[Random.Range(0, actions.Length)];
        setIconBehaviour.SetIcon(randomAction.Icon);
        return randomAction.Command;
    }

    public void ResetAction()
    {
        setIconBehaviour.SetIcon(defaultIcon);
    }
}