using System;
namespace LLC
{
    class Evaluator
    {
        public Evaluator(ExpressionSyntax root)
        {
            Root = root;
        }

        private ExpressionSyntax Root { get; }

        public int Evaluate()
        {
            return EvaluateExpression(Root);
        }

        private int EvaluateExpression(ExpressionSyntax root)
        {
            if (root is NumberExpressionSyntax n) return (int)n.NumberToken.Value;
            if(root is BinaryExpressionSyntax d)
            {
                var left = EvaluateExpression(d.Left);
                var right = EvaluateExpression(d.Right);

                if(d.OperatorToken.Kind == SyntaxKind.PlusToken)
                {
                    return left + right;
                }
                else if (d.OperatorToken.Kind == SyntaxKind.MinusToken)
                {
                    return left - right;
                }
                else if (d.OperatorToken.Kind == SyntaxKind.StarToken)
                {
                    return left * right;
                }
                else if (d.OperatorToken.Kind == SyntaxKind.SlashToken)
                {
                    return left / right;
                }
                else
                {
                    throw new Exception($"unepected binary operator {d.OperatorToken.Kind}");
                }               
            }

            throw new Exception($"unexpeced node {root.Kind}");
        }
    }
}