using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int LRealByteLength = 8;

    /// <summary>
    /// 【同步】单点读取 LReal
    /// </summary>
    public static double ReadLReal(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, LRealByteLength);
        double value = LReal.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【同步】批量读取连续的 LReal
    /// </summary>
    public static double[] ReadLReal(this Plc plc, int db, int byteAdr, int count)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, LRealByteLength * count);
        double[] value = LReal.ToArray(bytes);
        return value;
    }

    /// <summary>
    /// 【同步】单点写入 LReal
    /// </summary>
    public static void WriteLReal(this Plc plc, int db, int byteAdr, double value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, LReal.ToByteArray(value));
    }

    /// <summary>
    /// 【同步】批量写入连续的 LReal
    /// </summary>
    public static void WriteLReal(this Plc plc, int db, int byteAdr, double[] values)
    {
        List<byte> list = [];
        foreach (var value in values)
        {
            byte[] array1 = LReal.ToByteArray(value);
            list.AddRange(array1);
        }

        plc.WriteBytes(DataType.DataBlock, db, byteAdr, list.ToArray());
    }

    /// <summary>
    /// 【异步】单点读取 LReal
    /// </summary>
    public static async Task<double> ReadLRealAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, LRealByteLength, cancellationToken);
        double value = LReal.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【异步】批量读取连续的 LReal
    /// </summary>
    public static async Task<double[]> ReadLRealAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, LRealByteLength * count, cancellationToken);
        double[] value = LReal.ToArray(bytes);
        return value;
    }

    /// <summary>
    /// 【异步】单点写入 LReal
    /// </summary>
    public static async Task WriteLRealAsync(this Plc plc, int db, int byteAdr, double value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, LReal.ToByteArray(value), cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 LReal
    /// </summary>
    public static async Task WriteLRealAsync(this Plc plc, int db, int byteAdr, double[] values, CancellationToken cancellationToken = default)
    {
        List<byte> list = [];
        foreach (var value in values)
        {
            byte[] array1 = LReal.ToByteArray(value);
            list.AddRange(array1);
        }

        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, list.ToArray(), cancellationToken);
    }
}
