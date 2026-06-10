using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /// <summary>
    /// 在 S7 中  Int = 2B = 16b
    /// 在 C# 中  Int16 = short = 2B = 16b
    /// </summary>
    private const int IntBitLength = 16;

    public static short ReadInt(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, IntBitLength / 8);
        short value = Int.FromByteArray(bytes);
        return value;
    }

    public static void WriteInt(this Plc plc, int db, int byteAdr, short value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, Int.ToByteArray(value));
    }

    public static async Task<short> ReadIntAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, IntBitLength / 8, cancellationToken);
        short value = Int.FromByteArray(bytes);
        return value;
    }

    public static async Task WriteIntAsync(this Plc plc, int db, int byteAdr, short value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Int.ToByteArray(value), cancellationToken);
    }
}
