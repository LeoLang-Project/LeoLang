using System;
using System.Collections.Generic;
using System.Linq;
using LeoLang.CodeAnalysis.Binding;
using LeoLang.CodeAnalysis.Symbols;
using LeoLang.CodeAnalysis.Syntax;

namespace LeoLang.CodeAnalysis
{
    public sealed class Compilation
    {
        public Compilation(SyntaxTree syntaxTree, Dictionary<VariableSymbol, object> variables)
        {
            SyntaxTree = syntaxTree;
            Variables = variables;
        }

        public SyntaxTree SyntaxTree { get; }
        public Dictionary<VariableSymbol, object> Variables { get; }

        public EvaluationResult Evaluate()
        {
            var binder = new Binder(Variables);
            var boundExpression = binder.BindExpression(SyntaxTree.Root);

            var diagnostics = SyntaxTree.Diagnostics.Concat(binder.Diagnostics).ToArray();
            if (diagnostics.Any())
                return new EvaluationResult(diagnostics, null);

            var evaluator = new Evaluator(boundExpression, Variables);
            var value = evaluator.Evaluate();
            return new EvaluationResult(Array.Empty<Diagnostic>(), value);
        }
    }
}