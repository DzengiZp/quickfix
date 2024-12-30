using Microsoft.EntityFrameworkCore;

class LoginCommand : Command
{
    public LoginCommand()
        : base(2, "Login", "Description: Login with username and password") { }

    public override void Execute()
    {
        Console.WriteLine("Login Menu\n");

        Console.WriteLine("Email");
        string email = Console.ReadLine()!;

        Console.WriteLine("Password");
        string password = Console.ReadLine()!;

        // Verifierar correct information
        // Skriv ut namn efter inlogg är godkänd

        using var context = new AppContext();

        ProductMenu productMenu = new();
        productMenu.Display();
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}
