using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class RealTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 Real");
        plc.WriteReal(1, 2, 3.11f);
        plc.WriteReal(1, 6, 3.12f);
        plc.WriteReal(1, 10, 3.13f);
        plc.WriteReal(1, 14, 3.14f);
        plc.WriteReal(1, 18, 3.15f);
        plc.WriteReal(1, 22, 3.16f);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 Real");
        Console.WriteLine(plc.ReadReal(1, 2));
        Console.WriteLine(plc.ReadReal(1, 6));
        Console.WriteLine(plc.ReadReal(1, 10));
        Console.WriteLine(plc.ReadReal(1, 14));
        Console.WriteLine(plc.ReadReal(1, 18));
        Console.WriteLine(plc.ReadReal(1, 22));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 Real");
        plc.WriteReal(1, 2, [4.11f, 4.12f, 4.13f, 4.14f, 4.15f, 4.16f]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 Real");
        Console.WriteLine(string.Join(", ", plc.ReadReal(1, 2, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 Real");
        await plc.WriteRealAsync(1, 2, 5.11f);
        await plc.WriteRealAsync(1, 6, 5.12f);
        await plc.WriteRealAsync(1, 10, 5.13f);
        await plc.WriteRealAsync(1, 14, 5.14f);
        await plc.WriteRealAsync(1, 18, 5.15f);
        await plc.WriteRealAsync(1, 22, 5.16f);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 Real");
        Console.WriteLine(await plc.ReadRealAsync(1, 2));
        Console.WriteLine(await plc.ReadRealAsync(1, 6));
        Console.WriteLine(await plc.ReadRealAsync(1, 10));
        Console.WriteLine(await plc.ReadRealAsync(1, 14));
        Console.WriteLine(await plc.ReadRealAsync(1, 18));
        Console.WriteLine(await plc.ReadRealAsync(1, 22));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 Real");
        await plc.WriteRealAsync(1, 2, [6.11f, 6.12f, 6.13f, 6.14f, 6.15f, 6.16f]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 Real");
        Console.WriteLine(string.Join(", ", plc.ReadReal(1, 2, 6)));
    }
}
