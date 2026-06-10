using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /// <summary>
    /// 在 S7 中  UInt = 2B = 16b
    /// 在 C# 中  UInt16 = ushort = 2B = 16b
    /// </summary>
    private const int UIntBitLength = 16;

    public static ushort ReadUInt(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, UIntBitLength / 8);
        ushort value = Word.FromByteArray(bytes);
        return value;
    }

    public static void WriteUInt(this Plc plc, int db, int byteAdr, ushort value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, Word.ToByteArray(value));
    }

    public static async Task<ushort> ReadUIntAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, UIntBitLength / 8, cancellationToken);
        ushort value = Word.FromByteArray(bytes);
        return value;
    }

    public static async Task WriteUIntAsync(this Plc plc, int db, int byteAdr, ushort value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Word.ToByteArray(value), cancellationToken);
    }
}
