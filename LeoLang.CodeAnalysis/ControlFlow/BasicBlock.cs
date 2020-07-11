using LeoLang.CodeAnalysis.Binding;
using System.Collections.Generic;
using System.IO;

namespace LeoLang.CodeAnalysis.ControlFlow
{
    internal sealed partial class ControlFlowGraph
    {
        public sealed class BasicBlock
        {
            public BasicBlock()
            {
            }

            public BasicBlock(bool isStart)
            {
                IsStart = isStart;
                IsEnd = !isStart;
            }

            public bool IsStart { get; }
            public bool IsEnd { get; }
            public List<BoundStatement> Statements { get; } = new List<BoundStatement>();
            public List<BasicBlockBranch> Incoming { get; } = new List<BasicBlockBranch>();
            public List<BasicBlockBranch> Outgoing { get; } = new List<BasicBlockBranch>();

            public override string ToString()
            {
                if (IsStart)
                    return "<Start>";

                if (IsEnd)
                    return "<End>";

                using (var writer = new StringWriter())
                {
                    foreach (var statement in Statements)
                        statement.WriteTo(writer);

                    return writer.ToString();
                }
            }
        }
    }
}