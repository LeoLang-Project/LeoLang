namespace LeoLang.Core.AST
{
    public class MethodDefinitionNode : SyntaxNode
    {
        public SyntaxNode Body { get; set; }
        public string Name { get; set; }
        public string ReturnType { get; set; }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}