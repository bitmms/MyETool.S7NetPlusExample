using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /// <summary>
    /// 在 S7 中  Bool = 1b
    /// 在 C# 中  bool = 1B = 8b
    /// </summary>
    private const int BoolBitLength = 1;

    /// <summary>
    /// 【同步】单点读取 Bool
    /// </summary>
    public static bool ReadBool(this Plc plc, int db, int byteAdr, byte bitAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, BoolBitLength);
        bool value = Bit.FromByte(bytes[0], bitAdr);
        return value;
    }

    /// <summary>
    /// 【同步】批量读取连续的 Bool
    /// </summary>
    public static bool[] ReadBool(this Plc plc, int db, int byteAdr, byte bitAdr, int count)
    {
        // 从 bitAdr 开始，读 count 个 bit，一共需要读取 bitAdr + count 个 bit
        int totalBit = bitAdr + count;
        int byteCount = totalBit / 8 + (totalBit % 8 == 0 ? 0 : 1);

        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, byteCount);

        bool[] results = new bool[count];

        int startByteIndex = 0; // 字节从 0 开启
        byte startBitIndex = bitAdr; // bit 从传入的起始位开始，范围是 0-7

        int cnt = 0;
        while (true)
        {
            bool b = Bit.FromByte(bytes[startByteIndex], startBitIndex++);
            results[cnt++] = b;
            if (startBitIndex == 8)
            {
                startByteIndex++;
                startBitIndex = 0;
            }

            if (cnt == count) break;
        }

        return results;
    }

    /// <summary>
    /// 【同步】单点写入 Bool
    /// </summary>
    public static void WriteBool(this Plc plc, int db, int byteAdr, byte bitAdr, bool value)
    {
        plc.WriteBit(DataType.DataBlock, db, byteAdr, bitAdr, value);
    }

    /// <summary>
    /// 【同步】批量写入连续的 Bool
    /// </summary>
    public static void WriteBool(this Plc plc, int db, int byteAdr, byte bitAdr, bool[] values)
    {
        int startByteIndex = byteAdr;
        int startBitIndex = bitAdr;
        foreach (var value in values)
        {
            plc.WriteBit(DataType.DataBlock, db, startByteIndex, startBitIndex, value);
            startBitIndex++;
            if (startBitIndex == 8)
            {
                startByteIndex++;
                startBitIndex = 0;
            }
        }
    }

    /// <summary>
    /// 【异步】单点读取 Bool
    /// </summary>
    public static async Task<bool> ReadBoolAsync(this Plc plc, int db, int byteAdr, byte bitAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, BoolBitLength, cancellationToken);
        bool value = Bit.FromByte(bytes[0], bitAdr);
        return value;
    }

    /// <summary>
    /// 【异步】批量读取连续的 Bool
    /// </summary>
    public static async Task<bool[]> ReadBoolAsync(this Plc plc, int db, int byteAdr, byte bitAdr, int count, CancellationToken cancellationToken = default)
    {
        // 从 bitAdr 开始，读 count 个 bit，一共需要读取 bitAdr + count 个 bit
        int totalBit = bitAdr + count;
        int byteCount = totalBit / 8 + (totalBit % 8 == 0 ? 0 : 1);

        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, byteCount, cancellationToken);

        bool[] results = new bool[count];

        int startByteIndex = 0; // 字节从 0 开启
        byte startBitIndex = bitAdr; // bit 从传入的起始位开始，范围是 0-7

        int cnt = 0;
        while (true)
        {
            bool b = Bit.FromByte(bytes[startByteIndex], startBitIndex++);
            results[cnt++] = b;
            if (startBitIndex == 8)
            {
                startByteIndex++;
                startBitIndex = 0;
            }

            if (cnt == count) break;
        }

        return results;
    }

    /// <summary>
    /// 【异步】单点写入 Bool
    /// </summary>
    public static async Task WriteBoolAsync(this Plc plc, int db, int byteAdr, byte bitAdr, bool value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBitAsync(DataType.DataBlock, db, byteAdr, bitAdr, value, cancellationToken);
    }

    /// <summary>
    /// 【异步】批量写入连续的 Bool
    /// </summary>
    public static async Task WriteBoolAsync(this Plc plc, int db, int byteAdr, byte bitAdr, bool[] values, CancellationToken cancellationToken = default)
    {
        int startByteIndex = byteAdr;
        int startBitIndex = bitAdr;
        foreach (var value in values)
        {
            await plc.WriteBitAsync(DataType.DataBlock, db, startByteIndex, startBitIndex, value, cancellationToken);
            startBitIndex++;
            if (startBitIndex == 8)
            {
                startByteIndex++;
                startBitIndex = 0;
            }
        }
    }
}
