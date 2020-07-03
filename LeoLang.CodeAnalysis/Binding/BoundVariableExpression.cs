using LeoLang.CodeAnalysis.Symbols;
using System;

namespace LeoLang.CodeAnalysis.Binding
{
    internal class BoundVariableExpression : BoundExpression
    {
        public BoundVariableExpression(VariableSymbol Variable)
        {
            this.Variable = Variable;
        }

        public override Type Type => Variable.Type;

        public override BoundNodeKind Kind => BoundNodeKind.VariableExpression;

        public VariableSymbol Variable { get; }
    }
}