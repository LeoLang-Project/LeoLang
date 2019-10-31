namespace LeoLang.Core.AST
{
    public class PairSyntaxNode : SyntaxNode
    {
        public SyntaxNode Key { get; set; }

        public SyntaxNode Value { get; set; }

        public PairSyntaxNode(SyntaxNode key, SyntaxNode value)
        {
            Key = key;
            Value = value;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}