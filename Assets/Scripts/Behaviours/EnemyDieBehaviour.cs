using System.Collections.Generic;
using UnityEngine;

public class EnemyDieBehaviour : MonoBehaviour, IDie, ISubject
{
    private readonly List<IObserver> observers = new List<IObserver>();

    public void Die()
    {
        Notify();
    }

    public void Add(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Remove(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            IObserver observer = observers[i];
            observer.OnNotify();
        }
    }
}