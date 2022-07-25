using PhysicalQuantity;

namespace UnitOfMeasurementsTests
{
    public class ResistanceTest
    {
        Resistance _resistance = new(1);

        [Fact]
        public void 同値テスト()
        {
            Assert.Equal(1, _resistance.Value);
            Assert.Equal(0.001, new Resistance(1, SIPrefixes.Milli()).Value);
            Assert.Equal("1mΩ", new Resistance(1, SIPrefixes.Milli()).DisplayValueAndUnitSymbol(SIPrefixes.Milli()));
            Assert.Equal(1, new Resistance(new Current(1d), new Voltage(1d)).Value);
        }

        [Fact]
        public void 境界値テスト()
        {
            Assert.Equal(1000000000000000, new Resistance(1000000000000000).Value);
            Assert.Equal(1000000000000000, new Resistance(1000, SIPrefixes.Tera()).Value);
            Assert.Equal("1000TΩ", new Resistance(1000, SIPrefixes.Tera()).DisplayValueAndUnitSymbol(SIPrefixes.Tera()));

            var ex1 = Assert.Throws<ArgumentException>(() => new Resistance(1000000000000001).Value);
            Assert.Equal("抵抗値は1000[TΩ]超過は入力できません。", ex1.Message);
            var ex2 = Assert.Throws<ArgumentException>(() => new Resistance(1000.000000000001, SIPrefixes.Tera()).Value);
            Assert.Equal("抵抗値は1000[TΩ]超過は入力できません。", ex2.Message);

            Assert.Equal(0.000000000000001, new Resistance(0.000000000000001).Value);
            Assert.Equal(0.000000000000001, new Resistance(0.001, SIPrefixes.Pico()).Value);
            Assert.Equal("0.001pΩ", new Resistance(0.001, SIPrefixes.Pico()).DisplayValueAndUnitSymbol(SIPrefixes.Pico()));

            var ex3 = Assert.Throws<ArgumentException>(() => new Resistance(0.0000000000000009).Value);
            Assert.Equal("抵抗値は0.001[pΩ]未満は入力できません。", ex3.Message);
            var ex4 = Assert.Throws<ArgumentException>(() => new Resistance(0.0009, SIPrefixes.Pico()).Value);
            Assert.Equal("抵抗値は0.001[pΩ]未満は入力できません。", ex4.Message);
        }

        [Fact]
        public void 表示テスト()
        {
            Assert.Equal("Resistance", _resistance.Name);
            Assert.Equal("抵抗", _resistance.NameOfJapanese);
            Assert.Equal("R", _resistance.Symbol);
            Assert.Equal("Ω", _resistance.UnitSymbol);
            Assert.Equal("Ohm", _resistance.UnitName);

        }

        [Fact]
        public void ValueObjectイコールチェック()
        {
            Assert.True(_resistance == new Resistance(1));
            Assert.True(new Resistance(1, SIPrefixes.Milli()) == new Resistance(1, SIPrefixes.Milli()));
        }

    }
}
