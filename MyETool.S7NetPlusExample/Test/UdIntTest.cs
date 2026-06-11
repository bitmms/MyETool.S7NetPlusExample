using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class UdIntTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 UDInt");
        plc.WriteUdInt(1, 122, 311);
        plc.WriteUdInt(1, 126, 312);
        plc.WriteUdInt(1, 130, 313);
        plc.WriteUdInt(1, 134, 314);
        plc.WriteUdInt(1, 138, 315);
        plc.WriteUdInt(1, 142, 316);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 UDInt");
        Console.WriteLine(plc.ReadUdInt(1, 122));
        Console.WriteLine(plc.ReadUdInt(1, 126));
        Console.WriteLine(plc.ReadUdInt(1, 130));
        Console.WriteLine(plc.ReadUdInt(1, 134));
        Console.WriteLine(plc.ReadUdInt(1, 138));
        Console.WriteLine(plc.ReadUdInt(1, 142));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 UDInt");
        plc.WriteUdInt(1, 122, [321, 322, 323, 324, 325, 326]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 UDInt");
        Console.WriteLine(string.Join(", ", plc.ReadUdInt(1, 122, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 UDInt");
        await plc.WriteUdIntAsync(1, 122, 331);
        await plc.WriteUdIntAsync(1, 126, 332);
        await plc.WriteUdIntAsync(1, 130, 333);
        await plc.WriteUdIntAsync(1, 134, 334);
        await plc.WriteUdIntAsync(1, 138, 335);
        await plc.WriteUdIntAsync(1, 142, 336);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 UDInt");
        Console.WriteLine(await plc.ReadUdIntAsync(1, 122));
        Console.WriteLine(await plc.ReadUdIntAsync(1, 126));
        Console.WriteLine(await plc.ReadUdIntAsync(1, 130));
        Console.WriteLine(await plc.ReadUdIntAsync(1, 134));
        Console.WriteLine(await plc.ReadUdIntAsync(1, 138));
        Console.WriteLine(await plc.ReadUdIntAsync(1, 142));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 UDInt");
        await plc.WriteUdIntAsync(1, 122, [341, 342, 343, 344, 345, 346]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 UDInt");
        Console.WriteLine(string.Join(", ", await plc.ReadUdIntAsync(1, 122, 6)));
    }
}
