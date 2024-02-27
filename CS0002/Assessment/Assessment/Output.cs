namespace Assessment;

public static class Output
{
    /// <summary>
    /// Writes text to the console in the specified colour.
    /// </summary>
    /// <param name="text">The text to write.</param>
    /// <param name="colour">The colour to write it in.</param>
    private static void Write(string text, ConsoleColor colour)
    {
        Console.ForegroundColor = colour;
        Console.Write(text);
        Console.ResetColor();
    }

    /// <summary>
    /// Writes a line of text to the console in the specified colour.
    /// This method differs from <c>Output.Write(...)</c> in that it appends a new line to the end of the text.
    /// </summary>
    /// <param name="text">The text to write.</param>
    /// <param name="colour">The colour to write it in.</param>
    private static void WriteLine(string text, ConsoleColor colour)
    {
        Console.ForegroundColor = colour;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    // convenience methods for writing text in specific colours to the console.
    public static void White(string text) => Write(text, colour: ConsoleColor.White);
    public static void Blue(string text) => Write(text, colour: ConsoleColor.Blue);
    public static void Yellow(string text) => Write(text, colour: ConsoleColor.Yellow);
    public static void Purple(string text) => Write(text, colour: ConsoleColor.Magenta);
    public static void Green(string text) => Write(text, colour: ConsoleColor.Green);

    // convenience methods for writing lines of text in specific colours to the console.
    public static void WhiteNL(string text) => WriteLine(text, colour: ConsoleColor.White);
    public static void BlueNL(string text) => WriteLine(text, colour: ConsoleColor.Blue);
    public static void RedNL(string text) => WriteLine(text, colour: ConsoleColor.Red);
    public static void PurpleNL(string text) => WriteLine(text, colour: ConsoleColor.Magenta);
    public static void GreenNL(string text) => WriteLine(text, colour: ConsoleColor.Green);
}
