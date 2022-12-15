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
- ComplexFractionModel
- SimplifiedFractionModel
- RightAngleTriangleModel

- public ComplexFractionModel ComplexFraction(CompoundFractionModel simplifiedFraction)
- public ComplexFractionModel ComplexFraction(int Unit, int Numerator, int Denominator)
- public CompoundFractionModel CompountFraction(ComplexFractionModel complexFraction)
- public CompoundFractionModel CompountFraction(int Numerator, int Denominator)
- public CompoundFractionModel SimplifiedFraction(int numerator, int denominator)
- public double RightAngleTriangleOpposite(double hypotenuse, double adjacent)
- public double RightAngleTriangleAdjacent(double hypotenuse, double opposite)
- public double RightAngleTriangleHypotenuse(double adjacent, double opposite)
- public double SinA(double opposite, double hypotenuse)
- public double CosA(double adjacent, double hypotenuse)
- public double TanA(double opposite, double adjacent)
- public double ArcSinA(double opposite, double hypotenuse)
- public double ArcCosA(double adjacent, double hypotenuse)
- public double ArcTanA(double opposite, double adjacent)


#### ImperialModel
#### MetricModel
#### MultiScaleModel

#### ScaleMathematics
- Metrics
- InchFractions

- public ScaleMaths(int decimalPrecision)
- public ScaleMaths()

- public MetricModel MetricToScaleMM(Metrics metrics, double measurement, double scale)
- public ImperialModel ImperialToScaleMM(double feet, double inches, double scale)
- public List<ImperialModel> InchesTable(double _inches, double _scale, InchFractions _fraction)
- public List<ImperialModel> InchesTable(double _inches, double _scale, int fraction)
- public List<ImperialModel> FeetTable (double _feet, double _scale)
- public List<MultiScaleModel> MultiScaleTable (int feet)