namespace PhysicalQuantity
{
    internal interface IPhysicalQuantity<T>
    {
        /// <summary>
        /// 値
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// 物理量の名前
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 物理量の名前（日本語）
        /// </summary>
        public string NameOfJapanese { get; }

        /// <summary>
        /// 記号
        /// </summary>
        public string Symbol { get; }


        /// <summary>
        /// 単位の名前
        /// </summary>
        public string UnitName { get; }

        /// <summary>
        /// 単位の記号
        /// </summary>
        public string UnitSymbol { get; }


        public T Add(T addT);

        public string DisplayValue(SIPrefixes prefixes, int digits = 3);
        public string DisplayValueAndUnitSymbol(SIPrefixes prefixes, int digits = 3);

    }
}
