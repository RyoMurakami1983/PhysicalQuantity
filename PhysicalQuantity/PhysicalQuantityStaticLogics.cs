namespace PhysicalQuantity
{
    internal static class PhysicalQuantityStaticLogics
    {
        internal static double CreateConstructor(double value, SIPrefixes siPrefixes)
        {
            return value * siPrefixes.Value;
        }

        internal static void InputGuard(double value,string nameOfJapanese, string unitSymbol)
        {
            if (value > 1000000000000000)
            {
                throw new ArgumentException($"{nameOfJapanese}値は1000[T{unitSymbol}]超過は入力できません。");
            }
            if (value < 0.000000000000001)
            {
                throw new ArgumentException($"{nameOfJapanese}値は0.001[p{unitSymbol}]未満は入力できません。");
            }
        }

        internal static string DisplayValue(double Value, SIPrefixes prefixes, int digits = 3)
        {
            var value = Math.Round(Value / prefixes.Value, digits, MidpointRounding.AwayFromZero);
            return value.ToString() + prefixes.Symbol;
        }

        internal static string DisplayValueAndUnitSymbol(double Value, string unitSymbol, SIPrefixes prefixes, int digits = 3)
        {

            return DisplayValue(Value, prefixes, digits) + unitSymbol;
        }
    }
}
