using System.Text;
using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int CharByteLength = 1;

    /// <summary>
    /// 【同步】单点读取 Char
    /// </summary>
    public static char ReadChar(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, CharByteLength);
        char value = (char)bytes[0];
        return value;
    }

    /// <summary>
    /// 【同步】批量读取连续的 Char
    /// </summary>
    public static char[] ReadChar(this Plc plc, int db, int byteAdr, int count)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, CharByteLength * count);
        char[] values = new char[bytes.Length];
        for (int i = 0; i < bytes.Length; i++)
        {
            values[i] = (char)bytes[i];
        }

        return values;
    }

    /// <summary>
    /// 【同步】单点写入 Char
    /// </summary>
    public static void WriteChar(this Plc plc, int db, int byteAdr, char value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, [(byte)value]);
    }

    /// <summary>
    /// 【同步】批量写入连续的 Char
    /// </summary>
    public static void WriteChar(this Plc plc, int db, int byteAdr, char[] values)
    {
        byte[] bytes = new byte[values.Length];

        for (int i = 0; i < values.Length; i++)
        {
            bytes[i] = Encoding.BigEndianUnicode.GetBytes(values[i].ToString())[1];
        }

        plc.WriteBytes(DataType.DataBlock, db, byteAdr, bytes);
    }

    /// <summary>
    /// 【异步】单点读取 Char
    /// </summary>
    public static async Task<char> ReadCharAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, CharByteLength, cancellationToken);
        char value = (char)bytes[0];
        return value;
    }

    /// <summary>
    /// 【异步】批量读取连续的 Char
    /// </summary>
    public static async Task<char[]> ReadCharAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, CharByteLength * count, cancellationToken);
        char[] values = new char[bytes.Length];
        for (int i = 0; i < bytes.Length; i++)
        {
            values[i] = (char)bytes[i];
        }

        return values;
    }

    /// <summary>
    /// 【异步】单点写入 Char
    /// </summary>
    public static async Task WriteCharAsync(this Plc plc, int db, int byteAdr, char value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, [(byte)value], cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 Char
    /// </summary>
    public static async Task WriteCharAsync(this Plc plc, int db, int byteAdr, char[] values, CancellationToken cancellationToken = default)
    {
        byte[] bytes = new byte[values.Length];

        for (int i = 0; i < values.Length; i++)
        {
            bytes[i] = Encoding.BigEndianUnicode.GetBytes(values[i].ToString())[1];
        }

        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, bytes, cancellationToken);
    }
}
