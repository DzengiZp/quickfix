public class ExitCommand : Command
{
    public ExitCommand()
        : base(3, "Exit", "Exit the application") { }

    public override void Execute()
    {
        Environment.Exit(0);
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}
