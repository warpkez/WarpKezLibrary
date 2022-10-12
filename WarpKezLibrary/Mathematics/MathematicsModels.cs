namespace WarpKezLibrary.Mathematics;

/// <summary>
/// Basics of Pythagorean theorem a^2 + b^2 = c^2
/// </summary>
enum RightAngleTriangleTestValues
{
    Adjacent = 3,
    Opposite = 4,
    Hypotenuse = 5
}

/// <summary>
/// Model for fractions
/// </summary>
public class CompoundFractionModel
{
    public int unit { get; set; }
    public int numerator { get; set; }
    public int denominator { get; set; }
}

/// <summary>
/// Model for compound fractions
/// </summary>
public class ComplexFractionModel
{
    public int numerator { get; set; }
    public int denominator { get; set; }
}

/// <summary>
/// Model for a Right Angle Triangle
/// </summary>
public class RightAngleTriangleModel
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
