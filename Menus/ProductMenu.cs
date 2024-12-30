public class ProductMenu : Menu
{
    public ProductMenu()
    {
        // AddCommand(new Checkout());
    }

    public override void Display()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Product 1");
            Console.WriteLine("Product 2");
            Console.WriteLine("Product 3");
            Console.WriteLine("Product 4");

            Console.Write("Choice: ");
            Console.ReadKey();
        }
    }

    public override void Title()
    {
        throw new NotImplementedException();
    }
}
