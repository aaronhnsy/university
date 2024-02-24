namespace Labs;

public static class LabSix
{
    public static void TestLabSix()
    {
        Console.WriteLine("Testing Lab Six");
        // Task610();
        // Task620();
        Task631();
        Task632();
        Task633();
        Console.WriteLine("End of Lab Six");
    }

    private static bool CheckArray(int[] array)
    {
        /*
         * This function loops through each number in the array, checking that each one
         * is at least more than or equal to the next element. Essentially checking that
         * the array is sorted in descending order.
         */
        int i = 1;
        while (!(i >= array.Length)) {
            if (array[i - 1] < array[i]) {
                return false;
            }
            i += 1;
        }
        return true;
    }

    private static void Task610()
    {
        Console.WriteLine("Task 6.1.0: Checking an array");

        int[] arrayOne = new int[] { };
        Console.WriteLine(CheckArray(arrayOne));
        int[] arrayTwo = new int[] { 1 };
        Console.WriteLine(CheckArray(arrayTwo));
        int[] arrayThree = new int[] { 7, 6, 5, 4, 3, 2, 1, 0 };
        Console.WriteLine(CheckArray(arrayThree));
        int[] arrayFour = new int[] { 9, 9, 9 };
        Console.WriteLine(CheckArray(arrayFour));
        int[] arrayFive = new int[] { 8, 9, 7, 5, 6, 4, 3 };
        Console.WriteLine(CheckArray(arrayFive));
    }

    private static void Task620()
    {
        Console.WriteLine("Task 6.2.0: Euclid's Algorithm");

        // take user inputs
        Console.WriteLine("Enter the first number: ");
        if (!int.TryParse(Console.ReadLine(), out var numberOne)) {
            Console.WriteLine("That is not a valid number.");
            return;
        }
        Console.WriteLine("Enter the second number: ");
        if (!int.TryParse(Console.ReadLine(), out var numberTwo)) {
            Console.WriteLine("That is not a valid number.");
            return;
        }

        // store calculated numbers so that we can show the user their original
        // choices in the message at the end.
        int a = numberOne;
        int b = numberTwo;

        // calculate the initial remainder
        int c = a % b;

        // if the remainder is zero we skip straight to showing the HCF, otherwise
        // we divide 'b' (set to 'a') by the previous remainder 'c' (set to 'b')
        // until the remainder of that result is zero.
        while (c != 0) {
            // set 'a' to what 'b' was
            a = b;
            // set 'b' to the previous remainder ('a' divided by 'b')
            b = c;
            // recalculate the remainder
            c = a % b;
        }

        // show the user what numbers they chose and their highest command factor.
        Console.WriteLine($"The Highest Common Factor of '{numberOne}' and '{numberTwo}' is '{b}'.");
    }

    private static double CalculateFunctionOne(double x)
    {
        return Math.Pow(x, 2) - 2;
    }

    private static double DeriveFunctionOne(double x)
    {
        return x * 2;
    }

    private static void Task631()
    {
        Console.WriteLine("Task 6.3.1: The Newton-Raphson Method: f(x) = (x^2 - 2) = 0");
        double x = 10;
        double h = CalculateFunctionOne(x) / DeriveFunctionOne(x);
        while (Math.Abs(h) >= 0.001) {
            h = CalculateFunctionOne(x) / DeriveFunctionOne(x);
            x -= h;
        }
        Console.WriteLine($"The value of the root is: {x}");
    }

    private static double CalculateFunctionTwo(double x)
    {
        return Math.Pow(x, 7) - (5 * Math.Pow(x, 4)) + (2 * x) - 17;
    }

    private static double DeriveFunctionTwo(double x)
    {
        return (7 * Math.Pow(x, 6)) - (20 * Math.Pow(x, 3)) + 2;
    }

    private static void Task632()
    {
        Console.WriteLine("Task 6.3.2: The Newton-Raphson Method: f(x) = (x^7 - 5x^4 + 2x - 17) = 0");
        double x = -1;
        double h = CalculateFunctionTwo(x) / DeriveFunctionTwo(x);
        while (Math.Abs(h) >= 0.001) {
            h = CalculateFunctionTwo(x) / DeriveFunctionTwo(x);
            x -= h;
        }
        Console.WriteLine($"The value of the root is: {x}");
    }

    private static double CalculateFunctionThree(double x)
    {
        return 1 / Math.Pow(2, x) - Math.Pow(x, 3);
    }

    private static double DeriveFunctionThree(double x)
    {
        return -(Math.Log(2) / Math.Pow(2, x)) - 3;
    }

    private static void Task633()
    {
        Console.WriteLine("Task 6.3.3: The Newton-Raphson Method: f(x) = ((0.5)^x - x^3) = 0");
        double x = 1;
        double h = CalculateFunctionThree(x) / DeriveFunctionThree(x);
        while (Math.Abs(h) >= 0.001) {
            h = CalculateFunctionThree(x) / DeriveFunctionThree(x);
            x -= h;
        }
        Console.WriteLine($"The value of the root is: {x}");
    }
}
