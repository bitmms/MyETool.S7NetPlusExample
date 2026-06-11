using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int TimeByteLength = 4;

    /// <summary>
    /// 【同步】单点读取 Time
    /// </summary>
    public static TimeSpan ReadTime(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, TimeByteLength);
        int value = DInt.FromByteArray(bytes);
        TimeSpan timeSpan = TimeSpan.FromMilliseconds(value);
        return timeSpan;
    }

    /// <summary>
    /// 【同步】批量读取连续的 Time
    /// </summary>
    public static TimeSpan[] ReadTime(this Plc plc, int db, int byteAdr, int count)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, TimeByteLength * count);
        int[] value = DInt.ToArray(bytes);

        TimeSpan[] timeSpans = new TimeSpan[value.Length];
        for (int i = 0; i < timeSpans.Length; i++)
        {
            timeSpans[i] = TimeSpan.FromMilliseconds(value[i]);
        }

        return timeSpans;
    }

    /// <summary>
    /// 【同步】单点写入 Time
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
    /// 【同步】批量写入连续的 Time
    /// </summary>
    public static void WriteTime(this Plc plc, int db, int byteAdr, TimeSpan[] values)
    {
        byte[] bytes = new byte[values.Length * TimeByteLength];

        for (int i = 0, j = 0; i < values.Length * 4 && j < values.Length; i += 4, j++)
        {
            TimeSpan item = values[j];
            if (item < TimeSpan.FromMilliseconds(int.MinValue))
            {
                item = TimeSpan.FromMilliseconds(int.MinValue);
            }

            if (item > TimeSpan.FromMilliseconds(int.MaxValue))
            {
                item = TimeSpan.FromMilliseconds(int.MaxValue);
            }

            byte[] array = DInt.ToByteArray(Convert.ToInt32(item.TotalMilliseconds));
            bytes[i] = array[0];
            bytes[i + 1] = array[1];
            bytes[i + 2] = array[2];
            bytes[i + 3] = array[3];
        }

        plc.WriteBytes(DataType.DataBlock, db, byteAdr, bytes);
    }

    /// <summary>
    /// 【异步】单点读取 Time
    /// </summary>
    public static async Task<TimeSpan> ReadTimeAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, TimeByteLength, cancellationToken);
        int value = DInt.FromByteArray(bytes);
        TimeSpan timeSpan = TimeSpan.FromMilliseconds(value);
        return timeSpan;
    }

    /// <summary>
    /// 【异步】批量读取连续的 Time
    /// </summary>
    public static async Task<TimeSpan[]> ReadTimeAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, TimeByteLength * count, cancellationToken);
        int[] value = DInt.ToArray(bytes);

        TimeSpan[] timeSpans = new TimeSpan[value.Length];
        for (int i = 0; i < timeSpans.Length; i++)
        {
            timeSpans[i] = TimeSpan.FromMilliseconds(value[i]);
        }

        return timeSpans;
    }

    /// <summary>
    /// 【异步】单点写入 Time
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

    /// <summary>
    /// 【异步】批量写入连续的 Time
    /// </summary>
    public static async Task WriteTimeAsync(this Plc plc, int db, int byteAdr, TimeSpan[] values, CancellationToken cancellationToken = default)
    {
        byte[] bytes = new byte[values.Length * TimeByteLength];

        for (int i = 0, j = 0; i < values.Length * 4 && j < values.Length; i += 4, j++)
        {
            TimeSpan item = values[j];
            if (item < TimeSpan.FromMilliseconds(int.MinValue))
            {
                item = TimeSpan.FromMilliseconds(int.MinValue);
            }

            if (item > TimeSpan.FromMilliseconds(int.MaxValue))
            {
                item = TimeSpan.FromMilliseconds(int.MaxValue);
            }

            byte[] array = DInt.ToByteArray(Convert.ToInt32(item.TotalMilliseconds));
            bytes[i] = array[0];
            bytes[i + 1] = array[1];
            bytes[i + 2] = array[2];
            bytes[i + 3] = array[3];
        }

        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, bytes, cancellationToken);
    }
}
