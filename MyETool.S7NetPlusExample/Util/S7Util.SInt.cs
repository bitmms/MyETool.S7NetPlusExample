using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /// <summary>
    /// 在 S7 中  SInt = 1B = 8b，[-128,127]
    /// 在 C# 中  sbyte = 1B = 8b，[-128,127]
    /// </summary>
    private const int SIntBitLength = 8;

    public static sbyte ReadSInt(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, SIntBitLength / 8);
        sbyte value = (sbyte)bytes[0];
        return value;
    }

    public static void WriteSInt(this Plc plc, int db, int byteAdr, sbyte value)
    {
        byte[] bytes = [(byte)(value & 0xFF)];
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, bytes);
    }

    public static async Task<sbyte> ReadSIntAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, SIntBitLength / 8, cancellationToken);
        sbyte value = (sbyte)bytes[0];
        return value;
    }

    public static async Task WriteSIntAsync(this Plc plc, int db, int byteAdr, sbyte value, CancellationToken cancellationToken = default)
    {
        // sbyte → byte 正确转换
        byte[] bytes = [(byte)(value & 0xFF)];
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, bytes, cancellationToken);
    }
}
