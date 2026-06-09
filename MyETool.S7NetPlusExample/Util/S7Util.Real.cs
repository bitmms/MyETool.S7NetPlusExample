using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util
{
    public static partial class S7Util
    {
        /// <summary>
        /// 在 S7 中  Real = 4B = 32b
        /// 在 C# 中  float = 4B = 32b
        /// </summary>
        private const int RealBitLength = 32;

        public static float ReadReal(this Plc plc, int db, int byteAdr)
        {
            byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, RealBitLength / 8);
            float value = Real.FromByteArray(bytes);
            return value;
        }

        public static void WriteReal(this Plc plc, int db, int byteAdr, float value)
        {
            plc.WriteBytes(DataType.DataBlock, db, byteAdr, Real.ToByteArray(value));
        }

        public static async Task<float> ReadRealAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
        {
            byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, RealBitLength / 8, cancellationToken);
            float value = Real.FromByteArray(bytes);
            return value;
        }

        public static async Task WriteRealAsync(this Plc plc, int db, int byteAdr, float value, CancellationToken cancellationToken = default)
        {
            await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Real.ToByteArray(value), cancellationToken);
        }
    }
}
