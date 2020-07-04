namespace LeoLang.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        // Tokens
        BadToken,
        EndOfFileToken,
        WhitespaceToken,
        NumberToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        BangToken,
        AmpersandAmpersandToken,
        PipePipeToken,
        EqualsEqualsToken,
        ApostropheEqualsToken,
        BangEqualsToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        IdentifierToken,
        ApostropheToken,
        LessToken,
        LessOrEqualsToken,
        GreaterToken,
        GreaterOrEqualsToken,

        // Keywords
        FalseKeyword,
        TrueKeyword,

        // Expressions
        LiteralExpression,
        UnaryExpression,
        BinaryExpression,
        ParenthesizedExpression,
        EqualsEqualsEqualsToken,
        SymbolLiteral,
        EmptyKeyword,
        SomeKeyword,
        SomeExpression,
        DefaultKeyword,
        DefaultExpression,
        NameExpression,
        EqualsToken,
        AssignmentExpression,
        TypeOfKeyword,
        TypeOfExpression,
        CompilationUnit,
        BlockStatement,
        ExpressionStatement,
        CloseBraceToken,
        OpenBraceToken,
        VariableDeclaration,
        LetKeyword,
        VarKeyword,
    }
}
