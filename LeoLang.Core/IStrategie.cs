namespace LeoLang.Core
{
    public interface IStrategie<T>
    {
        T Do(T arg);
    }
}