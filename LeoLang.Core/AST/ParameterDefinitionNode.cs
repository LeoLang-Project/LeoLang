namespace LeoLang.Core.AST
{
    public class ParameterDefinitionNode : SyntaxNode
    {
        public string Name { get; set; }

        public string ReturnType { get; set; }

        public ParameterDefinitionNode(string returnType, string name)
        {
            ReturnType = returnType;
            Name = name;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}