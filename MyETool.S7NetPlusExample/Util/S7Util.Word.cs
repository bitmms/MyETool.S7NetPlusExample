using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int WordByteLength = 2;

    /// <summary>
    /// 【同步】单点读取 Word
    /// </summary>
    public static ushort ReadWord(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, WordByteLength);
        ushort value = Word.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【同步】批量读取连续的 Word
    /// </summary>
    public static ushort[] ReadWord(this Plc plc, int db, int byteAdr, int count)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, WordByteLength * count);
        ushort[] values = Word.ToArray(bytes);
        return values;
    }

    /// <summary>
    /// 【同步】单点写入 Word
    /// </summary>
    public static void WriteWord(this Plc plc, int db, int byteAdr, ushort value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, Word.ToByteArray(value));
    }

    /// <summary>
    /// 【同步】批量写入连续的 Word
    /// </summary>
    public static void WriteWord(this Plc plc, int db, int byteAdr, ushort[] values)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, Word.ToByteArray(values));
    }

    /// <summary>
    /// 【异步】单点读取 Word
    /// </summary>
    public static async Task<ushort> ReadWordAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, WordByteLength, cancellationToken);
        ushort value = Word.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【异步】批量读取连续的 Word
    /// </summary>
    public static async Task<ushort[]> ReadWordAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, WordByteLength * count, cancellationToken);
        ushort[] values = Word.ToArray(bytes);
        return values;
    }

    /// <summary>
    /// 【异步】单点写入 Word
    /// </summary>
    public static async Task WriteWordAsync(this Plc plc, int db, int byteAdr, ushort value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Word.ToByteArray(value), cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 Word
    /// </summary>
    public static async Task WriteWordAsync(this Plc plc, int db, int byteAdr, ushort[] values, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Word.ToByteArray(values), cancellationToken);
    }
}
