using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class DWordTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteDWordByUInt(1, 24, 1001);
        plc.WriteDWordByUInt(1, 28, 1002);
        plc.WriteDWordByUInt(1, 32, 1003);

        Console.WriteLine("2. 开始同步读 ==========");
        uint uint1 = plc.ReadDWordAsUInt(1, 24);
        uint uint2 = plc.ReadDWordAsUInt(1, 28);
        uint uint3 = plc.ReadDWordAsUInt(1, 32);
        Console.WriteLine(uint1);
        Console.WriteLine(uint2);
        Console.WriteLine(uint3);

        await Task.Delay(1000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteDWordByUIntAsync(1, 24, 101);
        await plc.WriteDWordByUIntAsync(1, 28, 102);
        await plc.WriteDWordByUIntAsync(1, 32, 103);

        Console.WriteLine("4. 开始异步读 ==========");
        uint uint4 = await plc.ReadDWordAsUIntAsync(1, 24);
        uint uint5 = await plc.ReadDWordAsUIntAsync(1, 28);
        uint uint6 = await plc.ReadDWordAsUIntAsync(1, 32);
        Console.WriteLine(uint4);
        Console.WriteLine(uint5);
        Console.WriteLine(uint6);
    }
}
