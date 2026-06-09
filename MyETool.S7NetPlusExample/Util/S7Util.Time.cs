using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util
{
    public static partial class S7Util
    {
        /// <summary>
        /// 在 S7 中  Time = 4B = 32b
        /// 在 C# 中  Int32 = int = 4B = 32b --->>> TimeSpan
        /// </summary>
        private const int TimeBitLength = 32;

        /// <summary>
        /// 同步读取一个 Time
        /// </summary>
        public static TimeSpan ReadTime(this Plc plc, int db, int byteAdr)
        {
            byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, TimeBitLength / 8);
            int value = DInt.FromByteArray(bytes);
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(value);
            return timeSpan;
        }

        /// <summary>
        /// 同步写入一个 Time
        /// </summary>
        public static void WriteTime(this Plc plc, int db, int byteAdr, TimeSpan value)
        {
            if (value < TimeSpan.FromMilliseconds(int.MinValue))
            {
                value = TimeSpan.FromMilliseconds(int.MinValue);
            }

            if (value > TimeSpan.FromMilliseconds(int.MaxValue))
            {
                value = TimeSpan.FromMilliseconds(int.MaxValue);
            }

            plc.WriteBytes(DataType.DataBlock, db, byteAdr, DInt.ToByteArray(Convert.ToInt32(value.TotalMilliseconds)));
        }

        /// <summary>
        /// 异步读取一个 Time
        /// </summary>
        public static async Task<TimeSpan> ReadTimeAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
        {
            byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, TimeBitLength / 8, cancellationToken);
            int value = DInt.FromByteArray(bytes);
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(value);
            return timeSpan;
        }

        /// <summary>
        /// 异步写入一个 Time
        /// </summary>
        public static async Task WriteTimeAsync(this Plc plc, int db, int byteAdr, TimeSpan value, CancellationToken cancellationToken = default)
        {
            if (value < TimeSpan.FromMilliseconds(int.MinValue))
            {
                value = TimeSpan.FromMilliseconds(int.MinValue);
            }

            if (value > TimeSpan.FromMilliseconds(int.MaxValue))
            {
                value = TimeSpan.FromMilliseconds(int.MaxValue);
            }

            await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, DInt.ToByteArray(Convert.ToInt32(value.TotalMilliseconds)), cancellationToken);
        }
    }
}
