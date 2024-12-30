public abstract class Menu
{
    public List<Command> commands { get; private set; } = new List<Command>();

    public void AddCommand(Command command)
    {
        commands.Add(command);
    }

    public void ExecuteCommand(int input)
    {
        foreach (Command c in commands)
        {
            if (input.Equals(c.Choice))
            {
                c.Execute();
                return;
            }
        }
    }

    public virtual void Display()
    {
        Console.Clear();

        Title();
        foreach (Command command in commands)
        {
            Console.WriteLine($"\t{command.Choice}. {command.CommandName}");
        }
    }

    public abstract void Title();
}
