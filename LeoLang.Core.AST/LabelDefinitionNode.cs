﻿using System;

namespace LeoLang.Core.AST
{
    public class LabelDefinitionNode : SyntaxNode
    {
        public BlockNode Body { get; set; }
        public Symbol Name { get; set; }

        public LabelDefinitionNode(Symbol id)
        {
            Name = id.Name;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}