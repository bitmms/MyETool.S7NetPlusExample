using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int DIntByteLength = 4;

    /// <summary>
    /// 【同步】单点读取 DInt
    /// </summary>
    public static int ReadDInt(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, DIntByteLength);
        int value = DInt.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【同步】批量读取连续的 DInt
    /// </summary>
    public static int[] ReadDInt(this Plc plc, int db, int byteAdr, int count)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, DIntByteLength * count);
        int[] values = DInt.ToArray(bytes);
        return values;
    }

    /// <summary>
    /// 【同步】单点写入 DInt
    /// </summary>
    public static void WriteDInt(this Plc plc, int db, int byteAdr, int value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, DInt.ToByteArray(value));
    }

    /// <summary>
    /// 【同步】批量写入连续的 DInt
    /// </summary>
    public static void WriteDInt(this Plc plc, int db, int byteAdr, int[] values)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, DInt.ToByteArray(values));
    }

    /// <summary>
    /// 【异步】单点读取 DInt
    /// </summary>
    public static async Task<int> ReadDIntAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, DIntByteLength, cancellationToken);
        int value = DInt.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【异步】批量读取连续的 DInt
    /// </summary>
    public static async Task<int[]> ReadDIntAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, DIntByteLength * count, cancellationToken);
        int[] values = DInt.ToArray(bytes);
        return values;
    }

    /// <summary>
    /// 【异步】单点写入 DInt
    /// </summary>
    public static async Task WriteDIntAsync(this Plc plc, int db, int byteAdr, int value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, DInt.ToByteArray(value), cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 DInt
    /// </summary>
    public static async Task WriteDIntAsync(this Plc plc, int db, int byteAdr, int[] values, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, DInt.ToByteArray(values), cancellationToken);
    }
}
