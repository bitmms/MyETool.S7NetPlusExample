using S7.Net;

namespace MyETool.S7NetPlusExample.Util
{
    public static partial class S7Util
    {
        /// <summary>
        /// 在 S7 中  Byte = 1B = 8b
        /// 在 C# 中  byte = 1B = 8b
        /// </summary>
        private const int ByteBitLength = 8;

        public static byte ReadByte(this Plc plc, int db, int byteAdr)
        {
            byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, ByteBitLength / 8);
            byte value = S7.Net.Types.Byte.FromByteArray(bytes);
            return value;
        }

        public static void WriteByte(this Plc plc, int db, int byteAdr, byte value)
        {
            plc.WriteBytes(DataType.DataBlock, db, byteAdr, S7.Net.Types.Byte.ToByteArray(value));
        }

        public static async Task<byte> ReadByteAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
        {
            byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, ByteBitLength / 8, cancellationToken);
            byte value = S7.Net.Types.Byte.FromByteArray(bytes);
            return value;
        }

        public static async Task WriteByteAsync(this Plc plc, int db, int byteAdr, byte value, CancellationToken cancellationToken = default)
        {
            await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, S7.Net.Types.Byte.ToByteArray(value), cancellationToken);
        }
    }
}
