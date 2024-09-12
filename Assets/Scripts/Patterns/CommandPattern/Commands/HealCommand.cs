public class HealCommand : ICommand
{
    private readonly IHeal healer;

    public HealCommand(IHeal healer)
    {
        this.healer = healer;
    }

    public void Execute()
    {
        healer.Heal();
    }
}