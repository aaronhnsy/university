namespace Labs;

public static class LabTwo
{
    public static void TestLabTwo()
    {
        Console.WriteLine("Testing Lab Two");
        Task230();
        Task241();
        Task242();
        Task243();
        Console.WriteLine("End of Lab Two");
    }

    private static void Task230()
    {
        Console.WriteLine("Task 2.3.0: Variables and Expressions");

        const int a = 5;
        const double b = 2.3;
        const double c = 1.2;
        const int p = 3;
        const string f = "a student!";
        const string name = "aaron";
        const double pi = 3.142;

        long x;
        double y;
        string z;

        // x = a + b
        // Console.WriteLine(x); - not valid, outputs a double but x is a long.

        y = a + b;
        Console.WriteLine(y); // valid - outputs a double.

        // x = b * c
        // Console.WriteLine(x); - not valid, outputs a double but x is a long.

        z = name + " is " + f;
        Console.WriteLine(z); // valid - outputs a string.

        // x = -2;
        // y = ax^2 + bx + c;
        // Console.WriteLine(y); - not valid - the equation is not valid code.

        // y = 100.9;
        // a = y / 3;
        // Console.WriteLine(a); - not valid - a is an int, but the equation produces a double.

        y = ((pi + 1) / (pi + 2)) / (pi + 3);
        Console.WriteLine(y); // valid - outputs a double.

        // y = -2;
        // x^2 = y^2 + 1;
        // Console.WriteLine(x); - not valid - the equation is not valid code.
    }

    private static void Task241()
    {
        Console.WriteLine("Task 2.4.1: Relational Operators");

        const int m = 100;
        const int n = 204;
        const double o = -23.1;
        const bool p = true;
        const bool q = false;
        const int r = -204;

        if (m < n) {
            Console.WriteLine("(m < n) == True");
        }
        else {
            Console.WriteLine("(m < n) == False");
        }

        if ((m > o) && (p == q)) {
            Console.WriteLine("(m > o && p == q) == True");
        }
        else {
            Console.WriteLine("(m > o && p == q) == False");
        }

        if (2 * r > n) {
            Console.WriteLine("(2 * r  > n) == True");
        }
        else {
            Console.WriteLine("(2 * r  > n) == False");
        }

        if (r != n || n > 0) {
            Console.WriteLine("(r != n || n > 0) == True");
        }
        else {
            Console.WriteLine("(r != n || n > 0) == False");
        }
    }

    private static void Task242()
    {
        Console.WriteLine("Task 2.4.2: If Statements");

        Console.WriteLine("Enter your ID number: ");
        string? idString = Console.ReadLine();
        if (int.TryParse(idString, out int id)) {
            if (id == 20) {
                Console.WriteLine("Id number starts with 20");
            }
            else if (id == 30) {
                Console.WriteLine("Id number starts with 30");
            }
            else if (id == 40) {
                Console.WriteLine("Id number starts with 40");
            }
            else {
                Console.WriteLine("Incorrect employee number");
            }
        }
        else {
            Console.WriteLine("That wasn't a valid number.");
        }
    }

    private static void Task243()
    {
        Console.WriteLine("Task 2.4.3: Select Statements");

        Console.WriteLine("Enter your ID number: ");
        string? idString = Console.ReadLine();
        if (int.TryParse(idString, out int id)) {
            switch (id) {
                case < 10:
                    Console.WriteLine("Id number is less than 10");
                    break;
                case >= 90:
                    Console.WriteLine("Id number is greater than or equal to 90");
                    break;
                case >= 30 and <= 40:
                    Console.WriteLine("Id number is between 30 and 40 inclusive");
                    break;
                case 11 or 21 or 51 or 61:
                    Console.WriteLine("Id number is 11, 21, 51 or 61");
                    break;
                case (>= 60 and <= 80):
                    Console.WriteLine("Id number is between 60 and 80 inclusive");
                    break;
                default:
                    Console.WriteLine("The number is not in any of the cases.");
                    break;
            }
        }
        else {
            Console.WriteLine("That wasn't a valid number.");
        }
    }
}
