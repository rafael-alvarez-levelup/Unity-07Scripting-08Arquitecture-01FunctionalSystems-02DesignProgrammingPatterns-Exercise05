using UnityEngine;

public class HealController : MonoBehaviour, IObserver<HealArgs>
{
    private ISubject<HealArgs> subject;

    private void Awake()
    {
        subject = GetComponent<ISubject<HealArgs>>();
    }

    private void OnEnable()
    {
        subject.Add(this);
    }

    private void OnDisable()
    {
        subject.Remove(this);
    }

    public void OnNotify(HealArgs param)
    {

    }
}