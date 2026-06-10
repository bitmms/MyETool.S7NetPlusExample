using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /// <summary>
    /// 在 S7 中  Word = 2B = 16b，表示一个 16 进制的数值
    /// 在 C# 中  UInt16 = ushort = 2B = 16b
    /// </summary>
    private const int WordBitLength = 16;

    /// <summary>
    /// 同步读取一个 Word
    /// </summary>
    public static ushort ReadWord(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, WordBitLength / 8);
        ushort value = Word.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 同步写入一个 Word
    /// </summary>
    public static void WriteWord(this Plc plc, int db, int byteAdr, ushort value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, Word.ToByteArray(value));
    }

    /// <summary>
    /// 异步读取一个 Word
    /// </summary>
    public static async Task<ushort> ReadWordAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, WordBitLength / 8, cancellationToken);
        ushort value = Word.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 异步写入一个 Word
    /// </summary>
    public static async Task WriteWordAsync(this Plc plc, int db, int byteAdr, ushort value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Word.ToByteArray(value), cancellationToken);
    }
}
