using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class WStringTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteWString(1, 1142, "从明天起做一个幸福的人,喂马、劈柴,周游世界", 254);
        plc.WriteWString(1, 1654, "我有一所房子，面朝大海，春暖花开", 254);

        Console.WriteLine("2. 开始同步读 ==========");
        Console.WriteLine(plc.ReadWString(1, 1142, 256));
        Console.WriteLine(plc.ReadWString(1, 1654, 254));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteWStringAsync(1, 1142, "陌生人，我也为你祝福", 254);
        await plc.WriteWStringAsync(1, 1654, "愿你有一个灿烂的前程", 254);

        Console.WriteLine("4. 开始异步读 ==========");
        Console.WriteLine(await plc.ReadWStringAsync(1, 1142, 256));
        Console.WriteLine(await plc.ReadWStringAsync(1, 1654, 254));
    }
}
