using System.Text;
using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /*
     * 在 S7 中，分配字符串采用：string 或 string[n]
     *      * 这里 n 大于等于1 且 小于等于 254，默认是 254
     *      * 这里的 n 表示可写入内容的字节数
     *      * PLC 实际分配的字节数是 1 + 1 + n，需要两个头字节填充长度：最大内容字节数 + 实际内容字节数
     */

    public static string ReadString(this Plc plc, int db, int byteAdr, int n, Encoding s7Encoding)
    {
        if (n <= 0) return "";
        n = Math.Min(254, n);

        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, 2 + n); // 这里保证了至少读取 2 个字节的数据

        int totalLength = bytes[0]; // 实际可写入字符串的字节数
        int contentLength = bytes[1]; // 实际写入字符串的字节数
        if (totalLength < contentLength) return ""; // 保险处理，避免之前针对 plc 的操作出现问题

        string fromByteArray = s7Encoding.GetString(bytes, 2, contentLength);
        return fromByteArray;
    }

    public static void WriteString(this Plc plc, int db, int byteAdr, string value, byte n, Encoding s7Encoding)
    {
        byte[] bytes = s7Encoding.GetBytes(value);
        n = Math.Min(n, (byte)254);
        n = Math.Max(n, (byte)0);
        byte[] destArray = new byte[2 + n];
        destArray[0] = n;
        destArray[1] = Math.Min((byte)bytes.Length, n);
        Array.Copy(bytes, 0, destArray, 2, destArray[1]);
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, destArray);
    }

    /// <summary>
    /// 异步单点读取 S7-1200 PLC string 类型的数据【最多读取 254 个字节数据，溢出自动截断】
    /// </summary>
    /// <param name="plc">plc实例</param>
    /// <param name="db">DB号</param>
    /// <param name="byteAdr">起始地址</param>
    /// <param name="n">声明 string 时，string[n]，这里的 n 是实际可写入字符串的字节长度，在 plc 中分配的空间字节实际是 2+n</param>
    /// <param name="s7Encoding">字符串编码</param>
    /// <param name="cancellationToken">取消异步的 token</param>
    /// <returns></returns>
    public static async Task<string> ReadStringAsync(this Plc plc, int db, int byteAdr, int n, Encoding s7Encoding, CancellationToken cancellationToken = default)
    {
        if (n <= 0) return "";
        n = Math.Min(254, n);

        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, 2 + n, cancellationToken); // 这里保证了至少读取 2 个字节的数据

        int totalLength = bytes[0]; // 实际可写入字符串的字节数
        int contentLength = bytes[1]; // 实际写入字符串的字节数
        Console.WriteLine(contentLength);
        if (totalLength < contentLength) return ""; // 保险处理，避免之前针对 plc 的操作出现问题

        string fromByteArray = s7Encoding.GetString(bytes, 2, contentLength);
        return fromByteArray;
    }

    /// <summary>
    /// 异步单点写入 S7-1200 PLC string 类型的数据【最多写入 n 个字节数据，溢出自动截断】
    /// </summary>
    /// <param name="plc">plc实例</param>
    /// <param name="db">DB号</param>
    /// <param name="byteAdr">起始地址</param>
    /// <param name="value">写入的字符串</param>
    /// <param name="n">声明 string 时，string[n]，这里的 n 是实际可写入字符串的字节长度，在 plc 中分配的空间字节实际是 2+n</param>
    /// <param name="s7Encoding">字符串编码</param>
    /// <param name="cancellationToken">取消异步的 token</param>
    /// <returns></returns>
    public static async Task WriteStringAsync(this Plc plc, int db, int byteAdr, string value, byte n, Encoding s7Encoding, CancellationToken cancellationToken = default)
    {
        byte[] bytes = s7Encoding.GetBytes(value);
        // 1. 实际可写入字符串的字节数的范围是 [0, 254]
        n = Math.Min(n, (byte)254);
        n = Math.Max(n, (byte)0);
        // 2. 声明实际写入 PLC 的字节数据：2+n
        byte[] destArray = new byte[2 + n];
        // 3. 第一个字节是：实际可写入字符串的字节数
        destArray[0] = n;
        // 4. 第二个字节是：实际写入字符串的字节数
        destArray[1] = Math.Min((byte)bytes.Length, n); // 即使字符串的长度很长，这里自动截断到 n
        // 5. 填充剩余字节
        Array.Copy(bytes, 0, destArray, 2, destArray[1]);
        // 6. 写入 plc
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, destArray, cancellationToken);
    }
}
