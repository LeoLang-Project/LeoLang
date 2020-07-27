using LeoLang.CodeAnalysis.Binding;

namespace LeoLang.CodeAnalysis.Emit
{
    public interface IEmitter
    {
        public void Emit(BoundProgram program);
    }
}