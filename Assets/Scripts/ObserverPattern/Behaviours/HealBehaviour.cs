using UnityEngine;

public class HealBehaviour : Subject<HealArgs>, IHeal
{
    [SerializeField] private int healing;

    public void Heal()
    {
        Notify();
    }

    public override void Notify()
    {
        HealArgs healArgs = new HealArgs(healing);

        for (int i = 0; i < observers.Count; i++)
        {
            IObserver<HealArgs> observer = observers[i];
            observer.OnNotify(healArgs);
        }
    }
}