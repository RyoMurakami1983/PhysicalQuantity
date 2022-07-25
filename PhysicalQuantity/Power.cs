namespace PhysicalQuantity
{
    public record Power : IPhysicalQuantity<Power>
    {
        public Power(double watt)
        {
            Value = watt;
            PhysicalQuantityStaticLogics.InputGuard(Value, NameOfJapanese, UnitSymbol);
        }

        public Power(double watt, SIPrefixes siPrefixes)
        {
            Value = watt * siPrefixes.Value;
            PhysicalQuantityStaticLogics.InputGuard(Value, NameOfJapanese, UnitSymbol);
        }

        public Power(Current current, Voltage voltage)
        {
            Value = current.Value * voltage.Value;
        }

        public double Value { get; }

        public string Name => nameof(Power);

        public string NameOfJapanese => "電力";

        public string Symbol => "P";

        public string UnitName => "Watt";

        public string UnitSymbol => "W";

        public Power Add(Power addT)
        {
            throw new NotImplementedException();
        }

        public string DisplayValue(SIPrefixes prefixes, int digits = 3)
        {
            var value = Math.Round(Value / prefixes.Value, digits, MidpointRounding.AwayFromZero);
            return value.ToString() + prefixes.Symbol;
        }

        public string DisplayValueAndUnitSymbol(SIPrefixes prefixes, int digits = 3)
        {
            return DisplayValue(prefixes, digits) + UnitSymbol;
        }
    }
}
