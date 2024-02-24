using System.Globalization;

namespace Lab;

public static class LabFour
{
    public static void TestLabFour()
    {
        Console.WriteLine("Testing Lab Four");
        Task421();
        Task422();
        Task423();
        Task424();
        Task425();
        Task430();
        Console.WriteLine("End of Lab Four");
    }

    private static void Task421()
    {
        Console.WriteLine("Task 4.2.1: Generating sequences using for loops");

        List<string> one = [];
        for (var i = 10; i < 20; i += 3) {
            one.Add(i.ToString());
        }
        Console.WriteLine($"1) {string.Join(", ", one)}");

        List<string> two = [];
        for (var i = 1; i < 11; i += 1) {
            two.Add(Math.Pow(i, 2).ToString(CultureInfo.CurrentCulture));
        }
        Console.WriteLine($"2) {string.Join(", ", two)}");

        List<string> three = [];
        for (var i = -10; i < 11; i += 2) {
            three.Add(i.ToString());
        }
        Console.WriteLine($"3) {string.Join(", ", three)}");
    }

    private static void Task422()
    {
        Console.WriteLine("Task 4.2.2: Using loops for data calculations");

        List<string> divisors = [];
        for (var i = 1; i < 101; i += 1) {
            if (i % 2 == 0 && i % 3 == 0 && i % 5 != 0) {
                divisors.Add(i.ToString());
            }
        }
        Console.WriteLine($"Numbers until 100 divisible by 2 and 3 but not 5: {string.Join(", ", divisors)}");
    }

    private static void Task423()
    {
        Console.WriteLine("Task 4.2.3: Factorials (non recursive implementation)");

        Console.WriteLine("Enter a number to find the factorial of: ");
        if (!int.TryParse(Console.ReadLine(), out var number)) {
            Console.WriteLine("That is not a valid number.");
            return;
        }
        var factorial = 1;
        for (var i = 1; i <= number; i += 1) {
            factorial *= i;
        }
        Console.WriteLine($"The factorial of {number} is {factorial}.");
    }

    private static void Task424()
    {
        Console.WriteLine("Task 4.2.4: Fibonacci sequence");

        Console.WriteLine("How many fibonacci numbers do you want: ");
        if (!int.TryParse(Console.ReadLine(), out var number)) {
            Console.WriteLine("That is not a valid number.");
            return;
        }
        var fibonacci = new List<int> { 0, 1 };
        for (var i = 2; i < number; i += 1) {
            fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);
        }
        Console.WriteLine($"The first {number} fibonacci numbers are: {string.Join(", ", fibonacci)}");
    }

    private static void Task425()
    {
        Console.WriteLine("Task 4.2.5: Using While Loops for a simple user interface.");

        var active = true;
        while (active) {
            Console.WriteLine("Welcome to the menu!");
            Console.WriteLine("1. Function 1");
            Console.WriteLine("2. Function 2");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Choose an option: ");
            if (!int.TryParse(Console.ReadLine(), out var number)) {
                Console.WriteLine("That is not a valid number.");
                continue;
            }
            switch (number) {
                case 1:
                    Console.WriteLine("You chose function 1.");
                    break;
                case 2:
                    Console.WriteLine("You chose function 2.");
                    break;
                case 3:
                    Console.WriteLine("Goodbye!");
                    active = false;
                    break;
                default:
                    Console.WriteLine("That is not a valid option.");
                    break;
            }
        }
    }

    private static void Task430()
    {
        Console.WriteLine("Task 4.3.0: Nested loops");

        List<string> one = [];
        for (var i = 1; i <= 5; i += 1) {
            for (var j = 1; j <= i; j += 1) {
                one.Add(i.ToString());
            }
        }
        Console.WriteLine($"1. {string.Join("", one)}");

        List<string> two = [];
        for (var i = 2; i <= 6; i += 1) {
            for (var j = 1; j <= i; j += 1) {
                two.Add(i.ToString());
            }
        }
        Console.WriteLine($"2. {string.Join("", two)}");

        List<string> three = [];
        for (var i = 1; i <= 5; i += 2) {
            for (var j = 1; j <= i; j += 1) {
                three.Add(i.ToString());
            }
        }
        Console.WriteLine($"3. {string.Join("", three)}");

        List<string> four = [];
        var count = 1;
        for (var i = 1; i <= 7; i += 2) {
            for (var j = 1; j <= count; j += 1) {
                four.Add(i.ToString());
            }
            count += 1;
        }
        Console.WriteLine($"4. {string.Join("", four)}");
    }
}
