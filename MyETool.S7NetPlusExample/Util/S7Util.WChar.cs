using System.Text;
using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int WCharByteLength = 2;

    /// <summary>
    /// 【同步】单点读取 WChar
    /// </summary>
    public static char ReadWChar(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, WCharByteLength);
        char resultChar = Encoding.BigEndianUnicode.GetChars(bytes)[0];
        return resultChar;
    }

    /// <summary>
    /// 【同步】批量读取连续的 WChar
    /// </summary>
    public static char[] ReadWChar(this Plc plc, int db, int byteAdr, int count)
    {
        // 1. 从 PLC 读取双字节字符，此时是 Unicode UTF-16 双字节大端
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, WCharByteLength * count);
        // 2. 利用 Unicode 大端进行解码得到 char 数据
        char[] resultChars = Encoding.BigEndianUnicode.GetChars(bytes);
        // 3. 返回
        return resultChars;
    }

    /// <summary>
    /// 【同步】单点写入 WChar
    /// </summary>
    public static void WriteWChar(this Plc plc, int db, int byteAdr, char value)
    {
        byte[] bytes = Encoding.BigEndianUnicode.GetBytes([value]);
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, bytes);
    }

    /// <summary>
    /// 【同步】批量写入连续的 WChar
    /// </summary>
    public static void WriteWChar(this Plc plc, int db, int byteAdr, char[] values)
    {
        // 1. 利用 Unicode 大端进行解码，得到 Unicode UTF-16 大端双字节数组
        byte[] bytes = Encoding.BigEndianUnicode.GetBytes(values);
        // 2. 写入 PLC 中
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, bytes);
    }

    /// <summary>
    /// 【异步】单点读取 WChar
    /// </summary>
    public static async Task<char> ReadWCharAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        // 1. 从 PLC 读取双字节字符，此时是 Unicode UTF-16 双字节大端
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, WCharByteLength, cancellationToken);
        // 2. 利用 Unicode 大端进行解码得到 char 数据
        char resultChar = Encoding.BigEndianUnicode.GetChars(bytes)[0];
        // 3. 返回
        return resultChar;
    }

    /// <summary>
    /// 【异步】批量读取连续的 WChar
    /// </summary>
    public static async Task<char[]> ReadWCharAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        // 1. 从 PLC 读取双字节字符，此时是 Unicode UTF-16 双字节大端
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, WCharByteLength * count, cancellationToken);
        // 2. 利用 Unicode 大端进行解码得到 char 数据
        char[] resultChars = Encoding.BigEndianUnicode.GetChars(bytes);
        // 3. 返回
        return resultChars;
    }

    /// <summary>
    /// 【异步】单点写入 WChar
    /// </summary>
    public static async Task WriteWCharAsync(this Plc plc, int db, int byteAdr, char value, CancellationToken cancellationToken = default)
    {
        // 1. 利用 Unicode 大端进行解码，得到 Unicode UTF-16 大端双字节数组
        byte[] bytes = Encoding.BigEndianUnicode.GetBytes([value]);
        // 2. 写入 PLC 中
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, bytes, cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 WChar
    /// </summary>
    public static async Task WriteWCharAsync(this Plc plc, int db, int byteAdr, char[] values, CancellationToken cancellationToken = default)
    {
        // 1. 利用 Unicode 大端进行解码，得到 Unicode UTF-16 大端双字节数组
        byte[] bytes = Encoding.BigEndianUnicode.GetBytes(values);
        // 2. 写入 PLC 中
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, bytes, cancellationToken);
    }
}
