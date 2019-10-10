namespace LeoLang.Core
{
    public interface IStrategy<T>
    {
        T Do(T arg);
    }
}