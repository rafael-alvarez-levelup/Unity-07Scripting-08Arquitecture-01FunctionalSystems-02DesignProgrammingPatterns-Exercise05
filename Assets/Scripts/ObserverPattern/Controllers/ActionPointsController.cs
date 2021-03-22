using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionPointsController : MonoBehaviour, ISubject<ActionPointsArgs>
{
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

        foreach (var observer in observers)
        {
            observer.OnNotify(new ActionPointsArgs(totalActionPoints));
        }
    }
}