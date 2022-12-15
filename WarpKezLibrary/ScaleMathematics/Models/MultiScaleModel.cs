
namespace WarpKezLibrary.ScaleMathematics.Models;

public class MultiScaleModel
{
    public int id { get; set; } = 0;
    public double Feet { get; set; } = 0.0;
    public double Inches { get; set; } = 0.0;
    public double Scale87 { get; set; } = 0.0;      // 1:87
    public double Scale76 { get; set; } = 0.0;      // 1:76
    public double Scale64 { get; set; } = 0.0;      // 1:64
    public double Scale48 { get; set; } = 0.0;      // 1:48
    public double Scale120 { get; set; } = 0.0;     // 1:120
    public double Scale160 { get; set; } = 0.0;     // 1:160
}
