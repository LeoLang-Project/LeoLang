﻿using System;
using System.Collections.Generic;
using LeoLang.CodeAnalysis.Binding;
using LeoLang.CodeAnalysis.Symbols;

namespace LeoLang.CodeAnalysis
{
    public sealed class Evaluator
    {
        private readonly BoundExpression _root;
        private readonly Dictionary<VariableSymbol, object> _variables;

        public Evaluator(BoundExpression root, Dictionary<VariableSymbol, object> variables)
        {
            _root = root;
            _variables = variables;
        }

        public object Evaluate()
        {
            return EvaluateExpression(_root);
        }

        private object EvaluateExpression(BoundExpression node)
        {
            if (node is BoundLiteralExpression n)
                return n.Value;
            if (node is BoundSomeExpression s)
            {
                return EvaluateExpression(s.Value);
            }
            if(node is BoundVariableExpression v)
            {
                var value = _variables[v.Variable];
                return value;
            }

            if(node is BoundAssignmentExpression a)
            {
                var value = EvaluateExpression(a.Expression);
                _variables[a.Variable] = value;
                return value;
            }

            if (node is BoundDefaultExpression d)
            {
                return ((BoundLiteralExpression)d.Value).Value;
            }
            if (node is BoundTypeOfExpression t)
            {
                var type = Type.GetType(((BoundLiteralExpression)t.Value).Value.ToString(), false, true);
                //Todo: fix type evaluation of typeof expression
                return type;
            }

            if (node is BoundUnaryExpression u)
            {
                var operand = EvaluateExpression(u.Operand);

                switch (u.Op.Kind)
                {
                    case BoundUnaryOperatorKind.Identity:
                        return (int)operand;
                    case BoundUnaryOperatorKind.Negation:
                        return -(int)operand;
                    case BoundUnaryOperatorKind.LogicalNegation:
                        return !(bool)operand;
                    default:
                        throw new Exception($"Unexpected unary operator {u.Op.Kind}");
                }
            }

            if (node is BoundBinaryExpression b)
            {
                var left = EvaluateExpression(b.Left);
                var right = EvaluateExpression(b.Right);

                switch (b.Op.Kind)
                {
                    case BoundBinaryOperatorKind.Addition:
                        return (int)left + (int)right;
                    case BoundBinaryOperatorKind.Subtraction:
                        return (int)left - (int)right;
                    case BoundBinaryOperatorKind.Multiplication:
                        return (int)left * (int)right;
                    case BoundBinaryOperatorKind.Division:
                        return (int)left / (int)right;
                    case BoundBinaryOperatorKind.LogicalAnd:
                        return (bool)left && (bool)right;
                    case BoundBinaryOperatorKind.LogicalOr:
                        return (bool)left || (bool)right;
                    case BoundBinaryOperatorKind.Equals:
                        return Equals(left, right);
                    case BoundBinaryOperatorKind.NotEquals:
                        return !Equals(left, right);
                    case BoundBinaryOperatorKind.RefEquals:
                        return ReferenceEquals(left, right);
                    case BoundBinaryOperatorKind.TypeEquals:
                        return Equals(left, right) && left.GetType() == right.GetType();
                    default:
                        throw new Exception($"Unexpected binary operator {b.Op.Kind}");
                }
            }

            throw new Exception($"Unexpected node {node.Kind}");
        }
    }
}