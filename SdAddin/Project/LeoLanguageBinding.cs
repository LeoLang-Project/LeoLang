using Furesoft.LeoBinding.Completion;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor.CodeCompletion;
using System;

namespace Furesoft.LeoBinding
{
    public class LeoLanguageBinding : DefaultLanguageBinding
    {
        public override ICodeCompletionBinding CreateCompletionBinding(string expressionToComplete, ICodeContext context)
        {
            return new LeoCompletionBinding(new ReadOnlyDocument(expressionToComplete).CreateSnapshot());
        }
    }
}