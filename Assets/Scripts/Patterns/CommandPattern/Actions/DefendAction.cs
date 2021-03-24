public class DefendAction : ActionBase
{
    private void Awake()
    {
        Command = new DefendCommand(GetComponentInParent<IDefend>());
    }
}