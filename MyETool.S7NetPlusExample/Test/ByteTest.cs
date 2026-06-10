using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class ByteTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteByte(1, 486, 31);
        plc.WriteByte(1, 487, 32);
        plc.WriteByte(1, 488, 33);

        Console.WriteLine("2. 开始同步读 ==========");
        byte b1 = plc.ReadByte(1, 486);
        byte b2 = plc.ReadByte(1, 487);
        byte b3 = plc.ReadByte(1, 488);
        Console.WriteLine(b1);
        Console.WriteLine(b2);
        Console.WriteLine(b3);

        await Task.Delay(1000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteByteAsync(1, 486, 61);
        await plc.WriteByteAsync(1, 487, 62);
        await plc.WriteByteAsync(1, 488, 63);

        Console.WriteLine("4. 开始异步读 ==========");
        byte b4 = await plc.ReadByteAsync(1, 486);
        byte b5 = await plc.ReadByteAsync(1, 487);
        byte b6 = await plc.ReadByteAsync(1, 488);
        Console.WriteLine(b4);
        Console.WriteLine(b5);
        Console.WriteLine(b6);
    }
}
