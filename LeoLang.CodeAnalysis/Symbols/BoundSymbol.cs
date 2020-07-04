namespace LeoLang.CodeAnalysis.Symbols
{
    internal sealed class BoundSymbol
    {
        internal BoundSymbol(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString() => Name;
    }
}