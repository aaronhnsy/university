namespace Assessment;

public readonly struct TradingDay(string date, string open, string high, string low, string close, string volume)
{
    public DateOnly Date { get; } = DateOnly.Parse(date);
    public float Open { get; } = float.Parse(open);
    public float High { get; } = float.Parse(high);
    public float Low { get; } = float.Parse(low);
    public float Close { get; } = float.Parse(close);
    public int Volume { get; } = int.Parse(volume);
}

public static class StockAnalysis
{
    private static List<TradingDay> GetTradingDays()
    {
        var days = new List<TradingDay>();
        using var streamReader = new StreamReader("AMD.csv");

        while (!streamReader.EndOfStream) {
            var line = streamReader.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) {
                Output.RedNL("Skipped an empty line while parsing CSV file.");
                continue;
            }
            try {
                var columns = line.Split(",");
                days.Add(new TradingDay(columns[0], columns[1], columns[2], columns[3], columns[4], columns[5]));
            }
            catch (FormatException) {
                Output.RedNL($"Skipped a line that contained invalid data:\n{line}");
            }
        }
        return days;
    }

    private static void AnalyseYear()
    {
        var days = GetTradingDays();
        days.Sort((day1, day2) => day1.Date.CompareTo(day2.Date));

        var count = days.Count;
        Output.Purple("Total number of trading days: ");
        Output.Green($"{count}\n");

        var firstTradingDayPrice = days.First().Open;
        Output.Purple("Opening price of the first trading day: ");
        Output.Green($"{firstTradingDayPrice}\n");

        var lastTradingDayPrice = days.Last().Close;
        Output.Purple("Closing price of the last trading day: ");
        Output.Green($"{lastTradingDayPrice}\n");

        var highestTradingPrice = days.Max(day => day.High);
        Output.Purple("Highest trading price of the year: ");
        Output.Green($"{highestTradingPrice}\n");

        var lowestTradingPrice = days.Min(day => day.Low);
        Output.Purple("Lowest trading price of the year: ");
        Output.Green($"{lowestTradingPrice}\n");

        days.Sort((day1, day2) => day2.Volume.CompareTo(day1.Volume));
        var highestVolumeDayDate = days.First().Date;
        Output.Purple("Date with the highest trading volume: ");
        Output.Green($"{highestVolumeDayDate}\n");

        days.Sort((day1, day2) => day1.Date.CompareTo(day2.Date));
        var highestVolumeDayIndex = days.FindIndex(0, day => day.Date == highestVolumeDayDate);
        var highestVolumeDayClosingPrice = days[highestVolumeDayIndex].Close;
        var previousDayClosingPrice = days[highestVolumeDayIndex - 1].Close;
        var closingPriceChange = (highestVolumeDayClosingPrice - previousDayClosingPrice) / previousDayClosingPrice;
        Output.Purple("- Change in closing price from the previous trading day: ");
        Output.Green($"{closingPriceChange:P}\n");
    }

    public static void Menu()
    {
        /*
         * Most of the following code is the same as found in `Program.cs`, with a few minor changes
         * to accommodate for this being the stock analysis menu rather than the programs main menu.
         */
        var active = true;

        while (active) {
            Output.GreenNL("Stock Analysis:");
            Output.Blue("1. ");
            Output.White("Yearly Data\n");
            Output.Blue("2. ");
            Output.White("Monthly data\n");
            Output.Blue("3. ");
            Output.White("Exit to main menu\n");

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
