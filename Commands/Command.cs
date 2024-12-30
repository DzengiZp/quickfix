public abstract class Command
{
    public int Choice { get; init; }
    public string CommandName { get; init; }
    public string Description { get; init; }

    public Command(int choice, string commandName, string description)
    {
        Choice = choice;
        CommandName = commandName;
        Description = description;
    }

    public abstract void Execute();

    public abstract void Undo();
}
