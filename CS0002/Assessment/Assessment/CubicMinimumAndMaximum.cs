namespace Assessment;

public enum RootSign
{
    Positive,
    Negative,
}

public static class CubicMinimumAndMaximum
{
    private static double GetCoefficient(string name)
    {
        double coefficient;
        while (Input.Get($"Value '{name}': ", out coefficient) == false) {
            Output.RedNL("That is not a valid number.");
        }
        return coefficient;
    }

    private static double CalculateRoot(double a, double b, double discriminant, RootSign sign)
    {
        /*
         * Calculate the positive or negative root;
         * - Instead of writing out the entire equation for both the positive and negative
         *   root, we can assign the main parts to variables and simply switch the signs
         *   around depending on which root we are finding.
         * - We can reuse the discriminant that we had predetermined in the main function
         *   as it would be wasteful to have to recalculate it again for the two times
         *   that this function is called.
         *
         *     -2b +- sqrt((2b)^2 - (4 * (3a) * c))
         * x = ------------------------------------
         *                    2 * 3a
         */
        var x = -(2 * b);
        var y = Math.Sqrt(discriminant);
        var z = (2 * 3 * a);
        return sign switch
        {
            RootSign.Positive => (x + y) / z, // notice the (x PLUS y) here
            RootSign.Negative => (x - y) / z, // v.s the (x MINUS y) here
            _ => throw new ArgumentOutOfRangeException(nameof(sign), sign, "That isn't a valid sign type.")
            // technically, the default case shouldn't ever happen as we are the only
            // ones calling this function, but it never hurts to be sure.
        };
    }

    private static void EvaluateMinimumOrMaximum(
        double a, double b, double c, double d, double discriminant, RootSign sign
    )
    {
        /*
         * We start by calculating the positive or negative root for the function's coefficients;
         * - The main function calls this function twice with differing 'sign' parameters, one
         *   for finding the positive root, and one for finding the negative.
         * - The positive and negative roots could be either the minimum or maximum of the
         *   function and this therefore avoids us having to duplicate the rest of this function
         *   for the differing roots.
         */
        var root = CalculateRoot(a, b, discriminant, sign);
        /*
         * We then calculate the 2nd derivative to determine whether or not this root is the
         * minimum or maximum of the cubic function.
         *
         * f''(x) = (6 * a * x) + (2 * b);
         */
        var secondDerivative = (6 * a * root) + (2 * b);
        /*
         * Finally, we can evaluate the function using this root to find the result of the
         * cubic function
         *
         * f(x) = a(x^3) + b(x^2) + cx + d
         */
        var result = (a * Math.Pow(root, 3)) + (b * Math.Pow(root, 2)) + (c * root) + d;

        /*
         * The 2nd derivative determines whether the root is the minimum or maximum of the cubic
         * function.
         * - If its more than zero, the root is the minimum.
         * - If its less than zero, the root is the maximum.
         * - If it is zero, the function might have an inflection point.
         */
        switch (secondDerivative) {
            case > 0:
                Output.PurpleNL("Minimum: ");
                Output.GreenNL($"x = {root:F}\nf(x) = {result:F}");
                break;
            case < 0:
                Output.PurpleNL("Maximum: ");
                Output.GreenNL($"x = {root:F}\nf(x) = {result:F}");
                break;
            default:
                Output.RedNL("The function might have an inflection point");
                break;
        }
    }

    public static void Start()
    {
        // let the user know that they will be entering their cubic function's coefficients.
        Output.BlueNL("Please enter your cubic function's coefficients:");

        /*
         * Use the helper function to read the coefficients from the users input:
         * - The value of 'a' can not be zero so we must loop until the user inputs a non-zero
         *   coefficient.
         */
        var a = GetCoefficient("a");
        while (a == 0) {
            Output.RedNL("The value of 'a' cannot be zero.");
            a = GetCoefficient("a");
        }
        var b = GetCoefficient("b");
        var c = GetCoefficient("c");
        var d = GetCoefficient("d");

        /*
         * Predetermine the discriminant of the x (root) of the function.
         * - This is used to check if the function will actually have a minimum or maximum.
         *
         * discriminant = (2b)^2 - (4 * (3a) * c)
         */
        var discriminant = Math.Pow((2 * b), 2) - (4 * (3 * a) * c);
        if (discriminant < 0) {
            Output.RedNL("\nNo Minimum and Maximum can be found for a cubic function with those coefficients.");
            return;
        }

        // newline for formatting reasons
        Console.WriteLine();
        // find the minimum and maximum for the positive and negative root of the function.
        EvaluateMinimumOrMaximum(a, b, c, d, discriminant, RootSign.Positive);
        EvaluateMinimumOrMaximum(a, b, c, d, discriminant, RootSign.Negative);
    }
}
