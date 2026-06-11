using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class DIntTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 DInt");
        plc.WriteDInt(1, 98, 211);
        plc.WriteDInt(1, 102, 212);
        plc.WriteDInt(1, 106, 213);
        plc.WriteDInt(1, 110, 214);
        plc.WriteDInt(1, 114, 215);
        plc.WriteDInt(1, 118, 216);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 DInt");
        Console.WriteLine(plc.ReadDInt(1, 98));
        Console.WriteLine(plc.ReadDInt(1, 102));
        Console.WriteLine(plc.ReadDInt(1, 106));
        Console.WriteLine(plc.ReadDInt(1, 110));
        Console.WriteLine(plc.ReadDInt(1, 114));
        Console.WriteLine(plc.ReadDInt(1, 118));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 DInt");
        plc.WriteDInt(1, 98, [221, 222, 223, 224, 225, 226]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 DInt");
        Console.WriteLine(string.Join(", ", plc.ReadDInt(1, 98, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 DInt");
        await plc.WriteDIntAsync(1, 98, 231);
        await plc.WriteDIntAsync(1, 102, 232);
        await plc.WriteDIntAsync(1, 106, 233);
        await plc.WriteDIntAsync(1, 110, 234);
        await plc.WriteDIntAsync(1, 114, 235);
        await plc.WriteDIntAsync(1, 118, 236);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 DInt");
        Console.WriteLine(await plc.ReadDIntAsync(1, 98));
        Console.WriteLine(await plc.ReadDIntAsync(1, 102));
        Console.WriteLine(await plc.ReadDIntAsync(1, 106));
        Console.WriteLine(await plc.ReadDIntAsync(1, 110));
        Console.WriteLine(await plc.ReadDIntAsync(1, 114));
        Console.WriteLine(await plc.ReadDIntAsync(1, 118));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 DInt");
        await plc.WriteDIntAsync(1, 98, [241, 242, 243, 244, 245, 246]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 DInt");
        Console.WriteLine(string.Join(", ", await plc.ReadDIntAsync(1, 98, 6)));
    }
}
