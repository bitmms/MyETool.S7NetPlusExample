using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /// <summary>
    /// 在 S7 中  Bool = 1b
    /// 在 C# 中  bool = 1B = 8b
    /// </summary>
    private const int BoolBitLength = 1;

    public static bool ReadBool(this Plc plc, int db, int byteAdr, byte bitAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, BoolBitLength);
        bool value = Bit.FromByte(bytes[0], bitAdr);
        return value;
    }

    public static void WriteBool(this Plc plc, int db, int byteAdr, byte bitAdr, bool value)
    {
        plc.WriteBit(DataType.DataBlock, db, byteAdr, bitAdr, value);
    }

    public static async Task<bool> ReadBoolAsync(this Plc plc, int db, int byteAdr, byte bitAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, BoolBitLength, cancellationToken);
        bool value = Bit.FromByte(bytes[0], bitAdr);
        return value;
    }

    public static async Task WriteBoolAsync(this Plc plc, int db, int byteAdr, byte bitAdr, bool value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBitAsync(DataType.DataBlock, db, byteAdr, bitAdr, value, cancellationToken);
    }
}
