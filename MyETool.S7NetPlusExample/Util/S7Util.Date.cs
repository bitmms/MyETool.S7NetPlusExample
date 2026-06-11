using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    private const int DateByteLength = 2;

    /// <summary>
    /// 【同步】单点读取 Date
    /// </summary>
    public static DateOnly ReadDate(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, DateByteLength);
        // 大端转天数
        ushort days = (ushort)((bytes[0] << 8) | bytes[1]);
        // 转 DateOnly（只有日期，无时间）
        DateOnly baseDate = new DateOnly(1990, 1, 1);
        DateOnly plcDate = baseDate.AddDays(days);
        return plcDate;
    }

    /// <summary>
    /// 【同步】批量读取连续的 Date
    /// </summary>
    public static DateOnly[] ReadDate(this Plc plc, int db, int byteAdr, int count)
    {
        DateOnly[] dateOnlyArray = new DateOnly[count];

        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, DateByteLength * count);

        for (int i = 0; i < count * 2; i += 2)
        {
            // 大端转天数
            ushort days = (ushort)((bytes[i] << 8) | bytes[i + 1]);
            // 转 DateOnly（只有日期，无时间）
            DateOnly baseDate = new DateOnly(1990, 1, 1);
            DateOnly plcDate = baseDate.AddDays(days);
            dateOnlyArray[i / 2] = plcDate;
        }

        return dateOnlyArray;
    }

    /// <summary>
    /// 【同步】单点写入 Date
    /// </summary>
    public static void WriteDate(this Plc plc, int db, int byteAdr, DateOnly value)
    {
        // 1. 计算天数
        DateOnly baseDate = new DateOnly(1990, 1, 1);
        ushort days = (ushort)(value.DayNumber - baseDate.DayNumber);
        // 2. 大端格式
        byte[] bytes = new byte[2];
        bytes[0] = (byte)(days >> 8);
        bytes[1] = (byte)(days & 0xFF);
        // 3. 写入PLC
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, bytes);
    }

    /// <summary>
    /// 【同步】批量写入连续的 Date
    /// </summary>
    public static void WriteDate(this Plc plc, int db, int byteAdr, DateOnly[] values)
    {
        int idx = 0;
        byte[] results = new byte[values.Length * DateByteLength];
        foreach (var value in values)
        {
            // 1. 计算天数
            DateOnly baseDate = new DateOnly(1990, 1, 1);
            ushort days = (ushort)(value.DayNumber - baseDate.DayNumber);
            // 2. 大端格式
            byte[] bytes = new byte[2];
            bytes[0] = (byte)(days >> 8);
            bytes[1] = (byte)(days & 0xFF);
            // 3. 填充
            results[idx++] = bytes[0];
            results[idx++] = bytes[1];
        }

        plc.WriteBytes(DataType.DataBlock, db, byteAdr, results);
    }

    /// <summary>
    /// 【异步】单点读取 Date
    /// </summary>
    public static async Task<DateOnly> ReadDateAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, DateByteLength, cancellationToken);
        // 大端转天数
        ushort days = (ushort)((bytes[0] << 8) | bytes[1]);
        // 转 DateOnly（只有日期，无时间）
        DateOnly baseDate = new DateOnly(1990, 1, 1);
        DateOnly plcDate = baseDate.AddDays(days);
        return plcDate;
    }

    /// <summary>
    /// 【异步】批量读取连续的 Date
    /// </summary>
    public static async Task<DateOnly[]> ReadDateAsync(this Plc plc, int db, int byteAdr, int count, CancellationToken cancellationToken = default)
    {
        DateOnly[] dateOnlyArray = new DateOnly[count];

        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, DateByteLength * count, cancellationToken);

        for (int i = 0; i < count * 2; i += 2)
        {
            // 大端转天数
            ushort days = (ushort)((bytes[i] << 8) | bytes[i + 1]);
            // 转 DateOnly（只有日期，无时间）
            DateOnly baseDate = new DateOnly(1990, 1, 1);
            DateOnly plcDate = baseDate.AddDays(days);
            dateOnlyArray[i / 2] = plcDate;
        }

        return dateOnlyArray;
    }

    /// <summary>
    /// 【异步】单点写入 Date
    /// </summary>
    public static async Task WriteDateAsync(this Plc plc, int db, int byteAdr, DateOnly value, CancellationToken cancellationToken = default)
    {
        // 1. 计算天数
        DateOnly baseDate = new DateOnly(1990, 1, 1);
        ushort days = (ushort)(value.DayNumber - baseDate.DayNumber);
        // 2. 大端格式
        byte[] bytes = new byte[2];
        bytes[0] = (byte)(days >> 8);
        bytes[1] = (byte)(days & 0xFF);
        // 3. 写入PLC
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, bytes, cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 Date
    /// </summary>
    public static async Task WriteDateAsync(this Plc plc, int db, int byteAdr, DateOnly[] values, CancellationToken cancellationToken = default)
    {
        int idx = 0;
        byte[] results = new byte[values.Length * DateByteLength];
        foreach (var value in values)
        {
            // 1. 计算天数
            DateOnly baseDate = new DateOnly(1990, 1, 1);
            ushort days = (ushort)(value.DayNumber - baseDate.DayNumber);
            // 2. 大端格式
            byte[] bytes = new byte[2];
            bytes[0] = (byte)(days >> 8);
            bytes[1] = (byte)(days & 0xFF);
            // 3. 填充
            results[idx++] = bytes[0];
            results[idx++] = bytes[1];
        }

        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, results, cancellationToken);
    }
}
