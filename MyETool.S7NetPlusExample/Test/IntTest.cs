using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class IntTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteInt(1, 172, 1001);
        plc.WriteInt(1, 174, 1002);
        plc.WriteInt(1, 176, 1003);

        Console.WriteLine("2. 开始同步读 ==========");
        short short1 = plc.ReadInt(1, 172);
        short short2 = plc.ReadInt(1, 174);
        short short3 = plc.ReadInt(1, 176);
        Console.WriteLine(short1);
        Console.WriteLine(short2);
        Console.WriteLine(short3);

        await Task.Delay(1000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteIntAsync(1, 172, 3001);
        await plc.WriteIntAsync(1, 174, 3002);
        await plc.WriteIntAsync(1, 176, 3003);

        Console.WriteLine("4. 开始异步读 ==========");
        short short4 = await plc.ReadIntAsync(1, 172);
        short short5 = await plc.ReadIntAsync(1, 174);
        short short6 = await plc.ReadIntAsync(1, 176);
        Console.WriteLine(short4);
        Console.WriteLine(short5);
        Console.WriteLine(short6);
    }
}
