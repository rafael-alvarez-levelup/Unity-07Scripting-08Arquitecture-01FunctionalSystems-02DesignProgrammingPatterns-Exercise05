public abstract class CharacterStateBase : State, IObserver<AttackArgs>, IObserver<DefendArgs>, IObserver<HealArgs>
{
    private readonly ISubject<AttackArgs> attackSubject;
    private readonly ISubject<DefendArgs> defendSubject;
    private readonly ISubject<HealArgs> healSubject;

    protected readonly IDamageable damageable;
    protected readonly IHealable healable;

    public CharacterStateBase(
        IStateController controller,
        ISubject<AttackArgs> attackSubject,
        ISubject<DefendArgs> defendSubject,
        ISubject<HealArgs> healSubject,
        IDamageable damageable,
        IHealable healable
        ) : base(controller)
    {
        this.attackSubject = attackSubject;
        this.defendSubject = defendSubject;
        this.healSubject = healSubject;
        this.damageable = damageable;
        this.healable = healable;
    }

    public override void Enter()
    {
        attackSubject.Add(this);
        defendSubject.Add(this);
        healSubject.Add(this);
    }

    public override void Exit()
    {
        attackSubject.Remove(this);
        defendSubject.Remove(this);
        healSubject.Remove(this);
    }

    public abstract void OnNotify(AttackArgs param);

    public abstract void OnNotify(DefendArgs param);

    public abstract void OnNotify(HealArgs param);
}