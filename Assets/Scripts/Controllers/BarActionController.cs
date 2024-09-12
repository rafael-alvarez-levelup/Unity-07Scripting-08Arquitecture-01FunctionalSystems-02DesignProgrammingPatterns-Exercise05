using UnityEngine;

public class BarActionController : MonoBehaviour, IObserver<ActionPointsArgs>
{
    private IBarAction barActionBehaviour;
    private ISubject<ActionPointsArgs> subject;

    private void Awake()
    {
        barActionBehaviour = GetComponent<IBarAction>();

        subject = FindObjectOfType<ActionPointsController>();
    }

    private void OnEnable()
    {
        subject.Add(this);
    }

    private void OnDisable()
    {
        subject.Remove(this);
    }

    public void OnNotify(ActionPointsArgs param)
    {
        barActionBehaviour.SetActionPoints(param.totalActionPoints);
    }
}