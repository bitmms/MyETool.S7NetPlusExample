using System.Text;
using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /*
     * 在 S7 中，分配 String 采用：String 或 String[n]
     *      * 这里 n 大于等于1 且 小于等于 254，默认是 254
     *      * 这里的 n 表示可写入内容的字符数量
     *      * PLC 实际分配的字节数是 1 + 1 + n*1，需要2个头字节填充长度：最大写入字符数量 + 实际写入字符数量
     *      * PLC String 按照 Encoding.ASCII 处理单字节字符
     *      * PLC String 永远按 1 字符 = 1 字节 计算
     *      * PLC String 只支持单字节字符，只用 1 字节存储字符，包括头字节的长度也用 1 字节存储
     */

    private static readonly Encoding S7StringEncoding = Encoding.ASCII;

    /// <summary>
    /// 【同步】单点读取 String
    /// </summary>
    public static string ReadString(this Plc plc, int db, int byteAdr, int maxCharCount)
    {
        if (maxCharCount <= 0) return "";
        maxCharCount = Math.Min(254, maxCharCount);

        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, 2 + maxCharCount); // 这里保证了至少读取 2 个字节的数据

        int totalLength = bytes[0]; // 实际可写入字符串的字节数
        int contentLength = bytes[1]; // 实际写入字符串的字节数
        if (totalLength < contentLength) return ""; // 保险处理，避免之前针对 plc 的操作出现问题

        string fromByteArray = S7StringEncoding.GetString(bytes, 2, contentLength);
        return fromByteArray;
    }

    /// <summary>
    /// 【同步】批量读取连续的 String
    /// </summary>
    /// <returns></returns>
    public static string[] ReadString(this Plc plc, int db, int byteAdr, int count, byte maxCharCount)
    {
        if (maxCharCount <= 0) return [];
        maxCharCount = Math.Min((byte)254, maxCharCount);

        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, (2 + maxCharCount) * count); // 这里保证了至少读取 2 个字节的数据

        return S7ByteArrayToStringArray(bytes, maxCharCount);
    }

    /// <summary>
    /// 【同步】单点写入 String
    /// </summary>
    public static void WriteString(this Plc plc, int db, int byteAdr, string value, byte maxCharCount)
    {
        byte[] bytes = S7StringEncoding.GetBytes(value);
        maxCharCount = Math.Min(maxCharCount, (byte)254);
        maxCharCount = Math.Max(maxCharCount, (byte)0);
        byte[] destArray = new byte[2 + maxCharCount];
        destArray[0] = maxCharCount;
        destArray[1] = Math.Min((byte)bytes.Length, maxCharCount);
        Array.Copy(bytes, 0, destArray, 2, destArray[1]);
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, destArray);
    }

    /// <summary>
    /// 【同步】批量写入连续的 String
    /// </summary>
    public static void WriteString(this Plc plc, int db, int byteAdr, string[] values, byte maxCharCount)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, S7StringArrayToByteArray(values, maxCharCount));
    }

    /// <summary>
    /// 【异步】单点读取 String
    /// </summary>
    /// <param name="plc">plc实例</param>
    /// <param name="db">DB号</param>
    /// <param name="byteAdr">起始地址</param>
    /// <param name="maxCharCount">声明 string 时，string[n]，这里的 n 是实际可写入的字符数量，最多可写入 254 个字节数据，溢出自动截断</param>
    /// <param name="cancellationToken">取消异步的 token</param>
    /// <returns></returns>
    public static async Task<string> ReadStringAsync(this Plc plc, int db, int byteAdr, int maxCharCount, CancellationToken cancellationToken = default)
    {
        if (maxCharCount <= 0) return "";
        maxCharCount = Math.Min(254, maxCharCount);

        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, 2 + maxCharCount, cancellationToken); // 这里保证了至少读取 2 个字节的数据

        int totalLength = bytes[0]; // 实际可写入字符串的字节数
        int contentLength = bytes[1]; // 实际写入字符串的字节数
        if (totalLength < contentLength) return ""; // 保险处理，避免之前针对 plc 的操作出现问题

        string resultString = S7StringEncoding.GetString(bytes, 2, contentLength);
        return resultString;
    }

    /// <summary>
    /// 【异步】批量读取连续的 String
    /// </summary>
    /// <returns></returns>
    public static async Task<string[]> ReadStringAsync(this Plc plc, int db, int byteAdr, int count, byte maxCharCount, CancellationToken cancellationToken = default)
    {
        if (maxCharCount <= 0) return [];
        maxCharCount = Math.Min((byte)254, maxCharCount);

        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, (2 + maxCharCount) * count, cancellationToken); // 这里保证了至少读取 2 个字节的数据

        return S7ByteArrayToStringArray(bytes, maxCharCount);
    }

    /// <summary>
    /// 【异步】单点写入 String
    /// </summary>
    /// <param name="plc">plc实例</param>
    /// <param name="db">DB号</param>
    /// <param name="byteAdr">起始地址</param>
    /// <param name="value">写入的字符串</param>
    /// <param name="maxCharCount">声明 string 时，string[n]，这里的 n 是实际可写入的字符数量，最多可写入 254 个字节数据，溢出自动截断</param>
    /// <param name="cancellationToken">取消异步的 token</param>
    /// <returns></returns>
    public static async Task WriteStringAsync(this Plc plc, int db, int byteAdr, string value, byte maxCharCount, CancellationToken cancellationToken = default)
    {
        byte[] bytes = S7StringEncoding.GetBytes(value);
        // 1. 实际可写入字符串的字节数的范围是 [0, 254]
        maxCharCount = Math.Min(maxCharCount, (byte)254);
        maxCharCount = Math.Max(maxCharCount, (byte)0);
        // 2. 声明实际写入 PLC 的字节数据：2+n
        byte[] destArray = new byte[2 + maxCharCount];
        // 3. 第一个字节是：实际可写入字符串的字节数
        destArray[0] = maxCharCount;
        // 4. 第二个字节是：实际写入字符串的字节数
        destArray[1] = Math.Min((byte)bytes.Length, maxCharCount); // 即使字符串的长度很长，这里自动截断到 n
        // 5. 填充剩余字节
        Array.Copy(bytes, 0, destArray, 2, destArray[1]);
        // 6. 写入 plc
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, destArray, cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 String
    /// </summary>
    public static async Task WriteStringAsync(this Plc plc, int db, int byteAdr, string[] values, byte maxCharCount, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, S7StringArrayToByteArray(values, maxCharCount), cancellationToken);
    }

    private static byte[] S7StringArrayToByteArray(string[] stringArray, byte maxCharCount)
    {
        // 限制最大字符数 0~254
        maxCharCount = Math.Min(maxCharCount, (byte)254);
        maxCharCount = Math.Max(maxCharCount, (byte)0);

        int myIdx = 0;
        byte[] results = new byte[stringArray.Length * (2 + maxCharCount)];

        foreach (var stringItem in stringArray)
        {
            byte[] contentBytes = S7StringEncoding.GetBytes(stringItem);
            // 最大长度字节
            results[myIdx++] = maxCharCount;
            // 实际长度：严格限制在 0 ~ maxCharCount，避免byte溢出
            byte actualLen = Math.Min((byte)contentBytes.Length, maxCharCount);
            results[myIdx++] = actualLen;
            // 内容
            Array.Copy(contentBytes, 0, results, myIdx, actualLen);
            // 指针跳过整个字符区（不足部分自动补0）
            myIdx += maxCharCount;
        }

        return results;
    }

    private static string[] S7ByteArrayToStringArray(byte[] byteArray, byte maxCharCount)
    {
        int idx = 0;
        string[] results = new string[byteArray.Length / (2 + maxCharCount)];

        for (int i = 0; i < byteArray.Length; i += 2 + maxCharCount)
        {
            int totalLength = byteArray[i];
            int contentLength = byteArray[i + 1];
            results[idx++] = totalLength < contentLength ? "" : S7StringEncoding.GetString(byteArray, i + 2, contentLength);
        }

        return results;
    }
}
