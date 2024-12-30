using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Grupparbete;

class Program
{
    static void Main(string[] args)
    {
        MainMenu mainMenu = new MainMenu();
        
        mainMenu.Display();

        while (true)
        {
            _ = int.TryParse(Console.ReadLine(), out int input);
            mainMenu.ExecuteCommand(input);
        }
    }
}

//docker exec -it postgres-ecommerce psql -U postgres -d Ecommerce
