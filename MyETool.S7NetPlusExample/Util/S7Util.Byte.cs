using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int ByteByteLength = 1;

    /// <summary>
    /// 【同步】单点读取 Byte
    /// </summary>
    public static byte ReadByte(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, ByteByteLength);
        byte value = bytes[0];
        return value;
    }

    /// <summary>
    /// 【同步】批量读取连续的 Byte
    /// </summary>
    public static byte[] ReadByte(this Plc plc, int db, int byteAdr, int count)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, ByteByteLength * count);
        return bytes;
    }

    /// <summary>
    /// 【同步】单点写入 Byte
    /// </summary>
    public static void WriteByte(this Plc plc, int db, int byteAdr, byte value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, [value]);
    }

    /// <summary>
    /// 【同步】批量写入连续的 Byte
    /// </summary>
    public static void WriteByte(this Plc plc, int db, int byteAdr, byte[] values)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, values);
    }

    /// <summary>
    /// 【异步】单点读取 Byte
    /// </summary>
    public static async Task<byte> ReadByteAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, ByteByteLength, cancellationToken);
        byte value = bytes[0];
        return value;
    }

    /// <summary>
    /// 【异步】批量读取连续的 Byte
    /// </summary>
    public static async Task<byte[]> ReadByteAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, ByteByteLength * count, cancellationToken);
        return bytes;
    }

    /// <summary>
    /// 【异步】单点写入 Byte
    /// </summary>
    public static async Task WriteByteAsync(this Plc plc, int db, int byteAdr, byte value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, [value], cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 Byte
    /// </summary>
    public static async Task WriteByteAsync(this Plc plc, int db, int byteAdr, byte[] values, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, values, cancellationToken);
    }
}
