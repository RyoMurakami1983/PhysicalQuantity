using PhysicalQuantity;

namespace UnitOfMeasurementsTests
{
    public class CurrentTest
    {
        Current _current = new(1);

        [Fact]
        public void 同値テスト()
        {
            Assert.Equal(1, _current.Value);
            Assert.Equal(0.001, new Current(1, SIPrefixes.Milli()).Value);
            Assert.Equal("1mA", new Current(1, SIPrefixes.Milli()).DisplayValueAndUnitSymbol(SIPrefixes.Milli()));
            Assert.Equal(1, new Current(new Resistance(1d), new Voltage(1d)).Value);
            Assert.Equal(1, new Current(new Power(1d), new Voltage(1d)).Value);
        }

        [Fact]
        public void 境界値テスト()
        {
            Assert.Equal(1000000000000000, new Current(1000000000000000).Value);
            Assert.Equal(1000000000000000, new Current(1000, SIPrefixes.Tera()).Value);
            Assert.Equal("1000TA", new Current(1000, SIPrefixes.Tera()).DisplayValueAndUnitSymbol(SIPrefixes.Tera()));

            var ex1 = Assert.Throws<ArgumentException>(() => new Current(1000000000000001).Value);
            Assert.Equal("電流値は1000[TA]超過は入力できません。", ex1.Message);
            var ex2 = Assert.Throws<ArgumentException>(() => new Current(1000.000000000001, SIPrefixes.Tera()).Value);
            Assert.Equal("電流値は1000[TA]超過は入力できません。", ex2.Message);

            Assert.Equal(0.000000000000001, new Current(0.000000000000001).Value);
            Assert.Equal(0.000000000000001, new Current(0.001, SIPrefixes.Pico()).Value);
            Assert.Equal("0.001pA", new Current(0.001, SIPrefixes.Pico()).DisplayValueAndUnitSymbol(SIPrefixes.Pico()));

            var ex3 = Assert.Throws<ArgumentException>(() => new Current(0.0000000000000009).Value);
            Assert.Equal("電流値は0.001[pA]未満は入力できません。", ex3.Message);
            var ex4 = Assert.Throws<ArgumentException>(() => new Current(0.0009, SIPrefixes.Pico()).Value);
            Assert.Equal("電流値は0.001[pA]未満は入力できません。", ex4.Message);
        }

        [Fact]
        public void 表示テスト()
        {
            Assert.Equal("Current", _current.Name);
            Assert.Equal("電流", _current.NameOfJapanese);
            Assert.Equal("I", _current.Symbol);
            Assert.Equal("A", _current.UnitSymbol);
            Assert.Equal("Ampere", _current.UnitName);

        }

        [Fact]
        public void ValueObjectイコールチェック()
        {
            Assert.True(_current == new Current(1));
            Assert.True(new Current(1, SIPrefixes.Milli()) == new Current(1, SIPrefixes.Milli()));
        }
    }
}
