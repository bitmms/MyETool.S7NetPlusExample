using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class WCharTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 WChar");
        plc.WriteWChar(1, 170, 'a');
        plc.WriteWChar(1, 172, 'b');
        plc.WriteWChar(1, 174, '中');
        plc.WriteWChar(1, 176, '国');
        plc.WriteWChar(1, 178, '1');
        plc.WriteWChar(1, 180, '2');

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 WChar");
        Console.WriteLine(plc.ReadWChar(1, 170));
        Console.WriteLine(plc.ReadWChar(1, 172));
        Console.WriteLine(plc.ReadWChar(1, 174));
        Console.WriteLine(plc.ReadWChar(1, 176));
        Console.WriteLine(plc.ReadWChar(1, 178));
        Console.WriteLine(plc.ReadWChar(1, 180));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 WChar");
        plc.WriteWChar(1, 170, ['c', 'd', '你', '好', '3', '4']);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 WChar");
        Console.WriteLine(string.Join(", ", plc.ReadWChar(1, 170, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 WChar");
        await plc.WriteWCharAsync(1, 170, 'a');
        await plc.WriteWCharAsync(1, 172, 'b');
        await plc.WriteWCharAsync(1, 174, '中');
        await plc.WriteWCharAsync(1, 176, '国');
        await plc.WriteWCharAsync(1, 178, '1');
        await plc.WriteWCharAsync(1, 180, '2');

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 WChar");
        Console.WriteLine(await plc.ReadWCharAsync(1, 170));
        Console.WriteLine(await plc.ReadWCharAsync(1, 172));
        Console.WriteLine(await plc.ReadWCharAsync(1, 174));
        Console.WriteLine(await plc.ReadWCharAsync(1, 176));
        Console.WriteLine(await plc.ReadWCharAsync(1, 178));
        Console.WriteLine(await plc.ReadWCharAsync(1, 180));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 WChar");
        await plc.WriteWCharAsync(1, 170, ['c', 'd', '你', '好', '3', '4']);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 WChar");
        Console.WriteLine(string.Join(", ", await plc.ReadWCharAsync(1, 170, 6)));
    }
}
