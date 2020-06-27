using System;

namespace LLC.CodeAnalysis.Binding
{
    public abstract class BoundExpression : BoundNode
    {
        public abstract Type Type { get; }
    }
}