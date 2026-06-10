using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int IntByteLength = 2;

    /// <summary>
    /// 【同步】单点读取 Int
    /// </summary>
    public static short ReadInt(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, IntByteLength);
        short value = Int.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【同步】批量读取连续的 Int
    /// </summary>
    public static short[] ReadInt(this Plc plc, int db, int byteAdr, int count)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, IntByteLength * count);
        short[] value = Int.ToArray(bytes);
        return value;
    }

    /// <summary>
    /// 【同步】单点写入 Int
    /// </summary>
    public static void WriteInt(this Plc plc, int db, int byteAdr, short value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, Int.ToByteArray(value));
    }

    /// <summary>
    /// 【同步】批量写入连续的 Int
    /// </summary>
    public static void WriteInt(this Plc plc, int db, int byteAdr, short[] value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, Int.ToByteArray(value));
    }

    /// <summary>
    /// 【异步】单点读取 Int
    /// </summary>
    public static async Task<short> ReadIntAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, IntByteLength, cancellationToken);
        short value = Int.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【异步】批量读取连续的 Int
    /// </summary>
    public static async Task<short[]> ReadIntAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, IntByteLength * count, cancellationToken);
        short[] value = Int.ToArray(bytes);
        return value;
    }

    /// <summary>
    /// 【异步】单点写入 Int
    /// </summary>
    public static async Task WriteIntAsync(this Plc plc, int db, int byteAdr, short value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Int.ToByteArray(value), cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 Int
    /// </summary>
    public static async Task WriteIntAsync(this Plc plc, int db, int byteAdr, short[] value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Int.ToByteArray(value), cancellationToken);
    }
}
