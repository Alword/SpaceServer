using System;

namespace SpaceServer.Network.Extentions
{
    public static class EnumerableExtentions
    {
        public static T[] ToArray<T>(this T[] arr, int start)
        {
            return arr.AsSpan().Slice(start).ToArray();
        }

        public static T[] ToArray<T>(this T[] arr, int start, int length)
        {
            return arr.AsSpan().Slice(start, length).ToArray();
        }
    }
}
