// ReSharper disable ArrangeRedundantParentheses

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
        /*
         * Use my IO helper class method to get a number input from the user;
         * - [1] It throws an error upon invalid input which we can use to display a message for the user.
         * - [2] If an error is thrown, we continue to the next loop which asks them to input something again.
         * - [3] If an error isn't thrown, they input a valid number and we can return it to the main function.
         */
        while (true) {
            double x;
            try {
                x = IO.GetNumberInput<double>(
                    prompt: $"Value '{name}': ",
                    errorMessage: "That is not a valid number."
                );
            }
            catch (ArgumentException e) {
                IO.WriteLine($"{e.Message}\n", colour: ConsoleColor.Red);  // [1]
                continue; // [2]
            }
            return x;  // [3]
        }
    }

    private static double CalculateDiscriminant(double a, double b, double c)
    {
        /*
         * Calculate the discriminant;
         * (2b)^2 - (4 * (3a) * c)
         */
        return Math.Pow((2 * b), 2) - (4 * (3 * a) * c);
    }

    private static double CalculateRoot(double a, double b, double discriminant, RootSign sign)
    {
        /*
         * Calculate the positive or negative root;
         * - [1] Instead of writing out the entire equation for both the positive and negative
         *   root, we can assign the main parts to variables and simply switch the signs
         *   around depending on which root we are finding.
         * - [2] We can reuse the discriminant that we had predetermined in the main function as
         *   it would be wasteful to have to recalculate it again for the two times that this
         *   function is called.
         *
         * -2b +- sqrt((2b)^2 - (4 * (3a) * c))
         * ------------------------------------
         *                2 * 3a
         */

        var x = -(2 * b);
        var y = Math.Sqrt(discriminant);  // [1]
        var z = (2 * 3 * a);

        return sign switch  // [2]
        {
            RootSign.Positive => (x + y) / z,  // notice the (x PLUS y) here
            RootSign.Negative => (x - y) / z,  // v.s the (x MINUS y) here
            _ => throw new ArgumentOutOfRangeException(nameof(sign), sign, "That isn't a valid sign type.")
            // technically, the default case shouldn't ever happen as we are the
            // only ones calling this function, but it never hurts to be sure.
        };
    }

    private static double CalculateSecondDerivative(double a, double b, double root)
    {
        /*
         * Calculate the 2nd derivative;
         * f''(x) = 6ax + 2b
         */
        return (6 * a * root) + (2 * b);
    }

    private static double EvaluateFunction(double a, double b, double c, double d, double x)
    {
        /*
         * Evaluate the function using the root values of x.
         * f(x) = a(x^3) + b(x^2) + cx + d
         */
        return (a * Math.Pow(x, 3)) + (b * Math.Pow(x, 2)) + (c * x) + d;
    }

    private static void EvaluateMinimumOrMaximum(
        double a, double b, double c, double d,
        double discriminant, RootSign sign
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
         */
        var secondDerivative = CalculateSecondDerivative(a, b, root);
        /*
         * Finally, we can evaluate the function using this root to find the result of the
         * cubic function
         */
        var result = EvaluateFunction(a, b, c, d, root);

        /*
         * The 2nd derivative determines whether the root is the minimum or maximum of the cubic
         * function.
         * - If its more than zero, the root is the minimum.
         * - If its less than zero, the root is the maximum.
         * - If it is zero, the function might have an inflection point.
         */
        switch (secondDerivative) {
            case > 0:
                IO.WriteLine("Minimum: ", colour: ConsoleColor.Magenta);
                IO.WriteLine(
                    $"x = {root:F}\nf(x) = {result:F}",
                    colour: ConsoleColor.Green
                );
                break;
            case < 0:
                IO.WriteLine("Maximum: ", colour: ConsoleColor.Magenta);
                IO.WriteLine(
                    $"x = {root:F}\nf(x) = {result:F}",
                    colour: ConsoleColor.Green
                );
                break;
            default:
                IO.WriteLine(
                    "The function might have an inflection point",
                    colour: ConsoleColor.Red
                );
                break;
        }
    }

    public static void Start()
    {
        // let the user know that they will be entering their cubic function's coefficients.
        IO.WriteLine(
            "\nPlease enter your cubic function's coefficients:",
            colour: ConsoleColor.Blue
        );

        /*
         * Use the helper function to read the coefficients from the users input:
         * - The value of 'a' can not be zero so we must loop until the user inputs a non-zero
         *   coefficient.
         */
        var a = GetCoefficient("a");
        while (a == 0) {
            IO.WriteLine(
                "The value of 'a' cannot be zero.",
                colour: ConsoleColor.Red
            );
            a = GetCoefficient("a");
        }
        var b = GetCoefficient("b");
        var c = GetCoefficient("c");
        var d = GetCoefficient("d");

        /*
         * Predetermine the discriminant of the x (root) of the function.
         * - This is used to check if the function will actually have a minimum or maximum.
         */
        var discriminant = CalculateDiscriminant(a, b, c);
        if (discriminant < 0) {
            IO.WriteLine(
                "\nNo Minimum and Maximum can be found for a function with those coefficients.\n",
                colour: ConsoleColor.Red
            );
            return;
        }

        // newline for formatting reasons
        Console.WriteLine();
        // find the minimum and maximum for the positive and negative root of the function.
        EvaluateMinimumOrMaximum(a, b, c, d, discriminant, RootSign.Positive);
        EvaluateMinimumOrMaximum(a, b, c, d, discriminant, RootSign.Negative);
        // newline for formatting reasons
        Console.WriteLine();
    }
}
