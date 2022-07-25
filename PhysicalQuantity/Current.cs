namespace PhysicalQuantity
{
    public record Current : IPhysicalQuantity<Current>
    {
        public Current(double ampere)
        {
            Value = ampere;
            PhysicalQuantityStaticLogics.InputGuard(Value, NameOfJapanese, UnitSymbol);
        }

        public Current(double ampere, SIPrefixes siPrefixes)
        {
            Value = ampere * siPrefixes.Value;
            PhysicalQuantityStaticLogics.InputGuard(Value, NameOfJapanese, UnitSymbol);
        }

        public Current (Resistance resistance, Voltage voltage)
        {
            Value = voltage.Value / resistance.Value;
        }

        public Current (Power power, Voltage voltage)
        {
            Value = power.Value / voltage.Value;
        }


        public double Value { get; }

        public string Name => nameof(Current);

        public string NameOfJapanese => "電流";

        public string Symbol => "I";

        public string UnitName => "Ampere";

        public string UnitSymbol => "A";

        public Current Add(Current addT)
        {
            throw new NotImplementedException();
        }

        public string DisplayValue(SIPrefixes prefixes, int digits = 3)
        {
            return PhysicalQuantityStaticLogics.DisplayValue(Value, prefixes, digits);
        }

        public string DisplayValueAndUnitSymbol(SIPrefixes prefixes, int digits = 3)
        {
            return PhysicalQuantityStaticLogics.DisplayValueAndUnitSymbol(Value,UnitSymbol,prefixes, digits);
        }
    }
}
