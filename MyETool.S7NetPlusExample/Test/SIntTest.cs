using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class SIntTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 SInt");
        plc.WriteSInt(1, 152, -111);
        plc.WriteSInt(1, 153, -112);
        plc.WriteSInt(1, 154, -113);
        plc.WriteSInt(1, 155, -114);
        plc.WriteSInt(1, 156, -115);
        plc.WriteSInt(1, 157, -116);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 SInt");
        Console.WriteLine(plc.ReadSInt(1, 152));
        Console.WriteLine(plc.ReadSInt(1, 153));
        Console.WriteLine(plc.ReadSInt(1, 154));
        Console.WriteLine(plc.ReadSInt(1, 155));
        Console.WriteLine(plc.ReadSInt(1, 156));
        Console.WriteLine(plc.ReadSInt(1, 157));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 SInt");
        plc.WriteSInt(1, 152, [-121, -122, -123, -124, -125, -126]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 SInt");
        Console.WriteLine(string.Join(", ", plc.ReadSInt(1, 152, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 SInt");
        await plc.WriteSIntAsync(1, 152, -101);
        await plc.WriteSIntAsync(1, 153, -102);
        await plc.WriteSIntAsync(1, 154, -103);
        await plc.WriteSIntAsync(1, 155, -104);
        await plc.WriteSIntAsync(1, 156, -105);
        await plc.WriteSIntAsync(1, 157, -106);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 SInt");
        Console.WriteLine(await plc.ReadSIntAsync(1, 152));
        Console.WriteLine(await plc.ReadSIntAsync(1, 153));
        Console.WriteLine(await plc.ReadSIntAsync(1, 154));
        Console.WriteLine(await plc.ReadSIntAsync(1, 155));
        Console.WriteLine(await plc.ReadSIntAsync(1, 156));
        Console.WriteLine(await plc.ReadSIntAsync(1, 157));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 SInt");
        await plc.WriteSIntAsync(1, 152, [61, 62, 63, 64, 65, 66]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 SInt");
        Console.WriteLine(string.Join(", ", await plc.ReadSIntAsync(1, 152, 6)));
    }
}
