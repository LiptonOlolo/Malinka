namespace Malinka
{
    /// <summary>
    /// Handler.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILog<T>
    {
        /// <summary>
        /// Get log string.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <param name="args">Arguments.</param>
        /// <returns></returns>
        string Log(T item, params object[] args);
    }
}
