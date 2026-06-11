using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class WordTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 Word");
        plc.WriteWord(1, 182, 211);
        plc.WriteWord(1, 184, 212);
        plc.WriteWord(1, 186, 213);
        plc.WriteWord(1, 188, 214);
        plc.WriteWord(1, 190, 215);
        plc.WriteWord(1, 192, 216);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 Word");
        Console.WriteLine(plc.ReadWord(1, 182));
        Console.WriteLine(plc.ReadWord(1, 184));
        Console.WriteLine(plc.ReadWord(1, 186));
        Console.WriteLine(plc.ReadWord(1, 188));
        Console.WriteLine(plc.ReadWord(1, 190));
        Console.WriteLine(plc.ReadWord(1, 192));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 Word");
        plc.WriteWord(1, 182, [221, 222, 223, 224, 225, 226]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 Word");
        Console.WriteLine(string.Join(", ", plc.ReadWord(1, 182, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 Word");
        await plc.WriteWordAsync(1, 182, 231);
        await plc.WriteWordAsync(1, 184, 232);
        await plc.WriteWordAsync(1, 186, 233);
        await plc.WriteWordAsync(1, 188, 234);
        await plc.WriteWordAsync(1, 190, 235);
        await plc.WriteWordAsync(1, 192, 236);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 Word");
        Console.WriteLine(await plc.ReadWordAsync(1, 182));
        Console.WriteLine(await plc.ReadWordAsync(1, 184));
        Console.WriteLine(await plc.ReadWordAsync(1, 186));
        Console.WriteLine(await plc.ReadWordAsync(1, 188));
        Console.WriteLine(await plc.ReadWordAsync(1, 190));
        Console.WriteLine(await plc.ReadWordAsync(1, 192));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 Word");
        await plc.WriteWordAsync(1, 182, [241, 242, 243, 244, 245, 246]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 Word");
        Console.WriteLine(string.Join(", ", await plc.ReadWordAsync(1, 182, 6)));
    }
}
