using System;
using System.Collections.Generic;
using System.Linq;
using LeoLang.CodeAnalysis;
using LeoLang.CodeAnalysis.Symbols;
using LeoLang.CodeAnalysis.Syntax;

namespace LLC
{
    class Program
    {
        static void Main(string[] args)
        {
            var variables = new Dictionary<VariableSymbol, object>();

            while(true) {
                Console.Write("> ");

                var line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                var syntaxTree = SyntaxTree.Parse(line);
                var compilation = new Compilation(syntaxTree, variables);
                var result = compilation.Evaluate();

                var diagnostics = syntaxTree.Diagnostics.Concat(result.Diagnostics).ToArray();

                if (!result.Diagnostics.Any())
                {
                    Console.WriteLine(result.Value);
                }
                else
                {
                    foreach (var diagnostic in result.Diagnostics)
                    {
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(diagnostic);
                        Console.ResetColor();

                        var prefix = line.Substring(0, diagnostic.Span.Start);
                        var error = line.Substring(diagnostic.Span.Start, diagnostic.Span.Length);
                        var suffix = line.Substring(diagnostic.Span.End);

                        Console.Write("    ");
                        Console.Write(prefix);

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(error);
                        Console.ResetColor();

                        Console.Write(suffix);

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }

                syntaxTree.Root.WriteTo(Console.Out);
                Console.WriteLine();
            }
        }
    }
}