using LeoLang.CodeAnalysis.Diagnostics;
using LeoLang.CodeAnalysis.Symbols;
using System.Collections.Immutable;

namespace LeoLang.CodeAnalysis.Binding
{
    internal sealed class BoundProgram
    {
        public BoundProgram(BoundGlobalScope globalScope, DiagnosticBag diagnostics, ImmutableDictionary<FunctionSymbol, BoundBlockStatement> functionBodies)
        {
            GlobalScope = globalScope;
            Diagnostics = diagnostics;
            FunctionBodies = functionBodies;
        }

        public BoundGlobalScope GlobalScope { get; }
        public DiagnosticBag Diagnostics { get; }
        public ImmutableDictionary<FunctionSymbol, BoundBlockStatement> FunctionBodies { get; }
    }
}