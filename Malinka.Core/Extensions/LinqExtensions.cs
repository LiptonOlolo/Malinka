using System.Collections.Generic;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static int IndexOf<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            int index = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                    return index;
                index++;
            }

            return -1;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
