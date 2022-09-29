namespace WarpKezLibrary.Mathematics;


/// <summary>
/// Demonstrates the a^2 + b^2 = c^2 of a right angle triagle
/// </summary>
enum RightAngleTriangleTestValues
{
    Adjacent = 3,
    Opposite = 4,
    Hypotenuse = 5
}

/// <summary>
/// Model for integer fractions x and y over z
/// </summary>
public class SimplifiedFractionModel
{
    public int unit { get; set; }
    public int numerator { get; set; }
    public int denominator { get; set; }
}

/// <summary>
/// Model for a Right Angle Triangle
/// </summary>
public class RightAngleTriangle
{
    /// <summary>
    /// Hypotenuse and adjacent    
    /// eg /_
    /// </summary>
    public double Angle_A { get; set; }

    /// <summary>
    /// Hypotenuse and opposite    
    /// eg /|
    /// </summary>
    public double Angle_B { get; set; }

    /// <summary>
    /// Adjacent and opposite    
    /// eg _|
    /// </summary>
    public double Angle_C { get; set; } = 90;

    public double Adjacent { get; set; }
    public double Opposite { get; set; }
    public double Hypotenuse { get; set; }
}

/// <summary>
/// Mathmatical methods
/// </summary>
public class Mathmatics
{

    /// <summary>
    /// Calculates the highest common divisor of the Numerator and Denominator in a fraction
    /// </summary>
    /// <param name="numerator"></param>
    /// <param name="denominator"></param>
    /// <returns>An Integer array containing the simplified fraction</returns>
    public SimplifiedFractionModel SimplifiedFraction(int numerator, int denominator)
    {
        int HighComDivisor = 0;
        int[] values = new int[2];
        SimplifiedFractionModel simplifiedFraction = new SimplifiedFractionModel();

        // If the numerator is 0 why are we even here then?
        if (numerator > 0)
        {
            for (int _HighComDivisor = 1; _HighComDivisor <= denominator; _HighComDivisor++)
            {
                // Check for highest common denominator if both have no remainder than _HighComDivisor is a common divisor
                if ((numerator % _HighComDivisor == 0) && (denominator % _HighComDivisor == 0))
                {
                    HighComDivisor = _HighComDivisor;
                }

                // Test if dividing by zero otherwise return the simplified fraction
                if (HighComDivisor == 0)
                {
                    values[0] = HighComDivisor;
                    values[1] = HighComDivisor;
                }
                else
                {
                    // Divide both the numerator and the denominator by the highest common divisor
                    values[0] = (numerator / HighComDivisor);
                    values[1] = (denominator / HighComDivisor);
                }
            }
        }
        else
        {
            values[0] = numerator;
            values[1] = denominator;
        }

        if (values[0] > values[1])
        {
            int unit = Math.Abs(values[0] / values[1]);
            int newNumerator = values[0] - (unit * values[1]);
            simplifiedFraction.unit = unit;
            simplifiedFraction.numerator = newNumerator;
            simplifiedFraction.denominator = values[1];
        }
        else
        {
            simplifiedFraction.unit = 0;
            simplifiedFraction.numerator = values[0];
            simplifiedFraction.denominator = values[1];
        }

        return simplifiedFraction;
    }

    /// <summary>
    /// Calculates the Opposite from the Hypotenuse and Adjacent
    /// </summary>
    /// <param name="hypotenuse"></param>
    /// <param name="adjacent"></param>
    /// <returns>The length of the Opposite line</returns>
    public double RightAngleTriangleOpposite(double hypotenuse, double adjacent) => Math.Sqrt((hypotenuse * hypotenuse) - (adjacent * adjacent));

    /// <summary>
    /// Calculates the adjacent from the Hypotenyse and Opposite
    /// </summary>
    /// <param name="hypotenuse"></param>
    /// <param name="opposite"></param>
    /// <returns>The length of the Adjacent line</returns>
    public double RightAngleTriangleAdjacent(double hypotenuse, double opposite) => Math.Sqrt((hypotenuse * hypotenuse) - (opposite * opposite));

    /// <summary>
    /// Calculates the Hypotenuse from Adjacent and Opposite
    /// </summary>
    /// <param name="adjacent"></param>
    /// <param name="opposite"></param>
    /// <returns>The length of the Hypotenuse line</returns>
    public double RightAngleTriangleHypotenuse(double adjacent, double opposite) => Math.Sqrt((adjacent * adjacent) + (opposite * opposite));

    public double SinA(double opposite, double hypotenuse) => opposite / hypotenuse;

    public double CosA(double adjacent, double hypotenuse) => adjacent / hypotenuse;

    public double TanA(double opposite, double adjacent) => opposite / adjacent;

    public double ArcSinA(double opposite, double hypotenuse) => Math.Asin(opposite / hypotenuse);

    public double ArcCosA(double adjacent, double hypotenuse) => Math.Acos(adjacent / hypotenuse);

    public double ArcTanA(double opposite, double adjacent) => Math.Atan(opposite / adjacent);
}

