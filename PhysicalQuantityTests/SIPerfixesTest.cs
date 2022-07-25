using PhysicalQuantity;

namespace UnitOfMeasurementsTests
{
    public class SIPerfixesTest
    {
        [Fact]
        public void SIPerfixes‚ÌƒeƒXƒg()
        {
            Assert.Equal(0.000000000001d, SIPrefixes.Pico().Value);
            Assert.Equal(0.000000001d, SIPrefixes.Nano().Value);
            Assert.Equal(0.000001d, SIPrefixes.Micro().Value);
            Assert.Equal(0.001d, SIPrefixes.Milli().Value);
            Assert.Equal(0.01d, SIPrefixes.Centi().Value);
            Assert.Equal(0.1d, SIPrefixes.Deci().Value);
            Assert.Equal(10d, SIPrefixes.Deca().Value);
            Assert.Equal(100d, SIPrefixes.Hecto().Value);
            Assert.Equal(1000d, SIPrefixes.Kilo().Value);
            Assert.Equal(1000000d, SIPrefixes.Mega().Value);
            Assert.Equal(1000000000d, SIPrefixes.Giga().Value);
            Assert.Equal(1000000000000d, SIPrefixes.Tera().Value);
            Assert.Equal(1d, SIPrefixes.Non().Value);

            Assert.Equal("p", SIPrefixes.Pico().Symbol);
            Assert.Equal("n", SIPrefixes.Nano().Symbol);
            Assert.Equal("u", SIPrefixes.Micro().Symbol);
            Assert.Equal("m", SIPrefixes.Milli().Symbol);
            Assert.Equal("c", SIPrefixes.Centi().Symbol);
            Assert.Equal("d", SIPrefixes.Deci().Symbol);
            Assert.Equal("da", SIPrefixes.Deca().Symbol);
            Assert.Equal("h", SIPrefixes.Hecto().Symbol);
            Assert.Equal("k", SIPrefixes.Kilo().Symbol);
            Assert.Equal("M", SIPrefixes.Mega().Symbol);
            Assert.Equal("G", SIPrefixes.Giga().Symbol);
            Assert.Equal("T", SIPrefixes.Tera().Symbol);
            Assert.Equal("", SIPrefixes.Non().Symbol);
        }
    }
}