﻿using System;

namespace LeoLang.Core
{
    public abstract class LiteralNode<T> : SyntaxNode
    {
        public T Value { get; set; }

        public abstract override void Accept(Visitor visitor);

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        protected LiteralNode(T value)
        {
            Value = value;
        }
    }
}