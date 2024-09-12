using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>, ISubject<LevelArgs>, IIncrementLevel
{
    private int currentLevel;

    private readonly List<IObserver<LevelArgs>> observers = new List<IObserver<LevelArgs>>();

    private void Start()
    {
        Notify();
    }

    public void IncrementLevel()
    {
        currentLevel++;

        Notify();
    }

    public void Add(IObserver<LevelArgs> observer)
    {
        observers.Add(observer);
    }

    public void Remove(IObserver<LevelArgs> observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            IObserver<LevelArgs> observer = observers[i];
            observer.OnNotify(new LevelArgs(currentLevel));
        }
    }
}