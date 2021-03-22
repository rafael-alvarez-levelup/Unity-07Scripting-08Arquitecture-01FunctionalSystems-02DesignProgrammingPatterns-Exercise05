using UnityEngine;

public class DefendController : MonoBehaviour, IObserver<DefendArgs>
{
    private ISubject<DefendArgs> subject;

    private void Awake()
    {
        subject = GetComponent<ISubject<DefendArgs>>();
    }

    private void OnEnable()
    {
        subject.Add(this);
    }

    private void OnDisable()
    {
        subject.Remove(this);
    }

    public void OnNotify(DefendArgs param)
    {

    }
}