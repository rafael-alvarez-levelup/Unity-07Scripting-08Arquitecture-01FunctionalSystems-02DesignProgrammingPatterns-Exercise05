using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEndController : MonoBehaviour, ISubject
{
    private Button button;

    private readonly List<IObserver> observers = new List<IObserver>();

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnClick());
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
        // Throws an exception using a foreach, because the iterator get changed while iterating along the list
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].OnNotify();
        }
    }

    private void OnClick()
    {
        Notify();
    }
}