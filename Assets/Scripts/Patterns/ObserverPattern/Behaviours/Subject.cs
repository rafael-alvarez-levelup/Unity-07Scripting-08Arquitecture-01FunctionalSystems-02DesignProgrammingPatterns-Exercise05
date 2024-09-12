using System.Collections.Generic;
using UnityEngine;

public abstract class Subject<T> : MonoBehaviour, ISubject<T>
{
    protected List<IObserver<T>> observers = new List<IObserver<T>>();

    public void Add(IObserver<T> observer)
    {
        if (observers.Contains(observer)) return;

        observers.Add(observer);
    }

    public void Remove(IObserver<T> observer)
    {
        if (!observers.Contains(observer)) return;

        observers.Remove(observer);
    }

    public abstract void Notify();
}