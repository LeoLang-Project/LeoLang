using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Editor.CodeCompletion;
using LeoLang.Core.AST;
using LeoLangCompiler;

namespace Furesoft.LeoBinding.Completion
{
    public class LeoCompletionBinding : ICodeCompletionBinding
    {
        public bool CtrlSpace(ITextEditor editor)
        {
            return ShowCompletion(editor, '\0', true);
        }

        public CodeCompletionKeyPressResult HandleKeyPress(ITextEditor editor, char ch)
        {
            // We use HandleKeyPressed instead.
            return CodeCompletionKeyPressResult.None;
        }

        public bool HandleKeyPressed(ITextEditor editor, char ch)
        {
            if (editor.ActiveCompletionWindow != null)
                return false;
            return ShowCompletion(editor, ch, false);
        }

        private bool ShowCompletion(ITextEditor editor, char v1, bool v2)
        {
            DefaultCompletionItemList list = new DefaultCompletionItemList();
            list.Items.Add(new DefaultCompletionItem("while"));

            var p = new LeoParser();
            var ast = p.Parse(editor.PrimaryView.SelectedText);
            //ToDo: load all methodnames, variablenames to completionlist
            //ToDo: load all predefined keywords to completionlist
            var d = new DumpVisitor();
            ast.ApplyVisitor(d);

            if (list.Items.Count > 0)
            {
                list.SortItems();
                editor.ShowCompletionWindow(list);
                return true;
            }

            return false;
        }
    }
}