using UnityEngine;

public class PlayerVisualController : MonoBehaviour, IObserver<AttackArgs>
{
    [SerializeField] private GameObject player;

    private ISubject<AttackArgs> attackSubject;
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        attackSubject = player.GetComponent<AttackBehaviour>();
    }

    private void OnEnable()
    {
        attackSubject.Add(this);
    }

    private void OnDisable()
    {
        attackSubject.Remove(this);
    }

    public void OnNotify(AttackArgs param)
    {
        myAnimator.SetTrigger("Attack");
    }
}