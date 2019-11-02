using ICSharpCode.NRefactory.Editor;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Editor.CodeCompletion;
using LeoLang.Core;
using LeoLang.Core.AST;
using Loyc.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Furesoft.LeoBinding.Completion
{
    public class LeoCompletionBinding : ICodeCompletionBinding
    {
        public LeoCompletionBinding()
            : this(null)
        {
        }

        public LeoCompletionBinding(ITextSource fileContent)
        {
            this.fileContent = fileContent;
        }

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

        private ITextSource fileContent;

        private IEnumerable<ICompletionItem> GetVariableNames(LNode ast)
        {
            /*if (ast is MethodDefinitionNode md)
            {
                var block = (BlockNode)md.Body;

                foreach (var variable in block.Body)
                {
                    if (variable is VariableDefinitionNode vd)
                    {
                        yield return new DefaultCompletionItem(vd.Name.Name);
                    }
                }
            }
            */

            return null;
        }

        private bool ShowCompletion(ITextEditor editor, char v1, bool v2)
        {
            DefaultCompletionItemList list = new DefaultCompletionItemList();
            list.Items.Add(new DefaultCompletionItem("while"));
            list.Items.Add(new DefaultCompletionItem("if"));
            list.Items.Add(new DefaultCompletionItem("unless"));
            list.Items.Add(new DefaultCompletionItem("for"));

            var txt = editor.
                Document.CreateSnapshot().Text;

            try
            {
                var p = new LeoParser();

                var ast = p.Parse(txt);

                list.Items.AddRange(GetVariableNames(ast));

                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\editor.txt", ObjectDumper.Dump(ast));
                //ToDo: load all methodnames, variablenames to completionlist
                //ToDo: load all predefined keywords to completionlist
            }
            catch (FormatException ex)
            {
                SD.Log.Error(ex.Message);
            }

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