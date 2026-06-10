using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class LRealTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 LReal");
        plc.WriteLReal(1, 26, 3.11);
        plc.WriteLReal(1, 34, 3.12);
        plc.WriteLReal(1, 42, 3.13);
        plc.WriteLReal(1, 50, 3.14);
        plc.WriteLReal(1, 58, 3.15);
        plc.WriteLReal(1, 66, 3.16);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 LReal");
        Console.WriteLine(plc.ReadLReal(1, 26));
        Console.WriteLine(plc.ReadLReal(1, 34));
        Console.WriteLine(plc.ReadLReal(1, 42));
        Console.WriteLine(plc.ReadLReal(1, 50));
        Console.WriteLine(plc.ReadLReal(1, 58));
        Console.WriteLine(plc.ReadLReal(1, 66));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 LReal");
        plc.WriteLReal(1, 26, [4.11, 4.12, 4.13, 4.14, 4.15, 4.16]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 LReal");
        Console.WriteLine(string.Join(", ", plc.ReadLReal(1, 26, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 LReal");
        await plc.WriteLRealAsync(1, 26, 5.11);
        await plc.WriteLRealAsync(1, 34, 5.12);
        await plc.WriteLRealAsync(1, 42, 5.13);
        await plc.WriteLRealAsync(1, 50, 5.14);
        await plc.WriteLRealAsync(1, 58, 5.15);
        await plc.WriteLRealAsync(1, 66, 5.16);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 LReal");
        Console.WriteLine(await plc.ReadLRealAsync(1, 26));
        Console.WriteLine(await plc.ReadLRealAsync(1, 34));
        Console.WriteLine(await plc.ReadLRealAsync(1, 42));
        Console.WriteLine(await plc.ReadLRealAsync(1, 50));
        Console.WriteLine(await plc.ReadLRealAsync(1, 58));
        Console.WriteLine(await plc.ReadLRealAsync(1, 66));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 LReal");
        await plc.WriteLRealAsync(1, 26, [6.11, 6.12, 6.13, 6.14, 6.15, 6.16]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 LReal");
        Console.WriteLine(string.Join(", ", await plc.ReadLRealAsync(1, 26, 6)));
    }
}
