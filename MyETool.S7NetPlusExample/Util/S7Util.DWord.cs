using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /// <summary>
    /// 在 S7 中  DWord = 4B = 32b，表示一个 16 进制的数值
    /// 在 C# 中  UInt32 = uint = 4B = 32b
    /// </summary>
    private const int DWordBitLength = 32;

    public static uint ReadDWordAsUInt(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, DWordBitLength / 8);
        uint value = DWord.FromByteArray(bytes);
        return value;
    }

    public static void WriteDWordByUInt(this Plc plc, int db, int byteAdr, uint value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, DWord.ToByteArray(value));
    }

    public static async Task<uint> ReadDWordAsUIntAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, DWordBitLength / 8, cancellationToken);
        uint value = DWord.FromByteArray(bytes);
        return value;
    }

    public static async Task WriteDWordByUIntAsync(this Plc plc, int db, int byteAdr, uint value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, DWord.ToByteArray(value), cancellationToken);
    }
}
