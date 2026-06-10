using S7.Net;

namespace MyETool.S7NetPlusExample.Util;

public static partial class S7Util
{
    /*
     * 在 S7 中  Byte = USInt = 1B = 8b，[0,255]
     * 在 C# 中  byte = 1B = 8b，[0,255]
     */

    public static byte ReadUsInt(this Plc plc, int db, int byteAdr)
    {
        return plc.ReadByte(db, byteAdr);
    }

    public static void WriteUsInt(this Plc plc, int db, int byteAdr, byte value)
    {
        plc.WriteByte(db, byteAdr, value);
    }

    public static async Task<byte> ReadUsIntAsync(this Plc plc, int db, int byteAdr, CancellationToken cancellationToken = default)
    {
        return await plc.ReadByteAsync(db, byteAdr, cancellationToken);
    }

    public static async Task WriteUsIntAsync(this Plc plc, int db, int byteAdr, byte value, CancellationToken cancellationToken = default)
    {
        await plc.WriteByteAsync(db, byteAdr, value, cancellationToken);
    }
}
