public interface ICommandProcessor
{
    void Add(ICommand command);
    void RunNext();
    int GetCommandQueueCount();
}