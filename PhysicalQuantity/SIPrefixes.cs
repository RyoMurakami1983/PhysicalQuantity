using System.Collections.Generic;

namespace PhysicalQuantity
{
    //public enum SIPrefixes
    //{
    //    Non,
    //    Pico,
    //    Nano,
    //    Micro,
    //    Milli,
    //    Centi,
    //    Deci,
    //    Deca,
    //    Hecto,
    //    Kilo,
    //    Mega,
    //    Giga,
    //    Tera,
    //}
    public class SIPrefixes
    {
        private SIPrefixes(string symbol, double value)
        {
            Symbol = symbol;
            Value = value;
        }

        public string Symbol { get; }
        public double Value { get; }

        public static SIPrefixes Pico()
        {
            return new SIPrefixes("p", Math.Pow(10, -12));
        }

        public static SIPrefixes Nano()
        {
            return new SIPrefixes("n", Math.Pow(10, -9));
        }

        public static SIPrefixes Micro()
        {
            return new SIPrefixes("u", Math.Pow(10, -6));
        }

        public static SIPrefixes Milli()
        {
            return new SIPrefixes("m", Math.Pow(10, -3));
        }

        public static SIPrefixes Centi()
        {
            return new SIPrefixes("c", Math.Pow(10, -2));
        }

        public static SIPrefixes Deci()
        {
            return new SIPrefixes("d", Math.Pow(10, -1));
        }

        public static SIPrefixes Deca()
        {
            return new SIPrefixes("da", Math.Pow(10, 1));
        }

        public static SIPrefixes Hecto()
        {
            return new SIPrefixes("h", Math.Pow(10, 2));
        }

        public static SIPrefixes Kilo()
        {
            return new SIPrefixes("k", Math.Pow(10, 3));
        }

        public static SIPrefixes Mega()
        {
            return new SIPrefixes("M", Math.Pow(10, 6));
        }

        public static SIPrefixes Giga()
        {
            return new SIPrefixes("G", Math.Pow(10, 9));
        }

        public static SIPrefixes Tera()
        {
            return new SIPrefixes("T", Math.Pow(10, 12));
        }

        public static SIPrefixes Non()
        {
            return new SIPrefixes("", 1);
        }
    }
}