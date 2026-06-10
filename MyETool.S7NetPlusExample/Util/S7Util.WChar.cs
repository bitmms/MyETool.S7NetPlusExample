using System.Text;
using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /// <summary>
    /// 在 S7 中  WChar = 2B = 16b，表示 Unicode UTF-16 大端 字符
    /// 在 C# 中  char = 2B = 16b
    /// </summary>
    private const int WCharBitLength = 16;

    public static char ReadWChar(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, WCharBitLength / 2);
        char resultChar = Encoding.BigEndianUnicode.GetChars(bytes)[0];
        return resultChar;
    }

    public static void WriteWChar(this Plc plc, int db, int byteAdr, char value)
    {
        byte[] bytes = Encoding.BigEndianUnicode.GetBytes([value]);
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, bytes);
    }

    public static async Task<char> ReadWCharAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, WCharBitLength / 2, cancellationToken);
        char resultChar = Encoding.BigEndianUnicode.GetChars(bytes)[0];
        return resultChar;
    }

    public static async Task WriteWCharAsync(this Plc plc, int db, int byteAdr, char value, CancellationToken cancellationToken = default)
    {
        byte[] bytes = Encoding.BigEndianUnicode.GetBytes([value]);
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, bytes, cancellationToken);
    }
}
