using System;
using PipelineNet.Middleware;
using dnlib;
using dnlib.DotNet.Emit;
using dnlib.DotNet;
using LeoLang.Core.AST;

namespace LeoLangCompiler.Middlewares
{
    public class EmitMiddleware : IMiddleware<CompilerPipelineContext>
    {
        public void Run(CompilerPipelineContext arg, Action<CompilerPipelineContext> next)
        {
            var mod = new ModuleDefUser("ctor-test", Guid.NewGuid(),
                new AssemblyRefUser(new AssemblyNameInfo(typeof(int).Assembly.GetName().FullName)));
            arg.Module = mod;
            mod.Kind = arg.CmdArgs.Kind;
            // Create the assembly and add the created module to it
            new AssemblyDefUser("ctor-test", new Version(1, 2, 3, 4)).Modules.Add(mod);

            // Create System.Console type reference
            var systemConsole = mod.CorLibTypes.GetTypeRef("System", "Console");
            // Create 'void System.Console.WriteLine(string,object)' method reference
            var writeLine2 = new MemberRefUser(mod, "WriteLine",
                            MethodSig.CreateStatic(mod.CorLibTypes.Void, mod.CorLibTypes.String,
                                                mod.CorLibTypes.Object),
                            systemConsole);

            CilBody body;

            // Create the Ctor.Test.Main type which derives from Ctor.Test.BaseClass
            var main = new TypeDefUser("Ctor.Test", "Main");
            // Add it to the module
            mod.Types.Add(main);
            // Create the static 'void Main()' method
            var entryPoint = new MethodDefUser("Main", MethodSig.CreateStatic(mod.CorLibTypes.Void),
                            MethodImplAttributes.IL | MethodImplAttributes.Managed,
                            MethodAttributes.Public | MethodAttributes.Static);
            // Set entry point to entryPoint and add it as a Ctor.Test.Main method
            mod.EntryPoint = entryPoint;
            main.Methods.Add(entryPoint);

            entryPoint.Body = body = new CilBody();

            /*if (arg.AST is MethodDefinitionNode methdef)
            {
                var m = new MethodDefUser((string)methdef.Name, MethodSig.CreateStatic(mod.CorLibTypes.Void),
                           MethodImplAttributes.IL | MethodImplAttributes.Managed,
                           MethodAttributes.Public | MethodAttributes.Static);

                if (methdef.Body is VariableDefinitionNode vardef)
                {
                    body.Variables.Add(new Local(mod.CorLibTypes.Int32, vardef.Name));
                    body.InitLocals = true;
                    body.MaxStack = 2;
                    body.Instructions.Add(OpCodes.Ret.ToInstruction());
                }

                main.Methods.Add(m);
            }
            */

            // Save the assembly
            mod.Write(arg.CmdArgs.Output);

            next(arg);
        }
    }
}