namespace LeoLang.CodeAnalysis.Binding
{
    public enum BoundNodeKind
    {
        UnaryExpression,
        LiteralExpression,
        DefaultExpression,
        VariableExpression,
        AssignmentExpression,
        SomeExpression,
        BinaryExpression,
        BlockStatement,
        ExpressionStatement,
        VariableDeclaration,
        IfStatement,
        WhileStatement,
        ForStatement,
        ConditionalGotoStatement,
        LabelStatement,
        GotoStatement,
        ErrorExpression,
        CallExpression,
        TypeOfExpression,
        ConversionExpression
    }
}