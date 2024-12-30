public class TestCommand : Command
{
    public TestCommand()
        : base(4, "Test", "Test Command") { }

    public override void Execute()
    {
        throw new NotImplementedException();
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}
