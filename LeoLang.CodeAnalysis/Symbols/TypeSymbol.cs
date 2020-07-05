namespace LeoLang.CodeAnalysis.Symbols
{
    public sealed class TypeSymbol : Symbol
    {
        public static readonly TypeSymbol Bool = new TypeSymbol("bool");
        public static readonly TypeSymbol Int = new TypeSymbol("int");
        public static readonly TypeSymbol String = new TypeSymbol("string");
        public static readonly TypeSymbol Symbol = new TypeSymbol("symbol");
        public static readonly TypeSymbol Some = new TypeSymbol("some");
        public static readonly TypeSymbol Any = new TypeSymbol("any");
        public static readonly TypeSymbol Type = new TypeSymbol("type");
        public static readonly TypeSymbol Void = new TypeSymbol("void");
        public static readonly TypeSymbol Error = new TypeSymbol("?");

        private TypeSymbol(string name)
            : base(name)
        {
        }

        public override SymbolKind Kind => SymbolKind.Type;
    }
}