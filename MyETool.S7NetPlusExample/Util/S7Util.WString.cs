using System.Text;
using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /*
     * 在 S7 中，分配 WString 采用：WString 或 WString[n]
     *      * 这里 n 大于等于1 且 小于等于 254，默认是 254
     *      * 这里的 n 表示可写入内容的字符数量
     *      * PLC 实际分配的字节数是 2 + 2 + n*2，需要4个头字节填充长度：最大写入字符数量 + 实际写入字符数量
     *      * WString 按照 Encoding.BigEndianUnicode 处理双字节字符
     *      * WString 永远按 1 字符 = 2 字节 计算
     *      * WString 只支持 Unicode 基本平面字符，只用 2 字节存储字符，包括头字节的长度也用 2 字节存储
     *      * WString 不支持 4 字节字符，写入 4 字节字符会直接乱码
     */

    private static readonly Encoding S7WStringEncoding = Encoding.BigEndianUnicode;

    public static string ReadWString(this Plc plc, int db, int byteAdr, int maxCharCount)
    {
        if (maxCharCount <= 0) return "";
        maxCharCount = Math.Min(254, maxCharCount);

        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, 4 + maxCharCount * 2);

        int totalLength = bytes[0] << 8 | bytes[1]; // 实际可写入字符串的字节数
        int contentLength = bytes[2] << 8 | bytes[3]; // 实际写入字符串的字节数
        if (totalLength < contentLength) return ""; // 保险处理，避免之前针对 plc 的操作出现问题

        string resultString = S7WStringEncoding.GetString(bytes, 4, contentLength * 2);
        return resultString;
    }

    public static void WriteWString(this Plc plc, int db, int byteAdr, string value, int maxCharCount)
    {
        byte[] bytes = S7WStringEncoding.GetBytes(value);

        // 1. 限制字符数：[0,254]
        maxCharCount = Math.Min(maxCharCount, 254);
        maxCharCount = Math.Max(maxCharCount, 0);

        // 2. 计算实际要写入的字符长度
        int actualCharCount = Math.Min(value.Length, maxCharCount);

        // 3. 创建字节数组：4字节头 + 最大字符数*2字节
        byte[] buffer = new byte[4 + maxCharCount * 2];

        // 4. 写入第1个Word：最大字符数（大端）
        buffer[0] = (byte)(maxCharCount >> 8); // int 4 字节，总共 32 位，右移 8 位，剩余 24 位，强转 byte 只取后 8 位，实现取高字节
        buffer[1] = (byte)(maxCharCount & 0xFF); // 利用与运算，实现取低字节

        // 5. 写入第2个Word：实际字符数（大端）
        buffer[2] = (byte)(actualCharCount >> 8); // 取高字节
        buffer[3] = (byte)(actualCharCount & 0xFF); // 取低字节

        // 6. 填充剩余字节
        Array.Copy(bytes, 0, buffer, 4, actualCharCount * 2);

        // 7. 写入PLC
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, buffer);
    }

    public static async Task<string> ReadWStringAsync(this Plc plc, int db, int byteAdr, int maxCharCount, CancellationToken cancellationToken = default)
    {
        if (maxCharCount <= 0) return "";
        maxCharCount = Math.Min(254, maxCharCount);

        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, 4 + maxCharCount * 2, cancellationToken);

        int totalLength = bytes[0] << 8 | bytes[1]; // 实际可写入字符串的字节数
        int contentLength = bytes[2] << 8 | bytes[3]; // 实际写入字符串的字节数
        if (totalLength < contentLength) return ""; // 保险处理，避免之前针对 plc 的操作出现问题

        string resultString = S7WStringEncoding.GetString(bytes, 4, contentLength * 2);
        return resultString;
    }

    public static async Task WriteWStringAsync(this Plc plc, int db, int byteAdr, string value, int maxCharCount, CancellationToken cancellationToken = default)
    {
        byte[] bytes = S7WStringEncoding.GetBytes(value);

        // 1. 限制字符数：[0,254]
        maxCharCount = Math.Min(maxCharCount, 254);
        maxCharCount = Math.Max(maxCharCount, 0);

        // 2. 计算实际要写入的字符长度
        int actualCharCount = Math.Min(value.Length, maxCharCount);

        // 3. 创建字节数组：4字节头 + 最大字符数*2字节
        byte[] buffer = new byte[4 + maxCharCount * 2];

        // 4. 写入第1个Word：最大字符数（大端）
        buffer[0] = (byte)(maxCharCount >> 8); // int 4 字节，总共 32 位，右移 8 位，剩余 24 位，强转 byte 只取后 8 位，实现取高字节
        buffer[1] = (byte)(maxCharCount & 0xFF); // 利用与运算，实现取低字节

        // 5. 写入第2个Word：实际字符数（大端）
        buffer[2] = (byte)(actualCharCount >> 8); // 取高字节
        buffer[3] = (byte)(actualCharCount & 0xFF); // 取低字节

        // 6. 填充剩余字节
        Array.Copy(bytes, 0, buffer, 4, actualCharCount * 2);

        // 7. 写入PLC
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, buffer, cancellationToken);
    }
}
