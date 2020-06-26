using System;
using System.Linq;
using Leo.CodeAnalysis;
using Leo.CodeAnalysis.Syntax;

namespace LLC
{
    class Program
    {
        static void Main(string[] args)
        {

            while(true) {
                Console.Write("> ");
                var line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                var syntaxtree = SyntaxTree.Parse(line);

                if(syntaxtree.Diagnostics.Any())
                {
                    foreach (var err in syntaxtree.Diagnostics)
                    {
                        Console.WriteLine(err);
                    }
                }
                else
                {
                    var evaluator = new Evaluator(syntaxtree.Root);
                    var result = evaluator.Evaluate();

                    Console.WriteLine(result);
                }

                PrettyPrint(syntaxtree.Root);
                Console.WriteLine();
            }
        }

        static void PrettyPrint(SyntaxNode node, string indent = "", bool last = false)
        {
            Console.WriteLine();
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("└──");
                indent += "  ";
            }

            Console.Write(node.Kind);

            if(node is SyntaxToken t && t.Value != null)
            {
                Console.Write(" ");
                Console.Write(t.Value);
            }

            foreach (var child in node.GetChildren())
            {
                PrettyPrint(child, indent);
            }
        }
    }
}