namespace System.Collections.Generic
{
    public static class Extensions
    {
        public static void AddIfNotExists<T>(this IList<T> list, T arg)
        {
            if (!list.Contains(arg))
            {
                list.Add(arg);
            }
        }

        public static void RemoveIfExists<T>(this IList<T> list, T arg)
        {
            if (list.Contains(arg))
            {
                list.Remove(arg);
            }
        }
    }
}