using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class RealTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteReal(1, 36, 3.14f);
        plc.WriteReal(1, 40, 3.15f);
        plc.WriteReal(1, 44, 3.16f);

        Console.WriteLine("2. 开始同步读 ==========");
        float float1 = plc.ReadReal(1, 36);
        float float2 = plc.ReadReal(1, 40);
        float float3 = plc.ReadReal(1, 44);
        Console.WriteLine(float1);
        Console.WriteLine(float2);
        Console.WriteLine(float3);

        await Task.Delay(1000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteRealAsync(1, 36, 6.661f);
        await plc.WriteRealAsync(1, 40, 6.662f);
        await plc.WriteRealAsync(1, 44, 6.663f);

        Console.WriteLine("4. 开始异步读 ==========");
        float float4 = await plc.ReadRealAsync(1, 36);
        float float5 = await plc.ReadRealAsync(1, 40);
        float float6 = await plc.ReadRealAsync(1, 44);
        Console.WriteLine(float4);
        Console.WriteLine(float5);
        Console.WriteLine(float6);
    }
}
