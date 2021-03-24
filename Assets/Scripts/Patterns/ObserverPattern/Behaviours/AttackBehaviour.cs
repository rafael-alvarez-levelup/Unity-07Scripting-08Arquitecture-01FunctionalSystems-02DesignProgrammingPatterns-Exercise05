using UnityEngine;

// TODO: Serialize Animator and SetTrigger("Attack")

public class AttackBehaviour : Subject<AttackArgs>, IAttack
{
    [SerializeField] private int damage;

    public void Attack()
    {
        Notify();
    }

    public override void Notify()
    {
        // It won't change, cache
        AttackArgs attackArgs = new AttackArgs(damage);

        for (int i = 0; i < observers.Count; i++)
        {
            IObserver<AttackArgs> observer = observers[i];
            observer.OnNotify(attackArgs);
        }
    }
}