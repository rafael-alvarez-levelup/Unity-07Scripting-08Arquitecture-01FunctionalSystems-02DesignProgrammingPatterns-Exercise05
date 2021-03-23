using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour, IHealth, IDamageable, IHealable, ISubject<HealthArgs>
{
    public int CurrentHealth => currentHealth;

    [SerializeField] private int maxHealth = 100;

    private int currentHealth;
    private readonly List<IObserver<HealthArgs>> observers = new List<IObserver<HealthArgs>>();

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        Notify();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Notify();
    }

    public void Add(IObserver<HealthArgs> observer)
    {
        observers.Add(observer);
    }

    public void Remove(IObserver<HealthArgs> observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            IObserver<HealthArgs> observer = observers[i];
            observer.OnNotify(new HealthArgs(currentHealth));
        }
    }
}