﻿using System;
using System.Collections.Generic;
using LeoLang.Core;

namespace LeoLang.CodeAnalysis.Syntax
{
    internal sealed class Lexer
    {
        private readonly string _text;
        private int _position;
        private readonly DiagnosticBag _diagnostics = new DiagnosticBag();

        public Lexer(string text)
        {
            _text = text;
        }

        public DiagnosticBag Diagnostics => _diagnostics;

        private char Current => Peek(0);

        private char Lookahead => Peek(1);

        private char Peek(int offset)
        {
            var index = _position + offset;

            if (index >= _text.Length)
                return '\0';

            return _text[index];
        }

        private void Next()
        {
            _position++;
        }

        public SyntaxToken Lex()
        {
            if (_position >= _text.Length)
                return new SyntaxToken(SyntaxKind.EndOfFileToken, _position, "\0", null);

            if (char.IsDigit(Current))
            {
                var start = _position;

                while (char.IsDigit(Current))
                    Next();

                var length = _position - start;
                var text = _text.Substring(start, length);
                if (!int.TryParse(text, out var value))
                    _diagnostics.ReportInvalidNumber(new TextSpan(start, length), _text, typeof(int));

                return new SyntaxToken(SyntaxKind.NumberToken, start, text, value);
            }

            if (char.IsWhiteSpace(Current))
            {
                var start = _position;

                while (char.IsWhiteSpace(Current))
                    Next();

                var length = _position - start;
                var text = _text.Substring(start, length);

                return new SyntaxToken(SyntaxKind.WhitespaceToken, start, text, null);
            }

            if (char.IsLetter(Current))
            {
                var start = _position;

                while (char.IsLetter(Current))
                    Next();

                var length = _position - start;
                var text = _text.Substring(start, length);
                var kind = SyntaxFacts.GetKeywordKind(text);
                object value = null;

                if(kind == SyntaxKind.EmptyKeyword)
                {
                    value = Maybe.None<object>();
                }
                return new SyntaxToken(kind, start, text, value);
            }
            if(Current == '\'')
            {
                var start = ++_position;
                while (char.IsLetter(Current)) 
                    Next();

                var length = _position - start;
                var text = _text.Substring(start, length);

                return new SyntaxToken(SyntaxKind.SymbolLiteral, start, "'" + text, (Symbol)text);
            }

            switch (Current)
            {
                case '+':
                    return new SyntaxToken(SyntaxKind.PlusToken, _position++, "+", null);
                case '-':
                    return new SyntaxToken(SyntaxKind.MinusToken, _position++, "-", null);
                case '*':
                    return new SyntaxToken(SyntaxKind.StarToken, _position++, "*", null);
                case '/':
                    return new SyntaxToken(SyntaxKind.SlashToken, _position++, "/", null);
                case '(':
                    return new SyntaxToken(SyntaxKind.OpenParenthesisToken, _position++, "(", null);
                case ')':
                    return new SyntaxToken(SyntaxKind.CloseParenthesisToken, _position++, ")", null);
                case '&':
                    if (Lookahead == '&')
                    {
                        _position += 2;
                        return new SyntaxToken(SyntaxKind.AmpersandAmpersandToken, _position, "&&", null);
                    }
                    break;
                case '|':
                    if (Lookahead == '|')
                    {
                        _position += 2;
                        return new SyntaxToken(SyntaxKind.PipePipeToken, _position, "||", null);
                    }
                    break;
                case '=':
                    if (Lookahead == '=')
                    {
                        if (Peek(2) == '=')
                        {
                            _position += 3;
                            return new SyntaxToken(SyntaxKind.EqualsEqualsEqualsToken, _position, "===", null);
                        }
                        else
                        {
                            _position += 2;
                            return new SyntaxToken(SyntaxKind.EqualsEqualsToken, _position, "==", null);
                        }
                    }
                    else
                    {
                        return new SyntaxToken(SyntaxKind.EqualsToken, _position++, "=", null);
                    }
                case '!':
                    if (Lookahead == '=')
                        return new SyntaxToken(SyntaxKind.BangEqualsToken, _position += 2, "!=", null);
                    else
                        return new SyntaxToken(SyntaxKind.BangToken, _position++, "!", null);
                case '\'':
                    if (Lookahead == '=')
                        return new SyntaxToken(SyntaxKind.ApostropheEqualsToken, _position += 2, "'=", null);
                    break;
            }

            _diagnostics.ReportBadCharacter(_position, Current);
            return new SyntaxToken(SyntaxKind.BadToken, _position++, _text.Substring(_position - 1, 1), null);
        }
    }
}