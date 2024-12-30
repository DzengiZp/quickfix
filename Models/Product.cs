public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public decimal Rating { get; set; }

    public Product(
        int id,
        string name,
        string description,
        decimal price,
        int inventory,
        decimal rating
    )
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Inventory = inventory;
        Rating = rating;
    }
}
