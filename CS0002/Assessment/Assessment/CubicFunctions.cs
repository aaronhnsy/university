namespace Assessment;

public class FindCubicFunctionMinAndMax
{
    private double _a;
    private double _b;
    private double _c;
    private double _d;
    private double _discriminant;

    private static double GetCoefficient(string prompt)
    {
        /*
         * Use one of the Input helper methods to get a number input from the user.
         * We loop until it returns true indicating that the user has input a valid
         * value.
         */
        double coefficient;
        while (Input.Get(prompt, out coefficient) == false) {
            Output.RedNL("That is not a valid number.");
        }
        return coefficient;
    }

    private enum RootType
    {
        Positive,
        Negative,
    }

    private double CalculateRoot(RootType rootType)
    {
        /*
         * Calculate the positive or negative root, notice the '+ Math.Sqrt(...)' v.s
         * the '- Math.Sqrt(...)'.
         *
         *     -2b +- sqrt[(2b)^2 - (4 * (3a) * c)]
         * x = ------------------------------------
         *                   2 * (3a)
         */
        return rootType switch
        {
            RootType.Positive => (-(2 * _b) + Math.Sqrt(_discriminant)) / (2 * (3 * _a)),
            RootType.Negative => (-(2 * _b) - Math.Sqrt(_discriminant)) / (2 * (3 * _a)),
            _ => throw new ArgumentOutOfRangeException(nameof(rootType))
            // the default case shouldn't ever happen, but it never hurts to be sure.
        };
    }

    private void MinimumOrMaximum(double root)
    {
        /*
         * Calculate the 2nd derivative which will tell us whether this root is the
         * minimum, maximum, or inflection point of the function.
         * - f''(x) = 6ax + 2b
         *
         * Use the root to evaluate one of the possible results of the function.
         * - f(x) = ax^3 + bx^2 + cx + d
         */
        var secondDerivative = (6 * _a * root) + (2 * _b);
        var result = (_a * Math.Pow(root, 3)) + (_b * Math.Pow(root, 2)) + (_c * root) + _d;
        /*
         * The 2nd derivative determines whether the root is the minimum, maximum, or
         * inflection point of the cubic function.
         * - If its more than zero, the root is the minimum.
         * - If its less than zero, the root is the maximum.
         * - If it is zero, the function might have an inflection point.
         */
        switch (secondDerivative) {
            case > 0:
                Output.PurpleNL("Minimum: ");
                Output.GreenNL($"x = {root:F2}\nf(x) = {result:F2}");
                break;
            case < 0:
                Output.PurpleNL("Maximum: ");
                Output.GreenNL($"x = {root:F2}\nf(x) = {result:F2}");
                break;
            default:
                Output.RedNL("The function might have an inflection point");
                break;
        }
    }

    public void Start()
    {
        /*
         * tell the user how their cubic function should be formed before using this
         * calculator.
         */
        Output.Purple("A cubic function is of the form: ");
        Output.Green("f(x) = ax\u00b3 + bx\u00b2 + cx + d\n");

        /*
         * ask the user to input their coefficients, letting them know that they can
         * include negative signs and that the value of 'a' can not be zero.
         */
        Output.BlueNL("\nPlease enter your function's coefficients (a, b, c, and d):");
        Output.BlueNL("- Be sure to include the negative sign if needed.");
        Output.BlueNL("- The 'a' coefficient can not be 0.\n");

        /*
         * Use a helper method to get the coefficients from the user;
         * - We loop while 'a' is equal to 0 until they input a non-zero number.
         * - The method returns their input number as a double which we store as a
         *   class variable, allowing us to access it from all the other methods in
         *   this class.
         */
        _a = GetCoefficient("a: ");
        while (_a == 0) {
            Output.RedNL("The 'a' coefficient can not be zero.");
            _a = GetCoefficient("a: ");
        }
        _b = GetCoefficient("b: ");
        _c = GetCoefficient("c: ");
        _d = GetCoefficient("d: ");

        /*
         * Calculate the discriminant and store it as another class variable, this
         * allows us to use it later when calculating the positive and negative roots.
         */
        _discriminant = Math.Pow((2 * _b), 2) - (4 * (3 * _a) * _c);

        /* If the discriminant is less than zero, the user's cubic function does not
         * have a minimum or maximum, let them know and use an early return to stop
         * any further calculations.
         */
        if (_discriminant < 0) {
            Output.RedNL("\nNo Minimum and Maximum can be found for a cubic function with those coefficients.");
            return;
        }

        // newline for formatting reasons
        Console.WriteLine();

        /*
         * Calculate the positive and negative root and then use the 2nd derivative
         * to find out if that root is the minimum or maximum.
         */
        MinimumOrMaximum(CalculateRoot(RootType.Positive));
        MinimumOrMaximum(CalculateRoot(RootType.Negative));
    }
}
