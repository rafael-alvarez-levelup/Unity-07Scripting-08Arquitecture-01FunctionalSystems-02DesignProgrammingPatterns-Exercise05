using UnityEngine;

public class DefendBehaviour : Subject<DefendArgs>, IDefend
{
    [SerializeField] private float damageReceivedMultiplier;

    public void Defend()
    {
        Notify();
    }

    public override void Notify()
    {
        DefendArgs defendArgs = new DefendArgs(damageReceivedMultiplier);

        for (int i = 0; i < observers.Count; i++)
        {
            IObserver<DefendArgs> observer = observers[i];
            observer.OnNotify(defendArgs);
        }
    }
}