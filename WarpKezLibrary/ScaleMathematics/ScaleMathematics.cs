using WarpKezLibrary.Mathematics;

namespace WarpKezLibrary.ScaleMathematics;

/// <summary>
/// Mathematica routines for scale modeling
/// </summary>
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
                mm.Metre = measurement;
                mm.ScaleMM = ScaledMillmeters(metrics, measurement, scale);
                break;
            case Metrics.Centimetres:
                mm.Centimetre = measurement;
                mm.ScaleMM = ScaledMillmeters(metrics, measurement, scale);
                break;
            case Metrics.Millimetres:
                mm.Millimetre = measurement;
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
    public ScaleModel ImperialToScaleMM(double feet, double inches, double scale)
    {
        ScaleModel model = new()
        {
            feet = feet,
            inches = inches,
            scale = scale
        };

        double _inches = FeetToInches(feet);
        model.scaleMM = ScaledMillmeters(Metrics.Inches, (inches + _inches), scale);

        return model;
    }

    /// <summary>
    /// Converts Imperial Inches real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="_inches"></param>
    /// <param name="_scale"></param>
    /// <param name="_fraction"></param>
    /// <returns></returns>
    public List<InchTable> InchesTable(double _inches, double _scale, InchFractions _fraction)
    {
        List<InchTable> list = new();
        InchTable _holder = new()
        {
            id = 0,
            inches = _inches,
            numerator = 0,
            denominator = 0,
            scale = _scale,
            scaleMM = ScaledMillmeters(Metrics.Inches, _inches, _scale)
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
            id = list.Count,
            inches = _inches + 1,
            numerator = 0,
            denominator = 0,
            scale = _scale,
            scaleMM = ScaledMillmeters(Metrics.Inches, _inches + 1, _scale)
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
    public List<InchTable> InchesTable(double _inches, double _scale, int fraction)
    {
        List<InchTable> list = new();
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
            Mathematicals m = new();
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
            id = list.Count,
            inches = _inches + 1,
            numerator = 0,
            denominator = 0,
            scale = _scale,
            scaleMM = ScaledMillmeters(Metrics.Inches, _inches + 1, _scale)
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
    public List<FeetTable> FeetTable (double _feet, double _scale)
    {
        List<FeetTable> list = new();
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
            id = list.Count,
            feet = _feet + 1,
            inches = 0,
            scale = _scale,
            scaleMM = ScaledMillmeters(Metrics.Feet, _feet +1, _scale)
        };
        
        list.Add(_holder);

        return list;
    }

    public List<MultiTable> MultiScaleTable (int feet)
    {
        List<MultiTable> list = new();
        MultiTable _holder = new()
        { feet = feet, inches = 0,
          id = list.Count,
          scale160 = ScaledMillmeters(Metrics.Feet, feet, 160),
          scale87 = ScaledMillmeters(Metrics.Feet, feet, 87),
          scale76 = ScaledMillmeters(Metrics.Feet, feet, 76),
          scale64 = ScaledMillmeters(Metrics.Feet, feet, 64),
          scale48 = ScaledMillmeters(Metrics.Feet, feet, 48)          
        };

        list.Add(_holder);
        
        for (int inch = 1; inch < 12; inch ++)
        {
            _holder = new()
            {
                id = inch,
                feet = feet,
                inches = inch,

                scale160 = ScaledMillmeters(Metrics.Inches, (FeetToInches(feet) + inch), 160),
                scale87 = ScaledMillmeters(Metrics.Inches, (FeetToInches(feet) + inch), 87),
                scale76 = ScaledMillmeters(Metrics.Inches, (FeetToInches(feet) + inch), 76),
                scale64 = ScaledMillmeters(Metrics.Inches, (FeetToInches(feet) + inch), 64),
                scale48 = ScaledMillmeters(Metrics.Inches, (FeetToInches(feet) + inch), 48)
            };

            list.Add(_holder);
        }
        
        _holder = new()
        {
            feet = feet + 1,
            inches = 0,
            id = list.Count,
            scale160 = ScaledMillmeters(Metrics.Feet, feet + 1, 160),
            scale87 = ScaledMillmeters(Metrics.Feet, feet +1, 87),
            scale76 = ScaledMillmeters(Metrics.Feet, feet +1, 76),
            scale64 = ScaledMillmeters(Metrics.Feet, feet +1, 64),
            scale48 = ScaledMillmeters(Metrics.Feet, feet +1, 48)            
        };

        list.Add(_holder);

        return list;
    }
}