namespace LeoLang.CodeAnalysis.Binding
{
    public enum BoundNodeKind
    {
        UnaryExpression,
        LiteralExpression,
        TypeOfExpression,
        VariableExpression,
        AssignmentExpression,
        SomeExpression,
        BinaryExpression,
        BlockStatement,
        ExpressionStatement,
        VariableDeclaration,
        IfStatement,
        WhileStatement
    }
}