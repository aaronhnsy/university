namespace Assessment;

public static class Output
{
    private static void Write(string text, ConsoleColor colour)
    {
        Console.ForegroundColor = colour;
        Console.Write(text);
        Console.ResetColor();
    }

    private static void WriteLine(string text, ConsoleColor colour)
    {
        Console.ForegroundColor = colour;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void White(string text) => Write(text, colour: ConsoleColor.White);
    public static void Blue(string text) => Write(text, colour: ConsoleColor.Blue);
    public static void Yellow(string text) => Write(text, colour: ConsoleColor.Yellow);
    public static void Red(string text) => Write(text, colour: ConsoleColor.Red);
    public static void Purple(string text) => Write(text, colour: ConsoleColor.Magenta);
    public static void Green(string text) => Write(text, colour: ConsoleColor.Green);

    public static void WhiteNL(string text) => WriteLine(text, colour: ConsoleColor.White);
    public static void BlueNL(string text) => WriteLine(text, colour: ConsoleColor.Blue);
    public static void YellowNL(string text) => WriteLine(text, colour: ConsoleColor.Yellow);
    public static void RedNL(string text) => WriteLine(text, colour: ConsoleColor.Red);
    public static void PurpleNL(string text) => WriteLine(text, colour: ConsoleColor.Magenta);
    public static void GreenNL(string text) => WriteLine(text, colour: ConsoleColor.Green);
}
