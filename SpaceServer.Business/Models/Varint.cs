using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceServer.Business.Models
{
    public class Varint
    {
        public static byte[] Encode(ulong x)
        {
            var buf = new byte[sizeof(UInt64)];
            var n = 0;
            for (n = 0; x > 127; n++)
            {
                buf[n] = (byte)(0x80 | (byte)(x & 0x7F));
                x >>= 7;
                x -= 1;
            }
            buf[n] = (byte)x;
            n++;
            return buf[0..n];
        }

        public static (ulong x, int n) Decode(byte[] buf)
        {
            int n = 0;
            ulong x = 0;
            for (int shift = 0; shift < 64; shift += 7)
            {
                if (n >= buf.Length) return (0, 0);
                ulong b = buf[n];
                n++;
                x += (b & 0xFF) << shift;
                if ((b & 0x80) == 0)
                {
                    return (x, n);
                }
            }
            return (0, 0);
        }

        public static int ReadInt(ref byte[] buf)
        {
            var (value, offset) = Varint.Decode(buf);
            var intValue = (int)value;
            buf = buf[offset..];
            return intValue;
        }
    }
}
