public interface IActionController
{
    ICommand GetCurrentCommand();
    void ResetAction();
}