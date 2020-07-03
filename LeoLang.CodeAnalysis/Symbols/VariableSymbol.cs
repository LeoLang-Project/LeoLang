using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLang.CodeAnalysis.Symbols
{
    public sealed class VariableSymbol
    {
        public VariableSymbol(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public Type Type { get; }
    }
}