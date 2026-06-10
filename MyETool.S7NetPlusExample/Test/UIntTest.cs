using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class UIntTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 UInt");
        plc.WriteUInt(1, 74, 11);
        plc.WriteUInt(1, 76, 12);
        plc.WriteUInt(1, 78, 13);
        plc.WriteUInt(1, 80, 14);
        plc.WriteUInt(1, 82, 15);
        plc.WriteUInt(1, 84, 16);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 UInt");
        Console.WriteLine(plc.ReadUInt(1, 74));
        Console.WriteLine(plc.ReadUInt(1, 76));
        Console.WriteLine(plc.ReadUInt(1, 78));
        Console.WriteLine(plc.ReadUInt(1, 80));
        Console.WriteLine(plc.ReadUInt(1, 82));
        Console.WriteLine(plc.ReadUInt(1, 84));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 UInt");
        plc.WriteUInt(1, 74, [21, 22, 23, 24, 25, 26]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 UInt");
        Console.WriteLine(string.Join(", ", plc.ReadUInt(1, 74, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 UInt");
        await plc.WriteUIntAsync(1, 74, 31);
        await plc.WriteUIntAsync(1, 76, 32);
        await plc.WriteUIntAsync(1, 78, 33);
        await plc.WriteUIntAsync(1, 80, 34);
        await plc.WriteUIntAsync(1, 82, 35);
        await plc.WriteUIntAsync(1, 84, 36);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 UInt");
        Console.WriteLine(await plc.ReadUIntAsync(1, 74));
        Console.WriteLine(await plc.ReadUIntAsync(1, 76));
        Console.WriteLine(await plc.ReadUIntAsync(1, 78));
        Console.WriteLine(await plc.ReadUIntAsync(1, 80));
        Console.WriteLine(await plc.ReadUIntAsync(1, 82));
        Console.WriteLine(await plc.ReadUIntAsync(1, 84));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 UInt");
        await plc.WriteUIntAsync(1, 74, [41, 42, 43, 44, 45, 46]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 UInt");
        Console.WriteLine(string.Join(", ", await plc.ReadUIntAsync(1, 74, 6)));
    }
}
