using System.Linq;
using UnityEngine;

public class ActionSelectorController : MonoBehaviour, ISelectActions, IResetActions
{
    private IActionController[] myActionControllers;
    private ICommandProcessor myCommandProcessor;

    private void Awake()
    {
        myActionControllers = GetComponentsInChildren<IActionController>();
        myCommandProcessor = GetComponent<ICommandProcessor>();
    }

    public void SelectActions()
    {
        foreach (ICommand command in myActionControllers.Select(action => action.GetCurrentCommand()))
        {
            myCommandProcessor.Add(command);
        }
    }

    public void ResetActions()
    {
        foreach (var actionController in myActionControllers)
        {
            actionController.ResetAction();
        }
    }
}