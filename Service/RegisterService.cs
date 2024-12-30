using System.Globalization;

public class RegisterService
{
    public static bool CheckEmail(string? email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        char at = '@';
        string[] emailFinishes = [".se", ".nu", ".com"];

        if (emailFinishes.Any(email.EndsWith) && email.Contains(at))
        {
            return true;
        }
        return false;
    }

    public static string CheckAddressFormat(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        int num = 0;

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {

                break;
            }
            num++;

        }

        return input[..num] + " " + input[num..];
    }

    public static string ZipCodeFormat(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        input = input[..3] + " " + input[3..];

        return input;
    }

    public static string SecurityNumFormat(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }
        
        string digitsOnly = "";

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                digitsOnly += c;
            }
        }

        int digitComp = int.Parse(digitsOnly.Substring(0, 1));

        if (digitsOnly.Length == 12)
        {
            input = digitsOnly[0..4] + "-" + digitsOnly[4..6] + "-" + digitsOnly[6..8] + "-" + digitsOnly[8..12];
        }

        if (digitsOnly.Length == 10 && digitComp >= 3)
        {
            input = "19" + digitsOnly[0..2] + "-" + digitsOnly[2..4] + "-" + digitsOnly[4..6] + "-" + digitsOnly[6..10];
        }

        if (digitsOnly.Length == 10 && digitComp <= 2)
        {
            input = "20" + digitsOnly[0..2] + "-" + digitsOnly[2..4] + "-" + digitsOnly[4..6] + "-" + digitsOnly[6..10];
        }

        return input;
    }
}
