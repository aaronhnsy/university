namespace Assessment;

public class StockAnalysis
{
    /*
     * Define a struct that represents a row from the CSV file, each row being one trading
     * day. The constructor accepts a list of strings which are the values of the columns
     * for this row. The struct is marked as readonly because once the properties are set,
     * they do not need to be changed.
    */
    private readonly struct TradingDay(IReadOnlyList<string> row)
    {
        public DateOnly Date { get; } = DateOnly.Parse(row[0]);
        public float Open { get; } = float.Parse(row[1]);
        public float High { get; } = float.Parse(row[2]);
        public float Low { get; } = float.Parse(row[3]);
        public float Close { get; } = float.Parse(row[4]);
        public int Volume { get; } = int.Parse(row[5]);
    }

    /*
     * Define a list to store instances of the `TradingDay` struct which will represent each
     * trading day from the CSV file.
    */
    private readonly List<TradingDay> _days = [];

    /*
     * This function reads the CSV file until the end (`.EndOfStream`), converting each line
     * into an instance of the `TradingDay` struct, and then adding that to the `_days` list.
     * If a line is empty, null, or contains invalid data, the line is ignored and a warning
     * is shown to the user.
    */
    private void LoadTradingDays()
    {
        using var streamReader = new StreamReader("AMD.csv");
        while (!streamReader.EndOfStream) {
            var line = streamReader.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) {
                Output.RedNL("Skipped an empty line while parsing CSV file.");
                continue;
            }
            try {
                _days.Add(new TradingDay(line.Split(",")));
            }
            catch (FormatException) {
                Output.RedNL($"Skipped a line that contained invalid data:\n{line}");
            }
        }
    }

    // analyses the trading days data for the entire year.
    private void AnalyseYear()
    {
        // the total number of trading days is the amount of elements in the `_days` list.
        Output.Purple("Total number of trading days: ");
        Output.Green($"{_days.Count}\n");

        // make sure the days are sorted by date (ascending)
        _days.Sort((dayOne, dayTwo) => dayOne.Date.CompareTo(dayTwo.Date));

        // the first element is the first trading day. (using `:F2` to round the number to 2 decimal places).
        var firstTradingDayOpenPrice = _days.First().Open;
        Output.Purple("Opening price of the first trading day: ");
        Output.Green($"{firstTradingDayOpenPrice:F2}\n");
        // the last element is the last trading day.
        var lastTradingDayClosePrice = _days.Last().Close;
        Output.Purple("Closing price of the last trading day: ");
        Output.Green($"{lastTradingDayClosePrice:F2}\n");

        // use the `Max()` method to find the highest trading price of the year.
        var highestTradingPrice = _days.Max(day => day.High);
        Output.Purple("Highest trading price of the year: ");
        Output.Green($"{highestTradingPrice:F2}\n");
        // use the `Min()` method to find the lowest trading price of the year.
        var lowestTradingPrice = _days.Min(day => day.Low);
        Output.Purple("Lowest trading price of the year: ");
        Output.Green($"{lowestTradingPrice:F2}\n");

        // use the `MaxBy()` method to get the date of the day with the highest trading volume.
        var highestVolumeDayDate = _days.MaxBy(day => day.Volume).Date;
        Output.Purple("Date with the highest trading volume: ");
        Output.Green($"{highestVolumeDayDate}\n");
        /*
         * Find the index of the date with the highest trading volume (see above) and then get
         * the closing price of that day, and the day before that (index - 1) to calculate the
         * difference in closing price.
         * We also use the `:P2` format specifier to display the number as a percentage with 2
         * decimal places.
         */
        var highestVolumeDayIndex = _days.FindIndex(0, day => day.Date == highestVolumeDayDate);
        var highestVolumeDayClosingPrice = _days[highestVolumeDayIndex].Close;
        var previousDayClosingPrice = _days[highestVolumeDayIndex - 1].Close;
        var closingPriceChange = (highestVolumeDayClosingPrice - previousDayClosingPrice) / previousDayClosingPrice;
        Output.Purple("- Change in closing price from the previous trading day: ");
        Output.Green($"{closingPriceChange:P2}\n");
    }

    /*
     * A dictionary that maps abbreviated month names to a tuple containing their number within
     * the calendar year and their full name.
    */
    private static readonly Dictionary<string, (byte Number, string Name)> Months = new()
    {
        ["jan"] = (Number: 1, Name: "January"),
        ["feb"] = (Number: 2, Name: "February"),
        ["mar"] = (Number: 3, Name: "March"),
        ["apr"] = (Number: 4, Name: "April"),
        ["may"] = (Number: 5, Name: "May"),
        ["jun"] = (Number: 6, Name: "June"),
        ["jul"] = (Number: 7, Name: "July"),
        ["aug"] = (Number: 8, Name: "August"),
        ["sep"] = (Number: 9, Name: "September"),
        ["oct"] = (Number: 10, Name: "October"),
        ["nov"] = (Number: 11, Name: "November"),
        ["dec"] = (Number: 12, Name: "December")
    };

    /*
     * This function loops, prompting the user each time to enter a month name. If the first
     * three characters of their input matches a key in the `Months` dictionary, the matching
     * value is returned which contains the month number and its full name. If the input didnt
     * match a key, an error message is shown and the loop continues.
    */
    private static (byte Number, string Name) ChooseMonth()
    {
        while (true) {
            Output.Yellow("What month would you like to analyse: ");
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && Months.TryGetValue(input.ToLower()[..3], out var month)) {
                return month;
            }
            Output.RedNL("That is not a valid month. Choices are January, May, or December.\n");
        }
    }

    // analyses the trading days data for a specific month.
    private void AnalyseMonth((byte Number, string Name) monthInfo)
    {
        // tell the user their selected month.
        Output.Purple("\nSelected month: ");
        Output.Green($"{monthInfo.Name}\n");

        // filter the `_days` list to only include days from the selected month.
        var monthDays = _days.Where(day => day.Date.Month == monthInfo.Number).ToList();
        // make sure the days are sorted by date (ascending)
        monthDays.Sort((dayOne, dayTwo) => dayOne.Date.CompareTo(dayTwo.Date));

        // the first element is the first trading day of the month.
        var firstTradingDayPrice = monthDays.First().Open;
        Output.Purple("Opening price: ");
        Output.Green($"{firstTradingDayPrice:F2}\n");
        // the last element is the last trading day of the month.
        var lastTradingDayPrice = monthDays.Last().Close;
        Output.Purple("Closing price: ");
        Output.Green($"{lastTradingDayPrice:F2}\n");

        // use the `Max()` method to find the highest trading price of the month.
        var highestTradingPrice = monthDays.Max(day => day.High);
        Output.Purple("Highest trading price: ");
        Output.Green($"{highestTradingPrice:F2}\n");
        // use the `Min()` method to find the lowest trading price of the month.
        var lowestTradingPrice = monthDays.Min(day => day.Low);
        Output.Purple("Lowest trading price: ");
        Output.Green($"{lowestTradingPrice:F2}\n");

        // sort the list by volume in descending order to get the days with the highest volume.
        monthDays.Sort((dayOne, dayTwo) => dayTwo.Volume.CompareTo(dayOne.Volume));
        Output.Purple("Dates with the highest trading volume: ");
        Output.Green(
            $"{monthDays[0].Date} ({monthDays[0].Volume}), " +
            $"{monthDays[1].Date} ({monthDays[1].Volume}), " +
            $"{monthDays[2].Date} ({monthDays[2].Volume})\n"
        );
    }

    public void Menu()
    {
        /*
         * load the trading days data from the CSV file and store it in the `_days` list as a class
         * variable so that it can be accessed from all the other methods in this class.
         */
        LoadTradingDays();

        /*‹
         * Most of the following code is the same as found in `Program.cs`, with a few minor changes
         * to accommodate for this being the stock analysis menu rather than the programs main menu.
         */
        var active = true;
        while (active) {
            Output.GreenNL("Stock Analysis:");
            Output.Blue("1. ");
            Output.White("Yearly Data\n");
            Output.Blue("2. ");
            Output.White("Monthly Data\n");
            Output.Blue("3. ");
            Output.White("Exit to Main Menu\n");

            if (Input.Get<byte>("Enter your choice: ", out var choice) == false) {
                Output.RedNL("That is not a valid number.\n");
                continue;
            }

            switch (choice) {
                case 1:
                    Console.WriteLine();
                    AnalyseYear();
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine();
                    var month = ChooseMonth();
                    AnalyseMonth(month);
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
    }
}
