namespace PhysicalQuantity
{
    public record Resistance : IPhysicalQuantity<Resistance>
    {
        public Resistance(double ohm)
        {
            Value = ohm;
            PhysicalQuantityStaticLogics.InputGuard(Value, NameOfJapanese, UnitSymbol);
        }

        public Resistance(double ohm, SIPrefixes siPrefixes)
        {
            Value = ohm * siPrefixes.Value;
            PhysicalQuantityStaticLogics.InputGuard(Value, NameOfJapanese, UnitSymbol);
        }

        public Resistance(Current current, Voltage voltage)
        {
            Value = voltage.Value / current.Value;
        }

        public double Value { get; }

        public string Name => nameof(Resistance);

        public string NameOfJapanese => "抵抗";

        public string Symbol => "R";

        public string UnitName => "Ohm";

        public string UnitSymbol => "Ω";

        public Resistance Add(Resistance addT)
        {
            throw new NotImplementedException();
        }

        public string DisplayValue(SIPrefixes prefixes, int digits = 3)
        {
            return PhysicalQuantityStaticLogics.DisplayValue(Value, prefixes, digits);
        }

        public string DisplayValueAndUnitSymbol(SIPrefixes prefixes, int digits = 3)
        {
            return PhysicalQuantityStaticLogics.DisplayValueAndUnitSymbol(Value, UnitSymbol, prefixes, digits);
        }
    }
}
