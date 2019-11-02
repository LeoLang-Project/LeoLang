using LeoLang.Core.AST;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeoLang.Core
{
    public class BlockNode : SyntaxNode
    {
        public IEnumerable<SyntaxNode> Body { get; set; }

        public BlockNode(IEnumerable<SyntaxNode> body)
        {
            Body = body;
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public BlockNode Concat(SyntaxNode tail)
        {
            var tmp = new List<SyntaxNode>(Body);
            tmp.Add(((BlockNode)tail).Body.First());

            Body = tmp;

            return this;
        }

        public IEnumerable<T> FindChildrenOfType<T>()
                            where T : SyntaxNode
        {
            foreach (var child in Body)
            {
                if (child is T) yield return child as T;
                if (child is BlockNode n)
                {
                    var buffer = n.FindChildrenOfType<T>();
                    foreach (var b in buffer)
                    {
                        yield return b;
                    }
                }

                if (child is StatementNode s)
                {
                    var buffer = s.Body.FindChildrenOfType<T>();
                    foreach (var b in buffer)
                    {
                        yield return b;
                    }
                }
                if (child is MethodDefinitionNode m)
                {
                    var buffer = ((BlockNode)m.Body).FindChildrenOfType<T>();
                    foreach (var b in buffer)
                    {
                        yield return b;
                    }
                }
            }
        }

        public void ReplaceNode(ref SyntaxNode root, SyntaxNode toReplace)
        {
            root = toReplace;
        }
    }
}