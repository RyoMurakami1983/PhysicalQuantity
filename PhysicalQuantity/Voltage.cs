namespace PhysicalQuantity
{
    /// <summary>
    /// 電圧
    /// </summary>
    public record Voltage:IPhysicalQuantity<Voltage>
    {

        public Voltage(double volt)
        {
            Value = volt;
            PhysicalQuantityStaticLogics.InputGuard(Value, NameOfJapanese, UnitSymbol);
        }

        public Voltage(double volt, SIPrefixes siPrefixes)
        {
            Value = volt*siPrefixes.Value;
            PhysicalQuantityStaticLogics.InputGuard(Value, NameOfJapanese, UnitSymbol);
        }

        public Voltage(Resistance resistance, Current current)
        {
            Value = resistance.Value * current.Value;
        }

        public Voltage(Power power, Current current)
        {
            Value = power.Value / current.Value;
        }

        public Voltage Add(Voltage addVoltage)
        {
            
            return new Voltage(Value + addVoltage.Value);
        }

        public double Value { get; }
        public string Symbol { get; } = "V";

        public string UnitSymbol { get; } = "V";

        public string Name { get; } = nameof(Voltage);
        public string NameOfJapanese { get; } = "電圧";

        public string UnitName => "Volt";

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
