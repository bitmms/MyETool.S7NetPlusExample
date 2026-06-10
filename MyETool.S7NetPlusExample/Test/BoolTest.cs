using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class BoolTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 Bool");
        plc.WriteBool(1, 0, 0, true);
        plc.WriteBool(1, 0, 1, true);
        plc.WriteBool(1, 0, 2, true);
        plc.WriteBool(1, 0, 3, false);
        plc.WriteBool(1, 0, 4, false);
        plc.WriteBool(1, 0, 5, false);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 Bool");
        Console.WriteLine(plc.ReadBool(1, 0, 0));
        Console.WriteLine(plc.ReadBool(1, 0, 1));
        Console.WriteLine(plc.ReadBool(1, 0, 2));
        Console.WriteLine(plc.ReadBool(1, 0, 3));
        Console.WriteLine(plc.ReadBool(1, 0, 4));
        Console.WriteLine(plc.ReadBool(1, 0, 5));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 Bool");
        plc.WriteBool(1, 0, 0, [false, false, false, true, true, true]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 Bool");
        Console.WriteLine(string.Join(", ", plc.ReadBool(1, 0, 0, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 Bool");
        await plc.WriteBoolAsync(1, 0, 0, true);
        await plc.WriteBoolAsync(1, 0, 1, true);
        await plc.WriteBoolAsync(1, 0, 2, true);
        await plc.WriteBoolAsync(1, 0, 3, false);
        await plc.WriteBoolAsync(1, 0, 4, false);
        await plc.WriteBoolAsync(1, 0, 5, false);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 Bool");
        Console.WriteLine(await plc.ReadBoolAsync(1, 0, 0));
        Console.WriteLine(await plc.ReadBoolAsync(1, 0, 1));
        Console.WriteLine(await plc.ReadBoolAsync(1, 0, 2));
        Console.WriteLine(await plc.ReadBoolAsync(1, 0, 3));
        Console.WriteLine(await plc.ReadBoolAsync(1, 0, 4));
        Console.WriteLine(await plc.ReadBoolAsync(1, 0, 5));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 Bool");
        await plc.WriteBoolAsync(1, 0, 0, [false, false, false, true, true, true]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 Bool");
        Console.WriteLine(string.Join(", ", await plc.ReadBoolAsync(1, 0, 0, 6)));
    }
}
