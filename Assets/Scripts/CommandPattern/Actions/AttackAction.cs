public class AttackAction : ActionBase
{
    private void Awake()
    {
        Command = new AttackCommand(GetComponentInParent<IAttack>());
    }
}