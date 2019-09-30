namespace LeoLang.Core
{
    public abstract class Visitor
    {
        public abstract void Visit(SyntaxNode rootNode); //Todo: use real syntaxnode implementation
    }
}