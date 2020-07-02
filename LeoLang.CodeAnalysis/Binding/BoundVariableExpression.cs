using System;

namespace LeoLang.CodeAnalysis.Binding
{
    internal class BoundVariableExpression : BoundExpression
    {
        private Type type;

        public BoundVariableExpression(string name, Type type)
        {
            Name = name;
            this.type = type;
        }

        public override Type Type => type;

        public override BoundNodeKind Kind => BoundNodeKind.VariableExpression;

        public string Name { get; }
    }
}