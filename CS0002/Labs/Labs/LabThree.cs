namespace Labs;

public static class LabThree
{
    public static void TestLabThree()
    {
        Console.WriteLine("Testing Lab Three");
        Task320();
        Task333();
        Task334();
        Task335();
        Task340();
        Console.WriteLine("End of Lab Three");
    }

    private static void Rounding()
    {
        Console.WriteLine("Task 3.2.1: Rounding");

        Console.WriteLine("Enter a decimal number: ");
        if (double.TryParse(Console.ReadLine(), out var number)) {
            Console.WriteLine("How many decimal places should it be rounded too: ");
            Console.WriteLine(int.TryParse(Console.ReadLine(), out var decimalPlaces)
                ? $"{Math.Round(number, decimalPlaces)}"
                : "That is not a valid amount of decimal places.");
        }
        else {
            Console.WriteLine("That is not a valid number.");
        }
    }

    private static void CompareStrings()
    {
        Console.WriteLine("Task 3.2.1: String Comparison");

        Console.WriteLine("Enter string 1: ");
        var stringOne = Console.ReadLine();
        Console.WriteLine("Enter string 2: ");
        var stringTwo = Console.ReadLine();
        Console.WriteLine(
            string.Equals(stringOne, stringTwo, StringComparison.CurrentCultureIgnoreCase)
                ? "The two strings are equal."
                : "The two strings are not equal."
        );
    }

    private static void Task320()
    {
        Console.WriteLine("Task 3.2.0: Built-in Functions");
        Rounding();
        CompareStrings();
    }

    private static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    private static bool IsLeapYear(int year)
    {
        return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
    }

    private static void Task333()
    {
        Console.WriteLine("Task 3.3.3: Days in a Month");

        Console.WriteLine("Enter a year: ");
        if (!int.TryParse(Console.ReadLine(), out var year)) {
            Console.WriteLine("That is not a valid year.");
            return;
        }

        var isLeapYear = IsLeapYear(year);
        Console.WriteLine("Enter a month: ");
        var month = Console.ReadLine();
        if (month == null) {
            Console.WriteLine("That is not a valid month.");
            return;
        }

        switch (month.ToLower()) {
            case "january":
                Console.WriteLine("There are 31 days in January.");
                break;
            case "february":
                Console.WriteLine($"There are {(isLeapYear ? 29 : 28)} days in February.");
                break;
            case "march":
                Console.WriteLine("There are 31 days in March.");
                break;
            case "april":
                Console.WriteLine("There are 30 days in April.");
                break;
            case "may":
                Console.WriteLine("There are 31 days in May.");
                break;
            case "june":
                Console.WriteLine("There are 30 days in June.");
                break;
            case "july":
                Console.WriteLine("There are 31 days in July.");
                break;
            case "august":
                Console.WriteLine("There are 31 days in August.");
                break;
            case "september":
                Console.WriteLine("There are 30 days in September.");
                break;
            case "october":
                Console.WriteLine("There are 31 days in October.");
                break;
            case "november":
                Console.WriteLine("There are 30 days in November.");
                break;
            case "december":
                Console.WriteLine("There are 31 days in December.");
                break;
            default:
                Console.WriteLine("That is not a valid month.");
                break;
        }
    }

    private static int Factorial(int number)
    {
        if (number == 0) {
            return 1;
        }

        return number * Factorial(number - 1);
    }

    private static void Task334()
    {
        Console.WriteLine("Task 3.3.4: Factorial");

        Console.WriteLine("Enter a number: ");
        if (!int.TryParse(Console.ReadLine(), out var number)) {
            Console.WriteLine("That is not a valid number.");
            return;
        }

        Console.WriteLine($"The factorial of {number} is {Factorial(number)}.");
    }

    private static void PassingByValueAndReference(int numberOne, ref int numberTwo)
    {
        numberOne += 1;
        numberTwo += 1;
    }

    private static void Task335()
    {
        Console.WriteLine("Task 3.3.5: Passing Parameters by Value and by Reference");

        int numberOne = 1;
        int numberTwo = 1;
        PassingByValueAndReference(numberOne, ref numberTwo);
        Console.WriteLine($"Number One: {numberOne}");
        Console.WriteLine($"Number Two: {numberTwo}");
    }

    private static void FunctionOne()
    {
        Console.WriteLine("This is function one.");
    }

    private static void FunctionTwo()
    {
        Console.WriteLine("This is function two.");
    }

    private static void FunctionThree()
    {
        Console.WriteLine("This is function three.");
    }

    private static void Task340()
    {
        Console.WriteLine("Task 3.4.0: A Simple Menu");

        Console.WriteLine("\tWelcome to the menu!");
        Console.WriteLine("1. Function 1");
        Console.WriteLine("2. Function 2");
        Console.WriteLine("3. Function 3");
        Console.WriteLine("4. Exit");

        Console.WriteLine("Please choose an option: ");
        var option = Console.ReadLine();

        switch (option) {
            case "1":
                FunctionOne();
                break;
            case "2":
                FunctionTwo();
                break;
            case "3":
                FunctionThree();
                break;
            case "4":
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("That is not a valid option.");
                break;
        }
    }
}
