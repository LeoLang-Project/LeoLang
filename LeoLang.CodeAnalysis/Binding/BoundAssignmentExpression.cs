using LeoLang.CodeAnalysis.Symbols;
using System;

namespace LeoLang.CodeAnalysis.Binding
{
    internal class BoundAssignmentExpression : BoundExpression
    {

        public BoundAssignmentExpression(VariableSymbol Variable, BoundExpression boundExpression)
        {
            this.Variable = Variable;
            Expression = boundExpression;
        }

        public override TypeSymbol Type => Expression.Type;

        public override BoundNodeKind Kind => BoundNodeKind.AssignmentExpression;

        public VariableSymbol Variable { get; }
        public BoundExpression Expression { get; }
    }
}