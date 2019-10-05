namespace LeoLang.Core.AST
{
    public class MethodDefinitionNode : SyntaxNode
    {
        public SyntaxNode Body { get; set; }

        public string Name { get; set; }

        public string ReturnType { get; set; }

        public MethodDefinitionNode(string name, string returnType, SyntaxNode body)
        {
            Name = name;
            ReturnType = returnType;
            Body = body;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}