using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLang.Core.AST
{
    public class ParameterListDefinitionNode : SyntaxNode
    {
        public List<SyntaxNode> Parameters { get; set; } = new List<SyntaxNode>();

        public ParameterListDefinitionNode(List<SyntaxNode> parameters)
        {
            Parameters = parameters;
        }

        public ParameterListDefinitionNode(SyntaxNode p)
        {
            Parameters.Add(p);
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public SyntaxNode Concat(SyntaxNode p)
        {
            Parameters.Add(p);

            return this;
        }
    }
}