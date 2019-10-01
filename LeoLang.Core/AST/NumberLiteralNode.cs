using System;

namespace LeoLang.Core.AST
{
    public class NumberLiteralNode : LiteralNode
    {
        public int Value { get; set; }

        public NumberLiteralNode(int value)
        {
            Value = value;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}