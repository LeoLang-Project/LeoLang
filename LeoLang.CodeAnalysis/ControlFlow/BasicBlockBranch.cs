using LeoLang.CodeAnalysis.Binding;

namespace LeoLang.CodeAnalysis.ControlFlow
{
    internal sealed partial class ControlFlowGraph
    {
        public sealed class BasicBlockBranch
        {
            public BasicBlockBranch(BasicBlock from, BasicBlock to, BoundExpression condition)
            {
                From = from;
                To = to;
                Condition = condition;
            }

            public BasicBlock From { get; }
            public BasicBlock To { get; }
            public BoundExpression Condition { get; }

            public override string ToString()
            {
                if (Condition == null)
                    return string.Empty;

                return Condition.ToString();
            }
        }
    }
}