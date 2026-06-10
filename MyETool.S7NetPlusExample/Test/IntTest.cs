using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class IntTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 Int");
        plc.WriteInt(1, 86, 101);
        plc.WriteInt(1, 88, 102);
        plc.WriteInt(1, 90, 103);
        plc.WriteInt(1, 92, 104);
        plc.WriteInt(1, 94, 105);
        plc.WriteInt(1, 96, 106);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 Int");
        Console.WriteLine(plc.ReadInt(1, 86));
        Console.WriteLine(plc.ReadInt(1, 88));
        Console.WriteLine(plc.ReadInt(1, 90));
        Console.WriteLine(plc.ReadInt(1, 92));
        Console.WriteLine(plc.ReadInt(1, 94));
        Console.WriteLine(plc.ReadInt(1, 96));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 Int");
        plc.WriteInt(1, 86, [201, 202, 203, 204, 205, 206]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 Int");
        Console.WriteLine(string.Join(", ", plc.ReadInt(1, 86, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 Int");
        await plc.WriteIntAsync(1, 86, 301);
        await plc.WriteIntAsync(1, 88, 302);
        await plc.WriteIntAsync(1, 90, 303);
        await plc.WriteIntAsync(1, 92, 304);
        await plc.WriteIntAsync(1, 94, 305);
        await plc.WriteIntAsync(1, 96, 306);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 Int");
        Console.WriteLine(await plc.ReadIntAsync(1, 86));
        Console.WriteLine(await plc.ReadIntAsync(1, 88));
        Console.WriteLine(await plc.ReadIntAsync(1, 90));
        Console.WriteLine(await plc.ReadIntAsync(1, 92));
        Console.WriteLine(await plc.ReadIntAsync(1, 94));
        Console.WriteLine(await plc.ReadIntAsync(1, 96));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 Int");
        await plc.WriteIntAsync(1, 86, [401, 402, 403, 404, 405, 406]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 Int");
        Console.WriteLine(string.Join(", ", await plc.ReadIntAsync(1, 86, 6)));
    }
}
