using S7.Net;

namespace MyETool.S7NetPlusExample.Util
{
    public static partial class S7Util
    {
        private const int SIntByteLength = 1;

        /// <summary>
        /// 【同步】单点读取 SInt
        /// </summary>
        public static sbyte ReadSInt(this Plc plc, int db, int byteAdr)
        {
            byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, SIntByteLength);
            sbyte value = (sbyte)bytes[0];
            return value;
        }

        /// <summary>
        /// 【同步】批量读取连续的 SInt
        /// </summary>
        public static sbyte[] ReadSInt(this Plc plc, int db, int byteAdr, int count)
        {
            byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, SIntByteLength * count);
            sbyte[] value = bytes.ToSByteArray();
            return value;
        }

        /// <summary>
        /// 【同步】单点写入 SInt
        /// </summary>
        public static void WriteSInt(this Plc plc, int db, int byteAdr, sbyte value)
        {
            byte[] bytes = [value.ToByte()];
            plc.WriteBytes(DataType.DataBlock, db, byteAdr, bytes);
        }

        /// <summary>
        /// 【同步】批量写入连续的 SInt
        /// </summary>
        public static void WriteSInt(this Plc plc, int db, int byteAdr, sbyte[] values)
        {
            byte[] bytes = values.ToByteArray();
            plc.WriteBytes(DataType.DataBlock, db, byteAdr, bytes);
        }

        /// <summary>
        /// 【异步】单点读取 SInt
        /// </summary>
        public static async Task<sbyte> ReadSIntAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
        {
            byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, SIntByteLength, cancellationToken);
            sbyte value = bytes[0].ToSByte();
            return value;
        }

        /// <summary>
        /// 【异步】批量读取连续的 SInt
        /// </summary>
        public static async Task<sbyte[]> ReadSIntAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
        {
            byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, SIntByteLength * count, cancellationToken);
            sbyte[] value = bytes.ToSByteArray();
            return value;
        }

        /// <summary>
        /// 【异步】单点写入 SInt
        /// </summary>
        public static async Task WriteSIntAsync(this Plc plc, int db, int byteAdr, sbyte value, CancellationToken cancellationToken = default)
        {
            byte[] bytes = [value.ToByte()];
            await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, bytes, cancellationToken);
        }

        /// <summary>
        /// 【异步】批量写入连续的 SInt
        /// </summary>
        public static async Task WriteSIntAsync(this Plc plc, int db, int byteAdr, sbyte[] values, CancellationToken cancellationToken = default)
        {
            byte[] bytes = values.ToByteArray();
            await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, bytes, cancellationToken);
        }

        /// <summary>
        /// sbyte 转 byte
        /// </summary>
        private static byte ToByte(this sbyte value)
        {
            return (byte)(value & 0xFF);
        }

        /// <summary>
        /// byte 转 sbyte
        /// </summary>
        private static sbyte ToSByte(this byte value)
        {
            return (sbyte)value;
        }

        /// <summary>
        /// sbyte[] 转 byte[]
        /// </summary>
        private static byte[] ToByteArray(this sbyte[] values)
        {
            int len = values.Length;

            byte[] bytes = new byte[len];
            for (int i = 0; i < len; i++)
            {
                bytes[i] = (byte)(values[i] & 0xFF);
            }

            return bytes;
        }

        /// <summary>
        /// byte[] 转 sbyte[]
        /// </summary>
        private static sbyte[] ToSByteArray(this byte[] values)
        {
            int len = values.Length;

            sbyte[] bytes = new sbyte[len];
            for (int i = 0; i < len; i++)
            {
                bytes[i] = (sbyte)(values[i]);
            }

            return bytes;
        }
    }
}
