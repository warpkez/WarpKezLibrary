﻿namespace WarpKezLibrary.ScaleMathematics;

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
