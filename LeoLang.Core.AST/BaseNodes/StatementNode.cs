namespace LeoLang.Core
{
    public abstract class StatementNode : SyntaxNode
    {
        public BlockNode Body { get; set; }

        public abstract override void Accept(Visitor visitor);

        protected StatementNode(BlockNode body)
        {
            Body = body;
        }
    }
}