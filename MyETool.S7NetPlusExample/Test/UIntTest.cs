using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class UIntTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteUInt(1, 0, 31);
        plc.WriteUInt(1, 2, 32);
        plc.WriteUInt(1, 4, 33);

        Console.WriteLine("2. 开始同步读 ==========");
        uint b1 = plc.ReadUInt(1, 0);
        uint b2 = plc.ReadUInt(1, 2);
        uint b3 = plc.ReadUInt(1, 4);
        Console.WriteLine(b1);
        Console.WriteLine(b2);
        Console.WriteLine(b3);

        await Task.Delay(1000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteUIntAsync(1, 0, 61);
        await plc.WriteUIntAsync(1, 2, 62);
        await plc.WriteUIntAsync(1, 4, 63);

        Console.WriteLine("4. 开始异步读 ==========");
        uint b4 = await plc.ReadUIntAsync(1, 0);
        uint b5 = await plc.ReadUIntAsync(1, 2);
        uint b6 = await plc.ReadUIntAsync(1, 4);
        Console.WriteLine(b4);
        Console.WriteLine(b5);
        Console.WriteLine(b6);
    }
}
