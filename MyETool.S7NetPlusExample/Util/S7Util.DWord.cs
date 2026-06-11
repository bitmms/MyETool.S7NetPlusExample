using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int DWordByteLength = 4;

    /// <summary>
    /// 【同步】单点读取 DWord
    /// </summary>
    public static uint ReadDWord(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, DWordByteLength);
        uint value = DWord.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【同步】批量读取连续的 DWord
    /// </summary>
    public static uint[] ReadDWord(this Plc plc, int db, int byteAdr, int count)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, DWordByteLength * count);
        uint[] values = DWord.ToArray(bytes);
        return values;
    }

    /// <summary>
    /// 【同步】单点写入 DWord
    /// </summary>
    public static void WriteDWord(this Plc plc, int db, int byteAdr, uint value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, DWord.ToByteArray(value));
    }

    /// <summary>
    /// 【同步】批量写入连续的 DWord
    /// </summary>
    public static void WriteDWord(this Plc plc, int db, int byteAdr, uint[] values)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, DWord.ToByteArray(values));
    }

    /// <summary>
    /// 【异步】单点读取 DWord
    /// </summary>
    public static async Task<uint> ReadDWordAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, DWordByteLength, cancellationToken);
        uint value = DWord.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【异步】批量读取连续的 DWord
    /// </summary>
    public static async Task<uint[]> ReadDWordAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, DWordByteLength * count, cancellationToken);
        uint[] values = DWord.ToArray(bytes);
        return values;
    }

    /// <summary>
    /// 【异步】单点写入 DWord
    /// </summary>
    public static async Task WriteDWordAsync(this Plc plc, int db, int byteAdr, uint value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, DWord.ToByteArray(value), cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 DWord
    /// </summary>
    public static async Task WriteDWordAsync(this Plc plc, int db, int byteAdr, uint[] values, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, DWord.ToByteArray(values), cancellationToken);
    }
}
