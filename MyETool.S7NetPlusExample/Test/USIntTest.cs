using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class UsIntTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 USInt");
        plc.WriteUsInt(1, 146, 111);
        plc.WriteUsInt(1, 147, 112);
        plc.WriteUsInt(1, 148, 113);
        plc.WriteUsInt(1, 149, 114);
        plc.WriteUsInt(1, 150, 115);
        plc.WriteUsInt(1, 151, 116);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 USInt");
        Console.WriteLine(plc.ReadUsInt(1, 146));
        Console.WriteLine(plc.ReadUsInt(1, 147));
        Console.WriteLine(plc.ReadUsInt(1, 148));
        Console.WriteLine(plc.ReadUsInt(1, 149));
        Console.WriteLine(plc.ReadUsInt(1, 150));
        Console.WriteLine(plc.ReadUsInt(1, 151));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 USInt");
        plc.WriteUsInt(1, 146, [121, 122, 123, 124, 125, 126]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 USInt");
        Console.WriteLine(string.Join(",", plc.ReadUsInt(1, 146, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 USInt");
        await plc.WriteUsIntAsync(1, 146, 131);
        await plc.WriteUsIntAsync(1, 147, 132);
        await plc.WriteUsIntAsync(1, 148, 133);
        await plc.WriteUsIntAsync(1, 149, 134);
        await plc.WriteUsIntAsync(1, 150, 135);
        await plc.WriteUsIntAsync(1, 151, 136);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 USInt");
        Console.WriteLine(await plc.ReadUsIntAsync(1, 146));
        Console.WriteLine(await plc.ReadUsIntAsync(1, 147));
        Console.WriteLine(await plc.ReadUsIntAsync(1, 148));
        Console.WriteLine(await plc.ReadUsIntAsync(1, 149));
        Console.WriteLine(await plc.ReadUsIntAsync(1, 150));
        Console.WriteLine(await plc.ReadUsIntAsync(1, 151));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 USInt");
        plc.WriteUsInt(1, 146, [141, 142, 143, 144, 145, 146]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 USInt");
        Console.WriteLine(string.Join(",", plc.ReadUsInt(1, 146, 6)));
    }
}
