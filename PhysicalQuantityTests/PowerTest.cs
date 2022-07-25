using PhysicalQuantity;

namespace UnitOfMeasurementsTests
{

    public class PowerTest
    {
        Power _power = new(1);

        [Fact]
        public void 同値テスト()
        {
            Assert.Equal(1, _power.Value);
            Assert.Equal(0.001, new Power(1, SIPrefixes.Milli()).Value);
            Assert.Equal("1mW", new Power(1, SIPrefixes.Milli()).DisplayValueAndUnitSymbol(SIPrefixes.Milli()));
            Assert.Equal(1, new Power(new Current(1d), new Voltage(1d)).Value);
        }

        [Fact]
        public void 境界値テスト()
        {
            Assert.Equal(1000000000000000, new Power(1000000000000000).Value);
            Assert.Equal(1000000000000000, new Power(1000, SIPrefixes.Tera()).Value);
            Assert.Equal("1000TW", new Power(1000, SIPrefixes.Tera()).DisplayValueAndUnitSymbol(SIPrefixes.Tera()));

            var ex1 = Assert.Throws<ArgumentException>(() => new Power(1000000000000001).Value);
            Assert.Equal("電力値は1000[TW]超過は入力できません。", ex1.Message);
            var ex2 = Assert.Throws<ArgumentException>(() => new Power(1000.000000000001, SIPrefixes.Tera()).Value);
            Assert.Equal("電力値は1000[TW]超過は入力できません。", ex2.Message);

            Assert.Equal(0.000000000000001, new Power(0.000000000000001).Value);
            Assert.Equal(0.000000000000001, new Power(0.001, SIPrefixes.Pico()).Value);
            Assert.Equal("0.001pW", new Power(0.001, SIPrefixes.Pico()).DisplayValueAndUnitSymbol(SIPrefixes.Pico()));

            var ex3 = Assert.Throws<ArgumentException>(() => new Power(0.0000000000000009).Value);
            Assert.Equal("電力値は0.001[pW]未満は入力できません。", ex3.Message);
            var ex4 = Assert.Throws<ArgumentException>(() => new Power(0.0009, SIPrefixes.Pico()).Value);
            Assert.Equal("電力値は0.001[pW]未満は入力できません。", ex4.Message);
        }

        [Fact]
        public void 表示テスト()
        {
            Assert.Equal("Power", _power.Name);
            Assert.Equal("電力", _power.NameOfJapanese);
            Assert.Equal("P", _power.Symbol);
            Assert.Equal("W", _power.UnitSymbol);
            Assert.Equal("Watt", _power.UnitName);

        }

        [Fact]
        public void ValueObjectイコールチェック()
        {
            Assert.True(_power == new Power(1));
            Assert.True(new Power(1, SIPrefixes.Milli()) == new Power(1, SIPrefixes.Milli()));
        }
    }
}
