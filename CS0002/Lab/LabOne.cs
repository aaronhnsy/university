namespace Lab;

public static class LabOne {
    public static void TestLabOne() {
        Console.WriteLine("Testing Lab One");

        int age = 18;
        string moduleName = "CS0002";
        double interestRate = 0.052f;
        double initialDeposit = 250.0f;
        string universityName = "Brunel University London";
        int wholeNumber = 100;

        Console.WriteLine($"The whole number is: {wholeNumber}");
        Console.WriteLine($"I am {age} years old this year.");
        Console.WriteLine($"I am studying the {moduleName} module at {universityName}.");

        Console.WriteLine($"Initial deposit: £{initialDeposit}");
        Console.WriteLine($"Interest rate: {interestRate:P2}");
        Console.WriteLine($"Sum after one year: £{(initialDeposit * (1 + interestRate)):F2}");
    }
}