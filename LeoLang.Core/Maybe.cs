namespace LeoLang.Core
{
    /// <summary>
    /// Provides a set of functions for creating optional values.
    /// </summary>
    public static class Maybe
    {
        /// <summary>
        /// Wraps an existing value in an Option&lt;T&gt; instance.
        /// </summary>
        /// <param name="value">The value to be wrapped.</param>
        /// <returns>An optional containing the specified value.</returns>
        public static Maybe<T> Some<T>(T value) => new Maybe<T>(value, true);


        /// <summary>
        /// Creates an empty Option&lt;T&gt; instance.
        /// </summary>
        /// <returns>An empty optional.</returns>
        public static Maybe<T> None<T>() => new Maybe<T>(default(T), false);

    }
}