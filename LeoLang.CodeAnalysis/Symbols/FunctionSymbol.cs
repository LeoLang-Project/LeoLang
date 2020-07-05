using System.Collections.Immutable;

namespace LeoLang.CodeAnalysis.Symbols
{
    public sealed class FunctionSymbol : Symbol
    {
        public FunctionSymbol(string name, ImmutableArray<ParameterSymbol> parameters, TypeSymbol type)
            : base(name)
        {
            Parameter = parameters;
            Type = type;
        }

        public override SymbolKind Kind => SymbolKind.Function;

        public ImmutableArray<ParameterSymbol> Parameter { get; }
        public TypeSymbol Type { get; }
    }
}