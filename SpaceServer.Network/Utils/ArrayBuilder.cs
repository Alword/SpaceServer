using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
