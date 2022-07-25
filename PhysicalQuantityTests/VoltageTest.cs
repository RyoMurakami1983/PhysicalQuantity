using PhysicalQuantity;

namespace UnitOfMeasurementsTests
{
    public class VoltageTest
    {
        [Fact]
        public void 同値テスト()
        {
            Assert.Equal(1, new Voltage(1).Value);
            Assert.Equal(0.001, new Voltage(1,SIPrefixes.Milli()).Value);
            Assert.Equal("1mV", new Voltage(1,SIPrefixes.Milli()).DisplayValueAndUnitSymbol(SIPrefixes.Milli()));
            Assert.Equal(1, new Voltage(new Resistance(1), new Current(1)).Value);
            Assert.Equal(1, new Voltage(new Power(1), new Current(1)).Value);
        }

        [Fact]
        public void 境界値テスト()
        {
            Assert.Equal(1000000000000000, new Voltage(1000000000000000).Value);
            Assert.Equal(1000000000000000, new Voltage(1000,SIPrefixes.Tera()).Value);
            Assert.Equal("1000TV", new Voltage(1000,SIPrefixes.Tera()).DisplayValueAndUnitSymbol(SIPrefixes.Tera()));

            var ex1 = Assert.Throws<ArgumentException>(() => new Voltage(1000000000000001).Value);
            Assert.Equal("電圧値は1000[TV]超過は入力できません。", ex1.Message);
            var ex2 = Assert.Throws<ArgumentException>(() => new Voltage(1000.000000000001, SIPrefixes.Tera()).Value);
            Assert.Equal("電圧値は1000[TV]超過は入力できません。", ex2.Message);

            Assert.Equal(0.000000000000001, new Voltage(0.000000000000001).Value);
            Assert.Equal(0.000000000000001, new Voltage(0.001, SIPrefixes.Pico()).Value);
            Assert.Equal("0.001pV", new Voltage(0.001, SIPrefixes.Pico()).DisplayValueAndUnitSymbol(SIPrefixes.Pico()));

            var ex3 = Assert.Throws<ArgumentException>(() => new Voltage(0.0000000000000009).Value);
            Assert.Equal("電圧値は0.001[pV]未満は入力できません。", ex3.Message);
            var ex4 = Assert.Throws<ArgumentException>(() => new Voltage(0.0009, SIPrefixes.Pico()).Value);
            Assert.Equal("電圧値は0.001[pV]未満は入力できません。", ex4.Message);
        }

        [Fact]
        public void 表示テスト()
        {
            Voltage voltage = new Voltage(1);
            Assert.Equal("Voltage", voltage.Name);
            Assert.Equal("電圧", voltage.NameOfJapanese);
            Assert.Equal("V", voltage.Symbol);
            Assert.Equal("V", voltage.UnitSymbol);
            Assert.Equal("Volt", voltage.UnitName);
            
        }

        [Fact]
        public void ValueObjectイコールチェック()
        {
            Assert.True(new Voltage(1) == new Voltage(1));
            Assert.True(new Voltage(1,SIPrefixes.Milli()) == new Voltage(1,SIPrefixes.Milli()));
        }
    }
}
