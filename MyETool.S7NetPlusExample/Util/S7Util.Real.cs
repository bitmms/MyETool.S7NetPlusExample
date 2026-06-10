using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int RealByteLength = 4;

    /// <summary>
    /// 【同步】单点读取 Real
    /// </summary>
    public static float ReadReal(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, RealByteLength);
        float value = Real.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【同步】批量读取连续的 Real
    /// </summary>
    public static float[] ReadReal(this Plc plc, int db, int byteAdr, int count)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, count * RealByteLength);
        float[] value = Real.ToArray(bytes);
        return value;
    }

    /// <summary>
    /// 【同步】单点写入 Real
    /// </summary>
    public static void WriteReal(this Plc plc, int db, int byteAdr, float value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, Real.ToByteArray(value));
    }

    /// <summary>
    /// 【同步】批量写入连续的 Real
    /// </summary>
    public static void WriteReal(this Plc plc, int db, int byteAdr, float[] values)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, Real.ToByteArray(values));
    }

    /// <summary>
    /// 【异步】单点读取 Real
    /// </summary>
    public static async Task<float> ReadRealAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, RealByteLength, cancellationToken);
        float value = Real.FromByteArray(bytes);
        return value;
    }

    /// <summary>
    /// 【异步】批量读取连续的 Real
    /// </summary>
    public static async Task<float[]> ReadRealAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, count * RealByteLength, cancellationToken);
        float[] value = Real.ToArray(bytes);
        return value;
    }

    /// <summary>
    /// 【异步】单点写入 Real
    /// </summary>
    public static async Task WriteRealAsync(this Plc plc, int db, int byteAdr, float value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Real.ToByteArray(value), cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 Real
    /// </summary>
    public static async Task WriteRealAsync(this Plc plc, int db, int byteAdr, float[] values, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, Real.ToByteArray(values), cancellationToken);
    }
}
