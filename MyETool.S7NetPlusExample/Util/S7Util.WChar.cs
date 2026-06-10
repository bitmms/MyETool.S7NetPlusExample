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
        // 1. 从 PLC 读取双字节字符，此时是 Unicode UTF-16 双字节大端
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, WCharBitLength / 2, cancellationToken);
        // 2. 利用 Unicode 大端进行解码得到 char 数据
        char resultChar = Encoding.BigEndianUnicode.GetChars(bytes)[0];
        // 3. 返回
        return resultChar;
    }

    public static async Task WriteWCharAsync(this Plc plc, int db, int byteAdr, char value, CancellationToken cancellationToken = default)
    {
        // 1. 利用 Unicode 大端进行解码，得到 Unicode UTF-16 大端双字节数组
        byte[] bytes = Encoding.BigEndianUnicode.GetBytes([value]);
        // 2. 写入 PLC 中
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, bytes, cancellationToken);
    }
}
