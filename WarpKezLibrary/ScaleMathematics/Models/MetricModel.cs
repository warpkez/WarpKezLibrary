namespace WarpKezLibrary.ScaleMathematics.Models;

public class MetricModel
{
    public int id { get; set; } = 0;
    public double Meters { get; set; } = 0.0;
    public double Centimeters { get; set; } = 0.0;
    public double Millimeters { get; set; } = 0.0;
    public double Scale { get; set; } = 0.0;
    public double ScaleMM { get; set; } = 0.0;
    public string Message { get; set; } = string.Empty;
}
