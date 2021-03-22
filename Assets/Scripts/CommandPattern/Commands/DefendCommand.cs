public class DefendCommand : ICommand
{
    private readonly IDefend defender;

    public DefendCommand(IDefend defender)
    {
        this.defender = defender;
    }

    public void Execute()
    {
        defender.Defend();
    }
}