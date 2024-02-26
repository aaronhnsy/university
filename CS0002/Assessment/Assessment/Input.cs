using System.Globalization;

namespace Assessment;

public static class Input
{
    /// <summary>
    /// Gets a value from the user and attempts to parse it into type <c>T</c>.
    /// </summary>
    /// <param name="prompt">A prompt describing what the user should input.</param>
    /// <param name="result">A variable to store the result.</param>
    /// <returns>
    /// <c>true</c> if the input was able to be parsed into a value of type <c>T</c>, otherwise <c>false</c>.
    /// </returns>
    public static bool Get<T>(string prompt, out T? result) where T : IParsable<T>
    {
        Output.Yellow(prompt);
        var input = Console.ReadLine();
        /*
         * Attempt to parse the input as a value of the specified type 'T'. The caller of
         * this function can determine whether or not 'result' contains the users parsed
         * input based on the bool returned by this function.
         */
        if (!T.TryParse(input, CultureInfo.CurrentCulture, out var output)) {
            result = default;
            return false;
        }
        result = output;
        return true;
    }
}
