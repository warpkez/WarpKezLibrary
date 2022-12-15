using WarpKezLibrary.Mathematics;
using WarpKezLibrary.ScaleMathematics.Models;

namespace WarpKezLibrary.ScaleMathematics;

/// <summary>
/// Definitions of current supported metrics
/// </summary>
public enum Metrics
{
    Feet,
    Inches,
    Metres,
    Centimetres,
    Millimetres
}

/// <summary>
/// Supported Fractions
/// </summary>
public enum InchFractions
{
    One = 1,
    Half = 2,
    Quarter = 4,
    Eigth = 8,
    Sixteenth = 16,
    Thirty2nd = 32,
    Sixty4th = 64
}

/// <summary>
/// Mathematica routines for scale modeling
/// </summary>
public class ScaleMaths
{
    private int _DecimalPrecision = 0;

    private double FeetToMillimeters(double feet) => (FeetToInches(feet)) * 25.4;
    private double FeetToInches(double feet) => (feet * 12.0);
    private double InchesToMillimeters(double inches) => inches * 25.4;

    private double MetersToMillimeters(double meters) => meters * 1000;
    private double CentimetersToMillimeters(double centimeters) => centimeters * 10;

    /// <summary>
    /// Constructor to set the number of decimal places return by Math.Round. 
    /// </summary>
    /// <param name="decimalPrecision"></param>
    public ScaleMaths(int decimalPrecision)
    {
        if (decimalPrecision < 0)
            decimalPrecision *= -1;

        if (decimalPrecision > 10)
            decimalPrecision = 10;

        _DecimalPrecision = decimalPrecision;
    }

    /// <summary>
    /// Constructor to set the number of decimal places return by Math.Round to 2.
    /// </summary>
    public ScaleMaths()
    {
        _DecimalPrecision = 2;
    }

    private double ScaledMillmeters(Metrics metric, double measurement, double scale)
    {
        double result = 0.0;

        switch (metric)
        {
            case Metrics.Feet:
                result = Math.Round(FeetToMillimeters(measurement) / scale, _DecimalPrecision);
                break;
            case Metrics.Inches:
                result = Math.Round(InchesToMillimeters(measurement) / scale, _DecimalPrecision);
                break;
            case Metrics.Metres:
                result = Math.Round(MetersToMillimeters(measurement) / scale, _DecimalPrecision);
                break;
            case Metrics.Centimetres:
                result = Math.Round(CentimetersToMillimeters(measurement) / scale, _DecimalPrecision);
                break;
            case Metrics.Millimetres:
                result = Math.Round((measurement) / scale, _DecimalPrecision);
                break;
        }

        return result;
    }

    /// <summary>
    /// Converts metric real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="metrics"></param>
    /// <param name="measurement"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public MetricModel MetricToScaleMM(Metrics metrics, double measurement, double scale)
    {
        MetricModel mm = new();

        switch (metrics)
        {
            case Metrics.Metres:
                mm.Meters = measurement;
                mm.ScaleMM = ScaledMillmeters(metrics, measurement, scale);
                break;
            case Metrics.Centimetres:
                mm.Centimeters = measurement;
                mm.ScaleMM = ScaledMillmeters(metrics, measurement, scale);
                break;
            case Metrics.Millimetres:
                mm.Millimeters = measurement;
                mm.ScaleMM = ScaledMillmeters(metrics, measurement, scale);
                break;
        }

        mm.Scale = scale;

        return mm;
    }

    /// <summary>
    /// Converts Imperial real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="feet"></param>
    /// <param name="inches"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public ImperialModel ImperialToScaleMM(double feet, double inches, double scale)
    {
        ImperialModel model = new()
        {
            Feet = feet,
            Inches = inches,
            Scale = scale
        };

        double _inches = FeetToInches(feet);
        model.ScaleMM = ScaledMillmeters(Metrics.Inches, (inches + _inches), scale);

        return model;
    }

    /// <summary>
    /// Converts Imperial Inches real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="_inches"></param>
    /// <param name="_scale"></param>
    /// <param name="_fraction"></param>
    /// <returns></returns>
    public List<ImperialModel> InchesTable(double _inches, double _scale, InchFractions _fraction)
    {
        List<ImperialModel> list = new();
        ImperialModel _holder = new()
        {
            id = 0,
            Inches = _inches,
            Numerator = 0,
            Denominator = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Inches, _inches, _scale)
        };

        int fraction = (int)_fraction;

        list.Add(_holder);
        for (int i = 1; i < fraction; i++)
        {
            Mathematicals m = new();
            var simplified = m.SimplifiedFraction(i, fraction);

            _holder = new()
            {
                id = i,
                Inches = _inches,
                Numerator = simplified.numerator,
                Denominator = simplified.denominator,
                Scale = _scale,
                ScaleMM = ScaledMillmeters(Metrics.Inches, (double)_inches + ((double)i / (double)fraction), _scale)
            };
            list.Add(_holder);
        }

        _holder = new()
        {
            id = list.Count,
            Inches = _inches + 1,
            Numerator = 0,
            Denominator = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Inches, _inches + 1, _scale)
        };

        list.Add(_holder);
        return list;
    }

    /// <summary>
    /// Converts Imperial Inches real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="_inches"></param>
    /// <param name="_scale"></param>
    /// <param name="fraction"></param>
    /// <returns></returns>
    public List<ImperialModel> InchesTable(double _inches, double _scale, int fraction)
    {
        List<ImperialModel> list = new();
        ImperialModel _holder = new()
        {
            id = 0,
            Inches = _inches,
            Numerator = 0,
            Denominator = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Inches, _inches, _scale)
        };

        list.Add(_holder);
        for (int i = 1; i < fraction; i++)
        {
            Mathematicals m = new();
            var simplified = m.SimplifiedFraction(i, fraction);

            _holder = new()
            {
                id = i,
                Inches = _inches,
                Numerator = simplified.numerator,
                Denominator = simplified.denominator,
                Scale = _scale,
                ScaleMM = ScaledMillmeters(Metrics.Inches, (double)_inches + ((double)i / (double)fraction), _scale)
            };
            list.Add(_holder);
        }

        _holder = new()
        {
            id = list.Count,
            Inches = _inches + 1,
            Numerator = 0,
            Denominator = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Inches, _inches + 1, _scale)
        };

        list.Add(_holder);
        return list;
    }


    /// <summary>
    /// Converts Imperial Feet real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="_feet"></param>
    /// <param name="_scale"></param>
    /// <returns></returns>
    public List<ImperialModel> FeetTable(double _feet, double _scale)
    {
        List<ImperialModel> list = new();
        ImperialModel _holder = new()
        {
            id = 0,
            Feet = _feet,
            Inches = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Feet, _feet, _scale)
        };

        list.Add(_holder);

        for (int i = 1; i < 12; i++)
        {
            _holder = new()
            {
                id = i,
                Feet = _feet,
                Scale = _scale,
                Inches = i,
                ScaleMM = ScaledMillmeters(Metrics.Inches, (FeetToInches(_feet) + i), _scale)
            };

            list.Add(_holder);
        }

        _holder = new()
        {
            id = list.Count,
            Feet = _feet + 1,
            Inches = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Feet, _feet + 1, _scale)
        };

        list.Add(_holder);

        return list;
    }

    /// <summary>
    /// Generates a table across multiple scales for a given footage
    /// </summary>
    /// <param name="feet"></param>
    /// <returns></returns>
    public List<MultiScaleModel> MultiScaleTable(int feet)
    {
        List<MultiScaleModel> list = new();
        MultiScaleModel _holder = new()
        {
            Feet = feet,
            Inches = 0,
            id = list.Count,
            Scale160 = ScaledMillmeters(Metrics.Feet, feet, 160),
            Scale120 = ScaledMillmeters(Metrics.Feet, feet, 120),
            Scale87 = ScaledMillmeters(Metrics.Feet, feet, 87),
            Scale76 = ScaledMillmeters(Metrics.Feet, feet, 76),
            Scale64 = ScaledMillmeters(Metrics.Feet, feet, 64),
            Scale48 = ScaledMillmeters(Metrics.Feet, feet, 48)
        };

        list.Add(_holder);

        for (int inch = 1; inch < 12; inch++)
        {
            _holder = new()
            {
                id = inch,
                Feet = feet,
                Inches = inch,

                Scale160 = ScaledMillmeters(Metrics.Inches, (FeetToInches(feet) + inch), 160),
                Scale120 = ScaledMillmeters(Metrics.Inches, (FeetToInches(feet) + inch), 120),
                Scale87 = ScaledMillmeters(Metrics.Inches, (FeetToInches(feet) + inch), 87),
                Scale76 = ScaledMillmeters(Metrics.Inches, (FeetToInches(feet) + inch), 76),
                Scale64 = ScaledMillmeters(Metrics.Inches, (FeetToInches(feet) + inch), 64),
                Scale48 = ScaledMillmeters(Metrics.Inches, (FeetToInches(feet) + inch), 48)
            };

            list.Add(_holder);
        }

        _holder = new()
        {
            Feet = feet + 1,
            Inches = 0,
            id = list.Count,
            Scale160 = ScaledMillmeters(Metrics.Feet, feet + 1, 160),
            Scale120 = ScaledMillmeters(Metrics.Feet, feet + 1, 120),
            Scale87 = ScaledMillmeters(Metrics.Feet, feet + 1, 87),
            Scale76 = ScaledMillmeters(Metrics.Feet, feet + 1, 76),
            Scale64 = ScaledMillmeters(Metrics.Feet, feet + 1, 64),
            Scale48 = ScaledMillmeters(Metrics.Feet, feet + 1, 48)
        };

        list.Add(_holder);

        return list;
    }
}