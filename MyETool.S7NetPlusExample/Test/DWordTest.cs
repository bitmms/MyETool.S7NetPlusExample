using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class DWordTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 DWord");
        plc.WriteDWord(1, 194, 211);
        plc.WriteDWord(1, 198, 212);
        plc.WriteDWord(1, 202, 213);
        plc.WriteDWord(1, 206, 214);
        plc.WriteDWord(1, 210, 215);
        plc.WriteDWord(1, 214, 216);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 DWord");
        Console.WriteLine(plc.ReadDWord(1, 194));
        Console.WriteLine(plc.ReadDWord(1, 198));
        Console.WriteLine(plc.ReadDWord(1, 202));
        Console.WriteLine(plc.ReadDWord(1, 206));
        Console.WriteLine(plc.ReadDWord(1, 210));
        Console.WriteLine(plc.ReadDWord(1, 214));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 DWord");
        plc.WriteDWord(1, 194, [221, 222, 223, 224, 225, 226]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 DWord");
        Console.WriteLine(string.Join(", ", plc.ReadDWord(1, 194, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 DWord");
        await plc.WriteDWordAsync(1, 194, 231);
        await plc.WriteDWordAsync(1, 198, 232);
        await plc.WriteDWordAsync(1, 202, 233);
        await plc.WriteDWordAsync(1, 206, 234);
        await plc.WriteDWordAsync(1, 210, 235);
        await plc.WriteDWordAsync(1, 214, 236);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 DWord");
        Console.WriteLine(await plc.ReadDWordAsync(1, 194));
        Console.WriteLine(await plc.ReadDWordAsync(1, 198));
        Console.WriteLine(await plc.ReadDWordAsync(1, 202));
        Console.WriteLine(await plc.ReadDWordAsync(1, 206));
        Console.WriteLine(await plc.ReadDWordAsync(1, 210));
        Console.WriteLine(await plc.ReadDWordAsync(1, 214));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 DWord");
        await plc.WriteDWordAsync(1, 194, [241, 242, 243, 244, 245, 246]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 DWord");
        Console.WriteLine(string.Join(", ", await plc.ReadDWordAsync(1, 194, 6)));
    }
}
