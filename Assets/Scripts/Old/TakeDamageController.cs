using UnityEngine;

// TODO: Moves this logic to the state

public class TakeDamageController : MonoBehaviour, IObserver<AttackArgs>
{
    [SerializeField] private GameObject target;

    private ISubject<AttackArgs> subject;

    private void Awake()
    {
        subject = target.GetComponent<ISubject<AttackArgs>>();
    }

    private void OnEnable()
    {
        subject.Add(this);
    }

    private void OnDisable()
    {
        subject.Remove(this);
    }

    public void OnNotify(AttackArgs param)
    {

    }
}