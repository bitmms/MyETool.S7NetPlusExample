using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class WCharTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteWChar(1, 2166, '中');
        plc.WriteWChar(1, 2168, '国');

        Console.WriteLine("2. 开始同步读 ==========");
        Console.WriteLine(plc.ReadWChar(1, 2166));
        Console.WriteLine(plc.ReadWChar(1, 2168));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteWCharAsync(1, 2166, '你');
        await plc.WriteWCharAsync(1, 2168, '好');

        Console.WriteLine("4. 开始异步读 ==========");
        Console.WriteLine(await plc.ReadWCharAsync(1, 2166));
        Console.WriteLine(await plc.ReadWCharAsync(1, 2168));
    }
}
