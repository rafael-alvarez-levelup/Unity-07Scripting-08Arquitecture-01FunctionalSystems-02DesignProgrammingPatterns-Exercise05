using UnityEngine;

// TODO: Move animation controller to EnemyVisualController class

public abstract class EnemyBase : MonoBehaviour, IObserver, IObserver<AttackArgs>
{
    public int ID => id;

    [SerializeField] private int id;

    private ISubject subject;
    private Animator myAnimator;
    private ISubject<AttackArgs> attackSubject;

    private void Awake()
    {
        subject = FindObjectOfType<EnemyDieBehaviour>();

        myAnimator = GetComponent<Animator>();

        attackSubject = FindObjectOfType<EnemyAttackBehaviour>();
    }

    private void OnEnable()
    {
        subject.Add(this);

        attackSubject.Add(this);
    }

    private void OnDisable()
    {
        subject.Remove(this);

        attackSubject.Remove(this);
    }

    public void OnNotify()
    {
        myAnimator.SetTrigger("Die");

        TimeManager.Instance.WaitForSeconds(1.5f, () => DestroyEnemy());
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void OnNotify(AttackArgs param)
    {
        myAnimator.SetTrigger("Attack");
    }
}