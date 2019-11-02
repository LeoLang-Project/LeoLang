using LeoLang.Core;
using LeoLang.Core.AST;
using System;
using System.Linq;

namespace LeoLangCompiler.Strategies.Lowering
{
    public class WhileLoweringStrategy : IStrategy<SyntaxNode>
    {
        public int Counter { get; set; }

        public SyntaxNode Do(SyntaxNode arg)
        {
            BlockNode blk = (BlockNode)arg;
            var nodes = blk.FindChildrenOfType<StatementNode>().ToArray();
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Name == "while")
                {
                    var lblNode = new LabelDefinitionNode("loop" + Counter++);
                    lblNode.Body = nodes[i].Body;

                    blk.ReplaceNode(ref nodes[i], lblNode);
                }
            }

            return arg;
        }
    }
}