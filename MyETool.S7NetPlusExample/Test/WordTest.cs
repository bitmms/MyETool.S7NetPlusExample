using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class WordTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteWord(1, 18, 1001);
        plc.WriteWord(1, 20, 1002);
        plc.WriteWord(1, 22, 1003);

        Console.WriteLine("2. 开始同步读 ==========");
        ushort ushort1 = plc.ReadWord(1, 18);
        ushort ushort2 = plc.ReadWord(1, 20);
        ushort ushort3 = plc.ReadWord(1, 22);
        Console.WriteLine(ushort1);
        Console.WriteLine(ushort2);
        Console.WriteLine(ushort3);

        await Task.Delay(1000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteWordAsync(1, 18, 101);
        await plc.WriteWordAsync(1, 20, 102);
        await plc.WriteWordAsync(1, 22, 103);

        Console.WriteLine("4. 开始异步读 ==========");
        ushort ushort4 = await plc.ReadWordAsync(1, 18);
        ushort ushort5 = await plc.ReadWordAsync(1, 20);
        ushort ushort6 = await plc.ReadWordAsync(1, 22);
        Console.WriteLine(ushort4);
        Console.WriteLine(ushort5);
        Console.WriteLine(ushort6);
    }
}
