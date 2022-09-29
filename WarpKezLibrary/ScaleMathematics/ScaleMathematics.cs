using WarpKezLibrary.Mathematics;

namespace WarpKezLibrary.ScaleMathematics;

public class ScaleMaths
{
    private int _DecimalPrecision = 0;

    private double FeetToMillimeters(double feet) => (FeetToInches(feet)) * 25.4;
    private double FeetToInches(double feet) => (feet * 12.0);
    private double InchesToMillimeters(double inches) => inches * 25.4;

    public double MetersToMillimeters(double meters) => meters * 1000;
    public double CentimetersToMillimeters(double centimeters) => centimeters * 10;

    /// <summary>
    /// Constructor to set the number of decimal places return by Math.Round. 
    /// </summary>
    /// <param name="decimalPrecision"></param>
    public ScaleMaths(int decimalPrecision)
    {
        if (decimalPrecision < 0)
            throw new Exception("Must not be a negative number.");

        if (decimalPrecision > 10)
            throw new Exception("Precision too high. Between 1 and 4 is realistic, 10 decimal places is the maximum.");

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
            case Metrics.Meters:
                result = Math.Round(MetersToMillimeters(measurement) / scale, _DecimalPrecision);
                break;
            case Metrics.Centimeters:
                result = Math.Round(CentimetersToMillimeters(measurement) / scale, _DecimalPrecision);
                break;
            case Metrics.Millimeters:
                result = Math.Round((measurement) / scale, _DecimalPrecision);
                break;
        }

        return result;
    }

    public MetricModel MetricToScaleMM(Metrics metrics, double measurement, double scale)
    {
        MetricModel mm = new();

        switch (metrics)
        {
            case Metrics.Meters:
                mm.Metre = measurement;
                mm.ScaleMM = ScaledMillmeters(metrics, measurement, scale);
                break;
            case Metrics.Centimeters:
                mm.Centimetre = measurement;
                mm.ScaleMM = ScaledMillmeters(metrics, measurement, scale);
                break;
            case Metrics.Millimeters:
                mm.Millimetre = measurement;
                mm.ScaleMM = ScaledMillmeters(metrics, measurement, scale);
                break;
        }

        mm.Scale = scale;

        return mm;
    }

    public ScaleModel ImperialToScaleMM(double feet, double inches, double scale)
    {
        ScaleModel model = new();

        model.feet = feet;
        model.inches = inches;
        model.scale = scale;

        double _inches = FeetToInches(feet);
        model.scaleMM = ScaledMillmeters(Metrics.Inches, (inches + _inches), scale);

        return model;
    }

    public List<InchTable> InchesTable(double _inches, double _scale, int fraction)
    {
        List<InchTable> list = new List<InchTable>();
        InchTable _holder = new()
        {
            id = 0,
            inches = _inches,
            numerator = 0,
            denominator = 0,
            scale = _scale,
            scaleMM = ScaledMillmeters(Metrics.Inches, _inches, _scale)
        };

        list.Add(_holder);
        for (int i = 1; i < fraction; i++)
        {
            Mathmatics m = new();
            var simplified = m.SimplifiedFraction(i, fraction);

            _holder = new()
            {
                id = i,
                inches = _inches,
                numerator = simplified.numerator,
                denominator = simplified.denominator,
                scale = _scale,
                scaleMM = ScaledMillmeters(Metrics.Inches, (double)_inches + ((double)i / (double)fraction), _scale)
            };
            list.Add(_holder);
        }

        _holder = new()
        {
            id = list.Count(),
            inches = _inches + 1,
            numerator = 0,
            denominator = 0,
            scale = _scale,
            scaleMM = ScaledMillmeters(Metrics.Inches, _inches + 1, _scale)
        };

        list.Add(_holder);
        return list;
    }

    public List<FeetTable> FeetTable (double _feet, double _scale)
    {
        List<FeetTable> list = new List<FeetTable>();
        FeetTable _holder = new()
        { 
            id =0,
            feet = _feet,
            inches = 0,
            scale = _scale,
            scaleMM = ScaledMillmeters(Metrics.Feet, _feet, _scale)
        };

        list.Add(_holder);
        for (int i=1; i < 12; i++)
        {
            _holder = new()
            { 
                id = i,
                feet = _feet,
                scale = _scale,
                inches = i,
                scaleMM = ScaledMillmeters(Metrics.Inches, (FeetToInches(_feet)+i), _scale)
            };

            list.Add(_holder);
        }

        _holder = new()
        {
            id = list.Count(),
            feet = _feet + 1,
            inches = 0,
            scale = _scale,
            scaleMM = ScaledMillmeters(Metrics.Feet, _feet +1, _scale)
        };
        
        list.Add(_holder);

        return list;
    }
}
