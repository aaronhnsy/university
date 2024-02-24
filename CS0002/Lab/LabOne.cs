namespace Lab;

public static class LabOne
{
    public static void TestLabOne()
    {
        Console.WriteLine("Testing Lab One");
        Task140();
        Console.WriteLine("End of Lab One");
    }

    private static void Task140()
    {
        Console.WriteLine("Task 1.4.0: Variables in C#");

        const int wholeNumber = 100;
        const int age = 18;
        const string moduleName = "CS0002";
        const string universityName = "Brunel University London";
        const double initialDeposit = 250.0f;
        const double interestRate = 0.052f;

        Console.WriteLine($"The whole number is: {wholeNumber}");
        Console.WriteLine($"I am {age} years old this year.");
        Console.WriteLine($"I am studying the {moduleName} module at {universityName}.");

        Console.WriteLine($"Initial deposit: £{initialDeposit}");
        Console.WriteLine($"Interest rate: {interestRate:P2}");
        Console.WriteLine($"Sum after one year: £{(initialDeposit * (1 + interestRate)):F2}");
    }
}
