public class AttackCommand : ICommand
{
    private readonly IAttack attacker;

    public AttackCommand(IAttack attacker)
    {
        this.attacker = attacker;
    }

    public void Execute()
    {
        attacker.Attack();
    }
}