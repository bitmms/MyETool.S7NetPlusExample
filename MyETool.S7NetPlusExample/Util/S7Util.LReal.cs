using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util
{
    public static partial class S7Util
    {
        /// <summary>
        /// 在 S7 中  LReal = 8B = 64b
        /// 在 C# 中  double = 8B = 64b
        /// </summary>
        private const int LRealBitLength = 64;

        public static double ReadLReal(this Plc plc, int db, int byteAdr)
        {
            byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, LRealBitLength / 8);
            double value = LReal.FromByteArray(bytes);
            return value;
        }

        public static void WriteLReal(this Plc plc, int db, int byteAdr, double value)
        {
            plc.WriteBytes(DataType.DataBlock, db, byteAdr, LReal.ToByteArray(value));
        }

        public static async Task<double> ReadLRealAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
        {
            byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, LRealBitLength / 8, cancellationToken);
            double value = LReal.FromByteArray(bytes);
            return value;
        }

        public static async Task WriteLRealAsync(this Plc plc, int db, int byteAdr, double value, CancellationToken cancellationToken = default)
        {
            await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, LReal.ToByteArray(value), cancellationToken);
        }
    }
}
