using S7.Net;
using S7.Net.Types;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /// <summary>
    /// 在 S7 中  DInt = 4B = 32b
    /// 在 C# 中  Int32 = int = 4B = 32b
    /// </summary>
    private const int DIntBitLength = 32;

    public static int ReadDInt(this Plc plc, int db, int byteAdr)
    {
        byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, byteAdr, DIntBitLength / 8);
        int value = DInt.FromByteArray(bytes);
        return value;
    }

    public static void WriteDInt(this Plc plc, int db, int byteAdr, int value)
    {
        plc.WriteBytes(DataType.DataBlock, db, byteAdr, DInt.ToByteArray(value));
    }

    public static async Task<int> ReadDIntAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        byte[] bytes = await plc.ReadBytesAsync(DataType.DataBlock, db, byteAdr, DIntBitLength / 8, cancellationToken);
        int value = DInt.FromByteArray(bytes);
        return value;
    }

    public static async Task WriteDIntAsync(this Plc plc, int db, int byteAdr, int value, CancellationToken cancellationToken = default)
    {
        await plc.WriteBytesAsync(DataType.DataBlock, db, byteAdr, DInt.ToByteArray(value), cancellationToken);
    }
}
