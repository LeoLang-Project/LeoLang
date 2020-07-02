using System;

namespace LeoLang.CodeAnalysis.Binding
{
    internal class BoundAssignmentExpression : BoundExpression
    {

        public BoundAssignmentExpression(string name, BoundExpression boundExpression)
        {
            Name = name;
            Expression = boundExpression;
        }

        public override Type Type => Expression.Type;

        public override BoundNodeKind Kind => BoundNodeKind.AssignmentExpression;

        public string Name { get; }
        public BoundExpression Expression { get; }
    }
}