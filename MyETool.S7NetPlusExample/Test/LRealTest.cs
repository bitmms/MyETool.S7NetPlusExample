using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class LRealTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteLReal(1, 48, 3.14);
        plc.WriteLReal(1, 56, 3.15);
        plc.WriteLReal(1, 64, 3.16);

        Console.WriteLine("2. 开始同步读 ==========");
        double double1 = plc.ReadLReal(1, 48);
        double double2 = plc.ReadLReal(1, 56);
        double double3 = plc.ReadLReal(1, 64);
        Console.WriteLine(double1);
        Console.WriteLine(double2);
        Console.WriteLine(double3);

        await Task.Delay(1000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteLRealAsync(1, 48, 8.661);
        await plc.WriteLRealAsync(1, 56, 8.662);
        await plc.WriteLRealAsync(1, 64, 8.663);

        Console.WriteLine("4. 开始异步读 ==========");
        double double4 = await plc.ReadLRealAsync(1, 48);
        double double5 = await plc.ReadLRealAsync(1, 56);
        double double6 = await plc.ReadLRealAsync(1, 64);
        Console.WriteLine(double4);
        Console.WriteLine(double5);
        Console.WriteLine(double6);
    }
}
