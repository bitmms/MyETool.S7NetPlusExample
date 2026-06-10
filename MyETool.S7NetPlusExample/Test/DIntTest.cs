using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class DIntTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteDInt(1, 4, 1001);
        plc.WriteDInt(1, 8, 1002);
        plc.WriteDInt(1, 12, 1003);

        Console.WriteLine("2. 开始同步读 ==========");
        int i1 = plc.ReadDInt(1, 4);
        int i2 = plc.ReadDInt(1, 8);
        int i3 = plc.ReadDInt(1, 12);
        Console.WriteLine(i1);
        Console.WriteLine(i2);
        Console.WriteLine(i3);

        await Task.Delay(1000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteDIntAsync(1, 4, 5001);
        await plc.WriteDIntAsync(1, 8, 5002);
        await plc.WriteDIntAsync(1, 12, 5003);

        Console.WriteLine("4. 开始异步读 ==========");
        int i4 = await plc.ReadDIntAsync(1, 4);
        int i5 = await plc.ReadDIntAsync(1, 8);
        int i6 = await plc.ReadDIntAsync(1, 12);
        Console.WriteLine(i4);
        Console.WriteLine(i5);
        Console.WriteLine(i6);
    }
}
