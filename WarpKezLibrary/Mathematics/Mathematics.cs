namespace WarpKezLibrary.Mathematics;

/// <summary>
/// Mathmatical methods
/// </summary>
public class Mathematicals
{
    /// <summary>
    /// Returns a complex fraction from a compound fraction
    /// </summary>
    /// <param name="simplifiedFraction"></param>
    /// <returns></returns>
    public ComplexFractionModel ComplexFraction(CompoundFractionModel simplifiedFraction)
    {
        ComplexFractionModel _complexFractionModel = new()
        {
            numerator = (simplifiedFraction.unit * simplifiedFraction.denominator) + simplifiedFraction.numerator,
            denominator = simplifiedFraction.denominator
        };

        return _complexFractionModel;
    }

    /// <summary>
    /// Returns a complex fraction from a compound fraction
    /// </summary>
    /// <param name="Unit"></param>
    /// <param name="Numerator"></param>
    /// <param name="Denominator"></param>
    /// <returns></returns>
    public ComplexFractionModel ComplexFraction(int Unit, int Numerator, int Denominator)
    {
        ComplexFractionModel _complexFractionModel = new()
        {
            numerator = (Unit * Denominator) + Numerator,
            denominator = Denominator
        };

        return _complexFractionModel;
    }

    /// <summary>
    /// Returns a compound fraction when passed a complex fraction (note: not optimised for lowest common denominator)
    /// </summary>
    /// <param name="complexFraction"></param>
    /// <returns></returns>
    public CompoundFractionModel CompountFraction(ComplexFractionModel complexFraction)
    {
        CompoundFractionModel _compoundFraction = new();
        int _unit = Math.Abs(complexFraction.numerator / complexFraction.denominator);
        _compoundFraction.unit = _unit;
        _compoundFraction.numerator = complexFraction.numerator - (_unit * complexFraction.denominator);
        _compoundFraction.denominator = complexFraction.denominator;


        return _compoundFraction;
    }

    /// <summary>
    /// Returns a compound fraction when passed a complex fraction (note: not optimised for lowest common denominator)
    /// </summary>
    /// <param name="Numerator"></param>
    /// <param name="Denominator"></param>
    /// <returns></returns>
    public CompoundFractionModel CompountFraction(int Numerator, int Denominator)
    {
        CompoundFractionModel _compoundFraction = new();
        int _unit = Math.Abs(Numerator / Denominator);
        _compoundFraction.unit = _unit;
        _compoundFraction.numerator = Numerator - (_unit * Denominator);
        _compoundFraction.denominator = Denominator;


        return _compoundFraction;
    }

    /// <summary>
    /// Returns a simplified or compound fraction.
    /// </summary>
    /// <param name="numerator"></param>
    /// <param name="denominator"></param>
    /// <returns></returns>
    public CompoundFractionModel SimplifiedFraction(int numerator, int denominator)
    {
        int HighComDivisor = 0;
        int[] values = new int[2];
        CompoundFractionModel simplifiedFraction = new();

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

