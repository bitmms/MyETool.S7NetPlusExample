using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class CharTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 Char");
        plc.WriteChar(1, 164, 'a');
        plc.WriteChar(1, 165, 'b');
        plc.WriteChar(1, 166, '中');
        plc.WriteChar(1, 167, '国');
        plc.WriteChar(1, 168, '1');
        plc.WriteChar(1, 169, '2');

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 Char");
        Console.WriteLine(plc.ReadChar(1, 164));
        Console.WriteLine(plc.ReadChar(1, 165));
        Console.WriteLine(plc.ReadChar(1, 166));
        Console.WriteLine(plc.ReadChar(1, 167));
        Console.WriteLine(plc.ReadChar(1, 168));
        Console.WriteLine(plc.ReadChar(1, 169));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 Char");
        plc.WriteChar(1, 164, ['c', 'd', '你', '好', '3', '4']);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 Char");
        Console.WriteLine(string.Join(", ", plc.ReadChar(1, 164, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 Char");
        await plc.WriteCharAsync(1, 164, 'a');
        await plc.WriteCharAsync(1, 165, 'b');
        await plc.WriteCharAsync(1, 166, '中');
        await plc.WriteCharAsync(1, 167, '国');
        await plc.WriteCharAsync(1, 168, '1');
        await plc.WriteCharAsync(1, 169, '2');

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 Char");
        Console.WriteLine(await plc.ReadCharAsync(1, 164));
        Console.WriteLine(await plc.ReadCharAsync(1, 165));
        Console.WriteLine(await plc.ReadCharAsync(1, 166));
        Console.WriteLine(await plc.ReadCharAsync(1, 167));
        Console.WriteLine(await plc.ReadCharAsync(1, 168));
        Console.WriteLine(await plc.ReadCharAsync(1, 169));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 Char");
        await plc.WriteCharAsync(1, 164, ['c', 'd', '你', '好', '3', '4']);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 Char");
        Console.WriteLine(string.Join(", ", await plc.ReadCharAsync(1, 164, 6)));
    }
}
