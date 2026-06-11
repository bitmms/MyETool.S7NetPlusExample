using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int UsIntByteLength = 1;

    /// <summary>
    /// 【同步】单点读取 USInt
    /// </summary>
    public static byte ReadUsInt(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, UsIntByteLength);
        byte value = bytes[0];
        return value;
    }

    /// <summary>
    /// 【同步】批量读取连续的 USInt
    /// </summary>
    public static byte[] ReadUsInt(this Plc plc, int db, int byteAdr, int count)
    {
        byte[] values = plc.ReadBytes(DataType.DataBlock, db, byteAdr, UsIntByteLength * count);
        return values;
    }

    /// <summary>
    /// 【同步】单点写入 USInt
    /// </summary>
    public static void WriteUsInt(this Plc plc, int db, int byteAdr, byte value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, [value]);
    }

    /// <summary>
    /// 【同步】批量写入连续的 USInt
    /// </summary>
    public static void WriteUsInt(this Plc plc, int db, int byteAdr, byte[] values)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, values);
    }

    /// <summary>
    /// 【异步】单点读取 USInt
    /// </summary>
    public static async Task<byte> ReadUsIntAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, UsIntByteLength, cancellationToken);
        byte value = bytes[0];
        return value;
    }

    /// <summary>
    /// 【异步】批量读取连续的 USInt
    /// </summary>
    public static async Task<byte[]> ReadUsIntAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        byte[] values = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, UsIntByteLength * count, cancellationToken);
        return values;
    }

    /// <summary>
    /// 【异步】单点写入 USInt
    /// </summary>
    public static async Task WriteUsIntAsync(this Plc plc, int db, int byteAdr, byte value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, [value], cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 USInt
    /// </summary>
    public static async Task WriteUsIntAsync(this Plc plc, int db, int byteAdr, byte[] values, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, values, cancellationToken);
    }
}
