using System;
using System.Collections;
using System.Linq;

namespace SpaceServer.Network
{
    public static class ArrayBuilder
    {
        public static T[] Build<T>(params Array[] parts)
        {
            var totalSize = parts.Sum(d => d.Length);
            var offset = 0;
            var result = new T[totalSize];
            for (int i = 0; i < parts.Length; i++)
            {
                var length = parts[i].Length;
                Array.Copy(parts[i], 0, result, offset, length);
                offset += length;
            }
            return result;
        }

        public static byte[] Build(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }
    }
}
