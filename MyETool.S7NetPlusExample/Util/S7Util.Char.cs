using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /// <summary>
    /// 在 S7 中  Char = 1B = 8b
    /// 在 C# 中  char = 1B = 8b
    /// </summary>
    private const int CharBitLength = 8;

    public static char ReadChar(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, CharBitLength / 8);
        char value = (char)S7.Net.Types.Byte.FromByteArray(bytes);
        return value;
    }

    public static void WriteChar(this Plc plc, int db, int byteAdr, char value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, S7.Net.Types.Byte.ToByteArray((byte)value));
    }

    public static async Task<char> ReadCharAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, CharBitLength / 8, cancellationToken);
        char value = (char)S7.Net.Types.Byte.FromByteArray(bytes);
        return value;
    }

    public static async Task WriteCharAsync(this Plc plc, int db, int byteAdr, char value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, S7.Net.Types.Byte.ToByteArray((byte)value), cancellationToken);
    }
}
