namespace Assessment;

internal static class Program
{
    private static void Main(string[] _)
    {
        /*
         * This boolean flag value controls the main loop of the program. At any point
         * during execution we can set it to 'false' which will end the program after
         * the current loop is over. We could also choose to use 'continue' or 'break'
         * to end the current loop immediately.
         */
        var active = true;

        while (active) {
            // print the main menu text using the Output helper class to colourise the
            // different elements.
            Output.GreenNL("Main Menu:");
            Output.Blue("1. ");
            Output.White("Find Cubic Function's Minimum and Maximum\n");
            Output.Blue("2. ");
            Output.White("Stock Analysis\n");
            Output.Blue("3. ");
            Output.White("Exit\n");

            /*
             * Use one of the Input helper class methods to get an input from the user;
             * - The type returned is specified in the angle brackets. (<byte>)
             *   - We're using a byte type here because it only stores numbers ranging
             *     from 0 to 255, which uses the least amount of memory. Our main menu
             *     only has 3 options so this is the most efficient type.
             * - The first parameter is the prompt telling the user what to input.
             * - The second parameter is the variable used to store their parsed input.
             * - This method returns true or false depending on the if the users input
             *   was able to be parsed into the type specified in the angle brackets.
             * - Using that return value, we can tell the user their input was invalid
             *   and continue to the next loop which will ask them to input something
             *   else.
             */
            if (Input.Get<byte>("Enter your choice: ", out var choice) == false) {
                Output.RedNL("That is not a valid number.\n");
                continue;
            }

            /*
             * The switch statement is used to decide which actions to perform based on
             * the users input;
             * - 1: We call 'CubicMinimumAndMaximum.Start()' which starts the cubic
             *      function local minimum and maximum part of this program.
             * - 2: We call `StockAnalysis.Menu()` which starts the menu for the stock
             *      analysis part of this program.
             * - 3: We set the main loops boolean flag to false which will end the
             *      program after the current loop has finished executing.
             * - If the user didn't select a valid choice, we tell them so and continue
             *   as normal because the main loop will restart after this, allowing them
             *   to pick another option.
             * - The extraneous `Console.WriteLine()`'s are to insert new lines to
             *   format everything nicely.
             */
            switch (choice) {
                case 1:
                    Console.WriteLine();
                    CubicMinimumAndMaximum.Start();
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine();
                    StockAnalysis.Menu();
                    Console.WriteLine();
                    break;
                case 3:
                    active = false;
                    break;
                default:
                    Output.RedNL("That is not a valid choice.\n");
                    break;
            }
        }
        // If the program main loop has finished, we can assume the user chose to exit
        // the program so we print a goodbye message to the console.
        Output.WhiteNL("Goodbye!");
    }
}
