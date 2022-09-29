namespace WarpKezLibrary.ScaleMathematics;

/// <summary>
/// Definitions of current supported metrics
/// </summary>
public enum Metrics
{
    Feet,
    Inches,
    Meters,
    Centimeters,
    Millimeters
}

/// <summary>
/// Supported Fractions
/// </summary>
public enum InchFractions
{
    OneOver1 = 1,
    OneOver2 = 2,
    OneOver4 = 4,
    OneOver8 = 8,
    OneOver16 = 16,
    OneOver32 = 32,
    OneOver64 = 64
}

/// <summary>
/// Class capable of being indexed for JSON tables.
/// </summary>
public class FeetTable
{
    public int id { get; set; } = 0;
    public double feet { get; set; } = 0.0;
    public double inches { get; set; } = 0.0;
    public double scale { get; set; } = 0.0;
    public double scaleMM { get; set; } = 0.0;
    public string message { get; set; } = string.Empty;
}

/// <summary>
/// Class capable of being indexed for JSON tables.
/// </summary>
public class InchTable
{
    public int id { get; set; } = 0;
    public double inches { get; set; } = 0.0;
    public int numerator { get; set; } = 0;
    public int denominator { get; set; } = 0;
    public double scale { get; set; } = 0.0;
    public double scaleMM { get; set; } = 0.0;
    public string message { get; set; } = string.Empty;
}

/// <summary>
/// Class capable of being indexed for JSON tables.
/// </summary>
public class MetricModel
{
    public int id { get; set; } = 0;
    public double Metre { get; set; } = 0;
    public double Centimetre { get; set; } = 0;
    public double Millimetre { get; set; } = 0;
    public double Scale { get; set; } = 0.0;
    public double ScaleMM { get; set; } = 0.0;
    public string Message { get; set; } = string.Empty;
}

/// <summary>
/// Class capable of being indexed for JSON tables.
/// </summary>
public class ScaleModel
{
    public int id { get; set; } = 0;
    public double feet { get; set; } = 0;
    public double inches { get; set; } = 0;
    public double scale { get; set; } = 0.0;
    public double scaleMM { get; set; } = 0.0;
    public string message { get; set; } = string.Empty;
}
