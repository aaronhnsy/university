namespace Assessment;

internal static class Program
{
    private static void Main(string[] _)
    {
        // This flag controls the main loop of the program, at any point during execution we
        // can set this to false and continue to the next loop to exit the program.
        var active = true;

        while (active) {
            // Print the programs main menu using my custom IO (Input/Output) helper class to
            // colourise the output.
            IO.WriteLine("Main Menu:", colour: ConsoleColor.Green);
            IO.Write("1. ", colour: ConsoleColor.Blue);
            IO.Write("Find Cubic Function Minimum and Maximum\n");
            IO.Write("2. ", colour: ConsoleColor.Blue);
            IO.Write("Stock Analysis\n");
            IO.Write("3. ", colour: ConsoleColor.Blue);
            IO.Write("Exit\n");

            /*
             * Use my IO helper class method to get an sbyte input from the user;
             * - [1] The type returned is specified in the angle brackets (<sbyte>).
             *   - We use an sbyte because the options only range from 1-3, it would be wasteful to
             *     use a type that allows for a higher range of inputs.
             * - [2] The first argument is the prompt to display to the user.
             * - [3] The second argument is the error message to display if the input is invalid.
             * - [4] If the input is invalid, an ArgumentException is thrown and caught in the catch block.
             *   - [5] The error message is printed to the console, in red.
             *   - [6] The loop continues to the next iteration, which displays the main menu again.
             */
            sbyte input;
            try {
                input = IO.GetNumberInput<sbyte>(  // [1]
                    prompt: "Enter your choice: ",  // [2]
                    errorMessage: "That is not a valid number."  // [3]
                );
            }
            catch (ArgumentException e) {  // [4]
                IO.WriteLine($"{e.Message}\n", colour: ConsoleColor.Red);  // [5]
                continue; // [6]
            }

            /*
             * The switch statement is used to decide which actions to perform based on the
             * users input;
             * 1. If the user types '1', we call the Calculate method from the CubicMinMax class.
             * 2. If the user types '2', we call the Menu method from the StockAnalysis class.
             * 3. If the user types '3', we set the active flag to false which will cause the main
             *    while loop's condition to be false, it turn, causing the loop to stop and the
             *    program to exit.
             * If the user didn't pick a valid option (1, 2, or 3), we tell them so and just continue
             * as normal because the loop will restart after this switch block ends, allowing them
             * to try again.
             */
            switch (input) {
                case 1:
                    CubicMinimumAndMaximum.Start();
                    break;
                case 2:
                    StockAnalysis.Menu();
                    break;
                case 3:
                    active = false;
                    break;
                default:
                    IO.WriteLine(
                        "That is not a valid choice.\n",
                        colour: ConsoleColor.Red
                    );
                    break;
            }
        }

        // If the while loop has finished, we can assume the user chose to exit the program so we
        // print a goodbye message to the console.
        Console.WriteLine("Goodbye!");
    }
}
