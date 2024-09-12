using UnityEngine;

public class CharacterStateController : StateController
{
    [SerializeField] private AttackBehaviour attackBehaviour;
    [SerializeField] private DefendBehaviour myDefendBehaviour;
    [SerializeField] private HealBehaviour myHealBehaviour;
    [SerializeField] private HealthBehaviour myHealthBehaviour;

    private IState notDefendingCharacterState;
    private IState defendingCharacterState;

    private void Awake()
    {
        notDefendingCharacterState = new NotDefendingCharacterState(
            this,
            attackBehaviour,
            myDefendBehaviour,
            myHealBehaviour,
            myHealthBehaviour,
            myHealthBehaviour
            );

        defendingCharacterState = new DefendingCharacterState(
            this,
            attackBehaviour,
            myDefendBehaviour,
            myHealBehaviour,
            myHealthBehaviour,
            myHealthBehaviour
            );

        states.Add(typeof(NotDefendingCharacterState), notDefendingCharacterState);
        states.Add(typeof(DefendingCharacterState), defendingCharacterState);
    }

    private void Start()
    {
        SwitchState<NotDefendingCharacterState>();
    }
}