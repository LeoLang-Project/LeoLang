using System;

namespace LLC
{
    class Program
    {
        static void Main(string[] args)
        {

            while(true) {
                Console.Write("> ");
                var line = "1 - 2 + 3"; //Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                var parser = new Parser(line);
                var expression = parser.Parse();

                PrettyPrint(expression);
            }
        }

        static void PrettyPrint(SyntaxNode node, string indent = "")
        {
            //ToDo: continue
            Console.Write(node.Kind);

            if(node is SyntaxToken t && t.Value != null)
            {
                Console.Write(" ");
                Console.Write(t.Value);
            }

            indent += "    ";

            foreach(var child in node.GetChildren())
            {
                PrettyPrint(child, indent);
            }
        }
    }
}