using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string Surname { get; private set; } = null!;
    public string Address { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string ZipCode { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public string SocialSecurityNumber { get; private set; } = null!;

    public User(
        string email,
        string passwordHash,
        string firstName,
        string surname,
        string address,
        string city,
        string zipCode,
        string country,
        string socialSecurityNumber
    )
    {
        Email = email;
        PasswordHash = passwordHash;
        FirstName = firstName;
        Surname = surname;
        Address = address;
        City = city;
        ZipCode = zipCode;
        Country = country;
        SocialSecurityNumber = socialSecurityNumber;
    }
}
