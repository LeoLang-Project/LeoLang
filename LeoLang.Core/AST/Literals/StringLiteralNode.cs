using System;

namespace LeoLang.Core.AST.Literals
{
    public class StringLiteralNode : LiteralNode<string>
    {
        public StringLiteralNode(string value) : base(value)
        {
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}