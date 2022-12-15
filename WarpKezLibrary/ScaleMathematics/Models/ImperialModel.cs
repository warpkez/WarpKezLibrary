
namespace WarpKezLibrary.ScaleMathematics.Models;

public class ImperialModel
{
    public int id { get; set; } = 0;
    public double Feet { get; set; } = 0.0;
    public double Inches { get; set; } = 0.0;
    public int Numerator { get; set; } = 0;
    public int Denominator { get; set; } = 0;
    public double Scale { get; set; } = 0.0;
    public double ScaleMM { get; set; } = 0.0;

    public double ScaleInches => Math.Round(ScaleMM / 25.4, 3);
    //public double ScaleInches { get; set; } = 0.0;
    public string Message { get; set; } = string.Empty;
}
