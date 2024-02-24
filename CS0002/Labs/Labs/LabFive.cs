namespace Labs;

public static class LabFive
{
    public static void TestLabFive()
    {
        Console.WriteLine("Testing Lab Five");
        Task521();
        Task522();
        Task523();
        Task524();
        Task525();
        Task530();
        Console.WriteLine("End of Lab Five");
    }

    private static void RaiseElementsToPower(double[] numbers, double power)
    {
        for (var i = 0; i < numbers.Length; i += 1) {
            numbers[i] = Math.Round(Math.Pow(numbers[i], power), 2);
        }
    }

    private static void Task521()
    {
        Console.WriteLine("Task 5.2.1: One Dimensional Arrays");

        double[] numbers = new double[] { 1.2, 2.1, 3.2, 4.1, 5.2, 6.1, 7.5, 8.3, 9.4, 10.2 };
        Console.WriteLine($"The original array: {string.Join(", ", numbers)}");
        RaiseElementsToPower(numbers, 3);
        Console.WriteLine($"The array after raising each element to the power of 3: {string.Join(", ", numbers)}");
    }

    private static void Task522()
    {
        Console.WriteLine("Task 5.2.2: One dimensional array calculations");

        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        double sum = 0;
        foreach (int number in numbers) {
            sum += Math.Pow(number, 2);
        }
        Console.WriteLine($"The sum of the squares of the numbers from 1 to 10 is: {sum}");
    }

    private static void Task523()
    {
        Console.WriteLine("Task 5.2.3: Counting digits");

        Console.WriteLine("Enter a decimal number to count the digits of: ");
        string? number = Console.ReadLine();
        if (number is null) {
            Console.WriteLine("Invalid input");
            return;
        }
        int beforeDecimal = 0;
        int afterDecimal = 0;
        for (var i = 0; i < number.Length; i += 1) {
            if (i >= number.IndexOf('.')) {
                afterDecimal += 1;
            }
            else {
                beforeDecimal += 1;
            }
        }
        Console.WriteLine(
            $"There are {beforeDecimal} digits before the decimal point and {afterDecimal - 1} " +
            $"digits after the decimal point in {number}");
    }

    private static void Task524()
    {
        Console.WriteLine("Task 5.2.4: Palindromic Numbers");

        while (true) {
            Console.WriteLine("Enter a number or type 'q' to exit: ");
            string? input = Console.ReadLine();
            if (input is null) {
                Console.WriteLine("That is not a valid number.");
                continue;
            }
            if (input == "q") {
                break;
            }
            if (!int.TryParse(input, out int number)) {
                Console.WriteLine("That is not a valid number.");
            }
            else {
                string numberString = number.ToString();
                bool isPalindrome = false;
                for (var i = 0; i < numberString.Length; i += 1) {
                    if (numberString[i] == numberString[numberString.Length - i - 1]) {
                        isPalindrome = true;
                    }
                    else {
                        isPalindrome = false;
                        break;
                    }
                }
                Console.WriteLine(
                    isPalindrome
                        ? $"{number} is a palindrome."
                        : $"{number} is not a palindrome."
                );
            }
        }
    }

    private static void CalculateSums(int[,] array, bool isRow)
    {
        if (isRow) {
            for (var i = 0; i < array.GetLength(0); i++) {
                int sum = 0;
                for (var j = 0; j < array.GetLength(1); j++) {
                    sum += array[i, j];
                }
                Console.WriteLine($"Row {i}'s sum: {sum}");
            }
        }
        else {
            for (var i = 0; i < array.GetLength(0); i++) {
                int sum = 0;
                for (var j = 0; j < array.GetLength(1); j++) {
                    sum += array[j, i];
                }
                Console.WriteLine($"Column {i}'s sum: {sum}");
            }
        }
    }

    private static void Task525()
    {
        Console.WriteLine("Task 5.2.5: Two Dimensional Arrays");

        Random random = new Random();
        int[,] numbers = new int[4, 4];
        for (var i = 0; i < numbers.GetLength(0); i++) {
            for (var j = 0; j < numbers.GetLength(1); j++) {
                numbers[i, j] = random.Next(1, 10);
            }
        }
        Console.WriteLine("The original array:");
        for (var i = 0; i < numbers.GetLength(0); i++) {
            for (var j = 0; j < numbers.GetLength(1); j++) {
                Console.Write($"{numbers[i, j]}\t");
            }
            Console.WriteLine();
        }
        CalculateSums(numbers, true);
        CalculateSums(numbers, false);
    }

    private static void CalculateAverageCarPrice()
    {
        List<int> prices = new List<int>();
        using (StreamReader streamReader = new StreamReader("carPrices.csv")) {
            string? line;
            while ((line = streamReader.ReadLine()) != null) {
                string[] columns = line.Split(",");
                int price = 0;
                int.TryParse(columns[1], out price);
                prices.Add(price);
            }
        }
        Console.WriteLine($"Number of cars: {prices.Count}");
        Console.WriteLine($"Average price: {prices.Sum() / prices.Count}");
    }

    private static void AddNewCar()
    {
        Console.WriteLine("What is the name of the car? ");
        string? name = Console.ReadLine();
        if (name is null) {
            Console.WriteLine("That is not a valid name.");
            return;
        }
        Console.WriteLine("What is the cost of the car? ");
        if (!int.TryParse(Console.ReadLine(), out var cost)) {
            Console.WriteLine("That is not a valid number.");
            return;
        }
        if (cost < 1000 || cost > 100000) {
            Console.WriteLine("That car costs too much.");
        }
        using (StreamWriter streamWriter = new StreamWriter("carPrices.csv", true)) {
            streamWriter.WriteLine($"{name},{cost}");
        }
    }

    private static void Task530()
    {
        Console.WriteLine("Task 5.3.0: File processing with a menu");

        bool active = true;
        while (active) {
            Console.WriteLine("\tCar Database");
            Console.WriteLine("1. Calculate average car price");
            Console.WriteLine("2. Add new car to the file");
            Console.WriteLine("3. Exit");
            string? input = Console.ReadLine();
            switch (input) {
                case "1":
                    CalculateAverageCarPrice();
                    break;
                case "2":
                    AddNewCar();
                    break;
                case "3":
                    active = false;
                    break;
                default:
                    Console.WriteLine("That wasn't a valid option. Try again");
                    break;
            }
        }
    }
}
