using System.Runtime.CompilerServices;

namespace AdventOfCode2022
{
    internal static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] arr, int size)
        {
            for (var i = 0; i < arr.Length / size + 1; i++)
            {
                yield return arr.Skip(i * size).Take(size);
            }
        }

        public static bool ContainsRange(this Range rangeLeft, Range rangeRight)
        {
            if (rangeLeft.Start.Value <= rangeRight.Start.Value && rangeLeft.End.Value >= rangeRight.End.Value)
                return true;
            
            return false;
        }

        public static bool OverlapsRange(this Range rangeLeft, Range rangeRight)
        {
            if (rangeLeft.Start.Value <= rangeRight.Start.Value && rangeLeft.End.Value >= rangeRight.Start.Value)
                return true;

            return false;
        }

        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            if (offset < 0)
                return Array.Empty<T>();

            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> func) where TKey : notnull
        {
            if (dict.TryGetValue(key, out var value))
                return value;
            return dict[key] = func(key);
        }
    }
}
