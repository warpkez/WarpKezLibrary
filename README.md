### WarpKezLibrary

#### GuidTools

- public string Guid2URL(Guid guid)
- public string GuidToURL(Guid guid)
- public Guid URLtoGuid(string url)
- public Guid GenerateGUID()

#### JSONTools

- public string ToJson<T>(T model)
- public T FromJson<T>(string json)

#### Mathematicals

- RightAngleTriangleTestValues
- SimplifiedFractionModel
- RightAngleTriangleModel

- public SimplifiedFractionModel SimplifiedFraction(int numerator, int denominator)
- public double RightAngleTriangleOpposite(double hypotenuse, double adjacent)
- public double RightAngleTriangleAdjacent(double hypotenuse, double opposite)
- public double RightAngleTriangleHypotenuse(double adjacent, double opposite)
- public double SinA(double opposite, double hypotenuse)
- public double CosA(double adjacent, double hypotenuse)
- public double TanA(double opposite, double adjacent)
- public double ArcSinA(double opposite, double hypotenuse)
- public double ArcCosA(double adjacent, double hypotenuse)
- public double ArcTanA(double opposite, double adjacent)

#### ScaleModels

- Metrics
- InchFractions
- FeetTable
- InchTable
- MetricModel
- ScaleModel
- MultiTable

#### ScaleMathematics

- public ScaleMaths(int decimalPrecision)
- public ScaleMaths()
- public MetricModel MetricToScaleMM(Metrics metrics, double measurement, double scale)
- public ScaleModel ImperialToScaleMM(double feet, double inches, double scale)
- public List<InchTable> InchesTable(double _inches, double _scale, InchFractions _fraction)
- public List<InchTable> InchesTable(double _inches, double _scale, int fraction)
- public List<FeetTable> FeetTable (double _feet, double _scale)
- public List<MultiTable> MultiScaleTable (int feet)