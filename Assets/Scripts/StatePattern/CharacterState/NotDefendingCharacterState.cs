public class NotDefendingCharacterState : CharacterStateBase
{
    public NotDefendingCharacterState(
        IStateController controller,
        ISubject<AttackArgs> attackSubject,
        ISubject<DefendArgs> defendSubject,
        ISubject<HealArgs> healSubject,
        IDamageable damageable,
        IHealable healable
        ) : base(controller,
            attackSubject,
            defendSubject,
            healSubject,
            damageable,
            healable)
    {

    }

    public override void OnNotify(AttackArgs param)
    {
        damageable.TakeDamage(param.damage);
    }

    public override void OnNotify(DefendArgs param)
    {
        // TODO: Pass defend args damageReceivedMultiplier to defending state

        controller.SwitchState<DefendingCharacterState>();
    }

    public override void OnNotify(HealArgs param)
    {
        healable.Heal(param.healing);
    }
}
