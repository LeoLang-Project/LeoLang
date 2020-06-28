using System;
using System.Linq;
using LeoLang.CodeAnalysis.Binding;
using LeoLang.CodeAnalysis.Syntax;

namespace LeoLang.CodeAnalysis
{
    public sealed class Compilation
    {
        public Compilation(SyntaxTree syntaxTree)
        {
            SyntaxTree = syntaxTree;
        }

        public SyntaxTree SyntaxTree { get; }

        public EvaluationResult Evaluate()
        {
            var binder = new Binder();
            var boundExpression = binder.BindExpression(SyntaxTree.Root);

            var diagnostics = SyntaxTree.Diagnostics.Concat(binder.Diagnostics).ToArray();
            if (diagnostics.Any())
                return new EvaluationResult(diagnostics, null);

            var evaluator = new Evaluator(boundExpression);
            var value = evaluator.Evaluate();
            return new EvaluationResult(Array.Empty<Diagnostic>(), value);
        }
    }
}