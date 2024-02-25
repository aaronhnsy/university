using System.Globalization;

namespace Assessment;

public static class IO
{
    public static void Write(string text, ConsoleColor colour = ConsoleColor.White)
    {
        Console.ForegroundColor = colour;
        Console.Write(text);
        Console.ResetColor();
    }

    public static void WriteLine(string text, ConsoleColor colour = ConsoleColor.White)
    {
        Console.ForegroundColor = colour;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static T GetNumberInput<T>(string prompt, string errorMessage) where T : IParsable<T>
    {
        Write(prompt, ConsoleColor.Yellow);
        var input = Console.ReadLine();
        if (!T.TryParse(input, CultureInfo.CurrentCulture, out var output)) {
            throw new ArgumentException(errorMessage);
        }
        return output;
    }
}
