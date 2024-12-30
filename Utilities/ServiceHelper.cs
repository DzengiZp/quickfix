public class ServiceHelper
{
    public static string FirstLetterUppercase(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        input = input[..1].ToUpper() + input[1..].ToLower();

        input = input.Replace(" ", "");

        return input;
    }

    public static string FirstLetterUppercaseWithoutTrim(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        input = input[..1].ToUpper() + input[1..].ToLower();

        return input;
    }

    public static bool CheckInputForOnlyLettersAndDigits(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        bool hasDigit = input.Any(char.IsDigit);
        bool hasLetter = input.Any(char.IsLetter);
        bool hasSpecialChar = input.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch));

        return hasDigit && hasLetter && !hasSpecialChar;
    }
    public static bool CheckInputForOnlyLetters(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        bool hasDigit = input.Any(char.IsDigit);
        bool hasLetter = input.Any(char.IsLetter);
        bool hasSpecialChar = input.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch));

        return !hasDigit && hasLetter && !hasSpecialChar;
    }

    public static bool CheckInputForOnlyDigits(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        bool hasDigit = input.Any(char.IsDigit);
        bool hasLetter = input.Any(char.IsLetter);
        bool hasSpecialChar = input.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch));

        return hasDigit && !hasLetter && !hasSpecialChar;
    }
    public static void PressAnyKey()
    {
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }
}

