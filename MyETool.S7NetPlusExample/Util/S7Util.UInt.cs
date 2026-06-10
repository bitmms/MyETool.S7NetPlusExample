using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int UIntByteLength = 2;

    /// <summary>
    /// 【同步】单点读取 UInt
    /// </summary>
    public static ushort ReadUInt(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, UIntByteLength);
        ushort value = Word.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【同步】批量读取连续的 UInt
    /// </summary>
    public static ushort[] ReadUInt(this Plc plc, int db, int byteAdr, int count)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, UIntByteLength * count);
        ushort[] value = Word.ToArray(bytes);
        return value;
    }

    /// <summary>
    /// 【同步】单点写入 UInt
    /// </summary>
    public static void WriteUInt(this Plc plc, int db, int byteAdr, ushort value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, Word.ToByteArray(value));
    }

    /// <summary>
    /// 【同步】批量写入连续的 UInt
    /// </summary>
    public static void WriteUInt(this Plc plc, int db, int byteAdr, ushort[] value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, Word.ToByteArray(value));
    }

    /// <summary>
    /// 【异步】单点读取 UInt
    /// </summary>
    public static async Task<ushort> ReadUIntAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, UIntByteLength, cancellationToken);
        ushort value = Word.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【异步】批量读取连续的 UInt
    /// </summary>
    public static async Task<ushort[]> ReadUIntAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, UIntByteLength * count, cancellationToken);
        ushort[] value = Word.ToArray(bytes);
        return value;
    }

    /// <summary>
    /// 【异步】单点写入 UInt
    /// </summary>
    public static async Task WriteUIntAsync(this Plc plc, int db, int byteAdr, ushort value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Word.ToByteArray(value), cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 UInt
    /// </summary>
    public static async Task WriteUIntAsync(this Plc plc, int db, int byteAdr, ushort[] value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Word.ToByteArray(value), cancellationToken);
    }
}
