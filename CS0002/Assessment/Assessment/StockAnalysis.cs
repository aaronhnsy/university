using System.Globalization;

namespace Assessment;

public class StockAnalysis
{
    private readonly struct TradingDay(IReadOnlyList<string> row)
    {
        public DateOnly Date { get; } = DateOnly.Parse(row[0]);
        public float Open { get; } = float.Parse(row[1]);
        public float High { get; } = float.Parse(row[2]);
        public float Low { get; } = float.Parse(row[3]);
        public float Close { get; } = float.Parse(row[4]);
        public int Volume { get; } = int.Parse(row[5]);
    }

    private List<TradingDay> _days = [];
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

    private void AnalyseYear()
    {
        _days.Sort((day1, day2) => day1.Date.CompareTo(day2.Date));

        var count = _days.Count;
        Output.Purple("Total number of trading days: ");
        Output.Green($"{count}\n");

        var firstTradingDayPrice = _days.First().Open;
        Output.Purple("Opening price of the first trading day: ");
        Output.Green($"{firstTradingDayPrice:F2}\n");

        var lastTradingDayPrice = _days.Last().Close;
        Output.Purple("Closing price of the last trading day: ");
        Output.Green($"{lastTradingDayPrice:F2}\n");

        var highestTradingPrice = _days.Max(day => day.High);
        Output.Purple("Highest trading price of the year: ");
        Output.Green($"{highestTradingPrice:F2}\n");

        var lowestTradingPrice = _days.Min(day => day.Low);
        Output.Purple("Lowest trading price of the year: ");
        Output.Green($"{lowestTradingPrice:F2}\n");

        _days.Sort((day1, day2) => day2.Volume.CompareTo(day1.Volume));
        var highestVolumeDayDate = _days.First().Date;
        Output.Purple("Date with the highest trading volume: ");
        Output.Green($"{highestVolumeDayDate}\n");

        _days.Sort((day1, day2) => day1.Date.CompareTo(day2.Date));
        var highestVolumeDayIndex = _days.FindIndex(0, day => day.Date == highestVolumeDayDate);
        var highestVolumeDayClosingPrice = _days[highestVolumeDayIndex].Close;
        var previousDayClosingPrice = _days[highestVolumeDayIndex - 1].Close;
        var closingPriceChange = (highestVolumeDayClosingPrice - previousDayClosingPrice) / previousDayClosingPrice;
        Output.Purple("- Change in closing price from the previous trading day: ");
        Output.Green($"{closingPriceChange:P2}\n");
    }

    private static readonly Dictionary<string, byte> Months = new()
    {
        ["january"] = 1, ["jan"] = 1,
        ["may"] = 5,
        ["december"] = 12, ["dec"] = 12
    };

    private static byte ChooseMonth()
    {
        while (true) {
            Output.Yellow("What month would you like to analyse: ");
            var line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line) && Months.TryGetValue(line.ToLower(), out var month)) {
                return month;
            }
            Output.RedNL("That is not a valid month. Choices are January, May, or December.\n");
        }
    }

    private void AnalyseMonth(byte month)
    {
        var monthName = Months.FirstOrDefault(kvPair => kvPair.Value == month).Key;
        Output.Purple("\nSelected month: ");
        Output.Green($"{new CultureInfo("en_GB", false).TextInfo.ToTitleCase(monthName)}\n");

        var days = _days.Where(day => day.Date.Month == month).ToList();
        days.Sort((day1, day2) => day1.Date.CompareTo(day2.Date));

        var firstTradingDayPrice = days.First().Open;
        Output.Purple("Opening price: ");
        Output.Green($"{firstTradingDayPrice:F2}\n");

        var lastTradingDayPrice = days.Last().Close;
        Output.Purple("Closing price: ");
        Output.Green($"{lastTradingDayPrice:F2}\n");

        var highestTradingPrice = days.Max(day => day.High);
        Output.Purple("Highest trading price: ");
        Output.Green($"{highestTradingPrice:F2}\n");

        var lowestTradingPrice = days.Min(day => day.Low);
        Output.Purple("Lowest trading price: ");
        Output.Green($"{lowestTradingPrice:F2}\n");

        days.Sort((day1, day2) => day2.Volume.CompareTo(day1.Volume));
        Output.Purple("Dates with the highest trading volume: ");
        Output.Green(
            $"{days[0].Date} ({days[0].Volume}), " +
            $"{days[1].Date} ({days[1].Volume}), " +
            $"{days[2].Date} ({days[2].Volume})\n"
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
