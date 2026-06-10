using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /// <summary>
    /// 在 S7 中  Date = 2B = 16b，存的是「从 1990-01-01 算起的天数」，存储的是一个数值
    /// 在 C# 中  UInt16 = ushort = 2B = 16b --->>> DateOnly 或者 DateTime
    /// </summary>
    private const int DateBitLength = 16;

    public static DateOnly ReadDate(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, DateBitLength / 8);
        // 大端转天数
        ushort days = (ushort)((bytes[0] << 8) | bytes[1]);
        // 转 DateOnly（只有日期，无时间）
        DateOnly baseDate = new DateOnly(1990, 1, 1);
        DateOnly plcDate = baseDate.AddDays(days);
        return plcDate;
    }

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

    public static async Task<DateOnly> ReadDateAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, DateBitLength / 8, cancellationToken);
        // 大端转天数
        ushort days = (ushort)((bytes[0] << 8) | bytes[1]);
        // 转 DateOnly（只有日期，无时间）
        DateOnly baseDate = new DateOnly(1990, 1, 1);
        DateOnly plcDate = baseDate.AddDays(days);
        return plcDate;
    }

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
}
