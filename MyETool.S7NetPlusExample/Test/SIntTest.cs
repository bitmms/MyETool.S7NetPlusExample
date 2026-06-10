using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class SIntTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteSInt(1, 2173, -31);
        plc.WriteSInt(1, 2174, 32);
        plc.WriteSInt(1, 2175, -33);

        Console.WriteLine("2. 开始同步读 ==========");
        sbyte sint1 = plc.ReadSInt(1, 2173);
        sbyte sint2 = plc.ReadSInt(1, 2174);
        sbyte sint3 = plc.ReadSInt(1, 2175);
        Console.WriteLine(sint1);
        Console.WriteLine(sint2);
        Console.WriteLine(sint3);

        await Task.Delay(1000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteSIntAsync(1, 2173, 61);
        await plc.WriteSIntAsync(1, 2174, -62);
        await plc.WriteSIntAsync(1, 2175, 63);

        Console.WriteLine("4. 开始异步读 ==========");
        sbyte sint4 = await plc.ReadSIntAsync(1, 2173);
        sbyte sint5 = await plc.ReadSIntAsync(1, 2174);
        sbyte sint6 = await plc.ReadSIntAsync(1, 2175);
        Console.WriteLine(sint4);
        Console.WriteLine(sint5);
        Console.WriteLine(sint6);
    }
}
