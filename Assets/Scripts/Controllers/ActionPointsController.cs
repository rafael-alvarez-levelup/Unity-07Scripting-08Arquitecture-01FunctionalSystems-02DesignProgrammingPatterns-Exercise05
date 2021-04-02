using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionPointsController : MonoBehaviour, ISubject<ActionPointsArgs>
{
    [SerializeField] private PlayerButtonBehaviour buttonEnd;

    private readonly List<IObserver<ActionPointsArgs>> observers = new List<IObserver<ActionPointsArgs>>();
    private ICurrentAction[] actionControllers;

    private void Awake()
    {
        actionControllers = GetComponentsInChildren<ICurrentAction>();
    }

    public void Add(IObserver<ActionPointsArgs> observer)
    {
        observers.Add(observer);
    }

    public void Remove(IObserver<ActionPointsArgs> observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        // Sum the action points cost of every action.
        int totalActionPoints = actionControllers.Sum(actionController => actionController.CurrentActionActionPoints);

        // TODO : Encapsulate in behaviour, listen to the same event
        if (totalActionPoints > 10 || totalActionPoints == 0)
        {
            buttonEnd.SetInteractable(false);
        }
        else
        {
            buttonEnd.SetInteractable(true);
        }

        for (int i = 0; i < observers.Count; i++)
        {
            IObserver<ActionPointsArgs> observer = observers[i];
            observer.OnNotify(new ActionPointsArgs(totalActionPoints));
        }
    }
}