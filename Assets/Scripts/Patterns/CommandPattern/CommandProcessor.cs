using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour, ICommandProcessor
{
    private readonly Queue<ICommand> commands = new Queue<ICommand>();

    public void Add(ICommand command)
    {
        commands.Enqueue(command);
    }

    public int GetCommandQueueCount()
    {
        return commands.Count;
    }

    public void RunNext()
    {
        if (commands.Count > 0)
        {
            ICommand command = commands.Dequeue();
            command.Execute();
        }
    }
}