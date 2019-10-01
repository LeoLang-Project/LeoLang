using LeoLang.Core.AST;

namespace LeoLang.Core
{
    public abstract class Visitor
    {
        public abstract void Visit(IdentifierNode rootNode);

        public abstract void Visit(BooleanLiteralNode rootNode);

        public abstract void Visit(LiteralNode rootNode);

        public abstract void Visit(VariableDefinitionNode rootNode);

        public abstract void Visit(NumberLiteralNode rootNode); //Todo: use real syntaxnode implementation
    }
}