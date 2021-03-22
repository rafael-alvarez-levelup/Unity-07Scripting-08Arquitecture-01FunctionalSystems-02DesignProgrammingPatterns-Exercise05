using UnityEngine;

public class DefendingCharacterState : CharacterStateBase
{
    public DefendingCharacterState(
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
        // TODO: Change hard coded number
        damageable.TakeDamage(Mathf.RoundToInt(param.damage * 0.5f));
        controller.SwitchState<NotDefendingCharacterState>();
    }

    public override void OnNotify(DefendArgs param)
    {
        return;
    }

    public override void OnNotify(HealArgs param)
    {
        healable.Heal(param.healing);
        controller.SwitchState<NotDefendingCharacterState>();
    }
}