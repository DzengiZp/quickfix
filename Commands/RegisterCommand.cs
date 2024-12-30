using BCrypt.Net;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

public class RegisterCommand : Command
{
    string? email;
    string? firstName;
    string? surname;
    string? address;
    string? city;
    string? zipCode;
    string? country;
    string? socialSecurityNumber;
    string? passwordHash;

    public RegisterCommand()
        : base(1, "Register", "Register an account.") { }

    public override void Execute()
    {
        MainMenu mainMenu = new();

        Console.Clear();
        Console.WriteLine("Register Menu\n");

        while (true)
        {
            Console.Write("First name: ");
            firstName = Console.ReadLine();

            if (!ServiceHelper.CheckInputForOnlyLetters(firstName))
            {
                Console.WriteLine("Can't be empty");
                continue;
            }

            firstName = ServiceHelper.FirstLetterUppercase(firstName);
            break;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Register Menu\n");
            Console.WriteLine("First name: " + firstName + "\n");
            Console.Write("Surname: ");
            surname = Console.ReadLine()!;

            if (!ServiceHelper.CheckInputForOnlyLetters(surname))
            {
                Console.WriteLine("Can't be empty");
                continue;
            }

            surname = ServiceHelper.FirstLetterUppercase(surname);
            break;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Register Menu\n");
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Surname: " + surname + "\n");

            Console.Write("Address: ");
            address = Console.ReadLine();

            address = ServiceHelper.FirstLetterUppercaseWithoutTrim(address);

            if (string.IsNullOrEmpty(address))
            {
                Console.WriteLine("Can't be empty");
                continue;
            }

            if (!ServiceHelper.CheckInputForOnlyLettersAndDigits(address))
            {
                Console.WriteLine("Can only be letters and digits");
                continue;
            }

            address = RegisterService.CheckAddressFormat(address);

            break;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Register Menu\n");
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Surname: " + surname);
            Console.WriteLine("Address: " + address + "\n");

            Console.Write("City: ");
            city = Console.ReadLine();

            if (!ServiceHelper.CheckInputForOnlyLetters(city))
            {
                Console.WriteLine("Can't be empty");
                continue;
            }

            city = ServiceHelper.FirstLetterUppercase(city);
            break;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Register Menu\n");
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Surname: " + surname);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("City: " + city + "\n");

            Console.Write("ZipCode: ");
            zipCode = Console.ReadLine();

            if (!ServiceHelper.CheckInputForOnlyDigits(zipCode))
            {
                Console.WriteLine("Can only be digits");
                continue;
            }

            if (string.IsNullOrEmpty(zipCode))
            {
                Console.WriteLine("Can't be empty");
                continue;
            }

            if (zipCode.Length > 5 || zipCode.Length <= 4)
            {
                Console.WriteLine("Zip Code has to be 5 digits");
                continue;
            }

            zipCode = ServiceHelper.FirstLetterUppercaseWithoutTrim(zipCode);

            zipCode = RegisterService.ZipCodeFormat(zipCode);

            break;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Register Menu\n");
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Surname: " + surname);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("City: " + city);
            Console.WriteLine("Zip Code: " + zipCode + "\n");

            Console.Write("Country: ");
            country = Console.ReadLine();

            if (string.IsNullOrEmpty(country))
            {
                Console.WriteLine("Can't be empty");
                continue;
            }
            if (!ServiceHelper.CheckInputForOnlyLetters(country))
            {
                continue;
            }

            country = ServiceHelper.FirstLetterUppercase(country);

            break;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Register Menu\n");
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Surname: " + surname);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("City: " + city);
            Console.WriteLine("Zip Code: " + zipCode);
            Console.WriteLine("Country: " + country + "\n");

            Console.Write("Social security number: ");
            socialSecurityNumber = Console.ReadLine();

            if (string.IsNullOrEmpty(socialSecurityNumber))
            {
                Console.WriteLine("Can't be empty");
                continue;
            }

            socialSecurityNumber = RegisterService.SecurityNumFormat(socialSecurityNumber);

            try
            {
                DateOnly date = DateOnly.Parse(socialSecurityNumber.Substring(0, 10));
            }
            catch
            {
                Console.WriteLine($"{socialSecurityNumber} is not valid.");
                continue;
            }

            break;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Register Menu\n");
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Surname: " + surname);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("City: " + city);
            Console.WriteLine("Zip Code: " + zipCode);
            Console.WriteLine("Country: " + country);
            Console.WriteLine("Social security number: " + socialSecurityNumber + "\n");

            Console.Write("Email: ");
            email = Console.ReadLine();

            if (!RegisterService.CheckEmail(email))
            {
                Console.WriteLine("Email incorrect, try again.");
                continue;
            }

            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Can't be empty");
                continue;
            }

            break;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Register Menu\n");
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Surname: " + surname);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("City: " + city);
            Console.WriteLine("Zip Code: " + zipCode);
            Console.WriteLine("Country: " + country);
            Console.WriteLine("Social security number: " + socialSecurityNumber);
            Console.WriteLine("Email: " + email + "\n");

            Console.Write("Password: ");
            string? password = PasswordHelper.HidePassword();

            if (!PasswordHelper.IsPasswordStrong(password))
            {
                Console.WriteLine(
                    "Password must contain at least one uppercase letter,"
                  + " one lowercase letter, one number and one special character."
                );
                continue;
            }

            Console.Write("Confirm password: ");
            string? confirmPassword = PasswordHelper.HidePassword();

            if (confirmPassword != password)
            {
                Console.WriteLine("Password doesn't match");
                continue;
            }

            passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            break;
        }

        User user = new User(
            email,
            passwordHash,
            firstName,
            surname,
            address,
            city,
            zipCode,
            country,
            socialSecurityNumber
        );

        try
        {
            using var context = new AppContext();

            if (context.Users == null)
            {
                Console.WriteLine($"{context.Users} doesn't exist.");
                return;
            }

            if (context.Users.Any(u => u.Email == email))
            {
                Console.Clear();
                Console.WriteLine("Can't add user to database, duplicate Email exists.");
                ServiceHelper.PressAnyKey();
                mainMenu.Display();
                return;
            }

            context.Users.Add(user);
            context.SaveChanges();

            Console.WriteLine("Created user. Try logging in.");

            mainMenu.Display();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

public class AppContext : DbContext
{
    public DbSet<User>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        Env.Load();
        builder.UseNpgsql(Env.GetString("DATABASE_STRING"));
    }
}
