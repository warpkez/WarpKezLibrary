namespace WarpKezLibrary.ScaleMathematics;

public enum Metrics
{
    Feet,
    Inches,
    Meters,
    Centimeters,
    Millimeters
}

public enum InchFractions
{
    Full = 1,
    Half = 2,
    Quarter = 4,
    Eigth = 8,
    Sixtenth = 16,
}

public class FeetTable
{
    public int id { get; set; } = 0;
    public double feet { get; set; } = 0.0;
    public double inches { get; set; } = 0.0;
    public double scale { get; set; } = 0.0;
    public double scaleMM { get; set; } = 0.0;
    public string message { get; set; } = string.Empty;
}

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

public class ScaleModel
{
    public int id { get; set; } = 0;
    public double feet { get; set; } = 0;
    public double inches { get; set; } = 0;
    public double scale { get; set; } = 0.0;
    public double scaleMM { get; set; } = 0.0;
    public string message { get; set; } = string.Empty;
}
