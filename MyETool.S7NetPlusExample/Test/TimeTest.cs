using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class TimeTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 Time");
        plc.WriteTime(1, 230, new TimeSpan(1, 2, 3, 4, 5));
        plc.WriteTime(1, 234, new TimeSpan(3, 2, 3, 4, 5));
        plc.WriteTime(1, 238, new TimeSpan(5, 2, 3, 4, 5));
        plc.WriteTime(1, 242, new TimeSpan(7, 2, 3, 4, 5));
        plc.WriteTime(1, 246, new TimeSpan(9, 2, 3, 4, 5));
        plc.WriteTime(1, 250, new TimeSpan(0, 2, 3, 4, 5));

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 Time");
        Console.WriteLine(plc.ReadTime(1, 230));
        Console.WriteLine(plc.ReadTime(1, 234));
        Console.WriteLine(plc.ReadTime(1, 238));
        Console.WriteLine(plc.ReadTime(1, 242));
        Console.WriteLine(plc.ReadTime(1, 246));
        Console.WriteLine(plc.ReadTime(1, 250));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 Time");
        plc.WriteTime(1, 230, [
            new TimeSpan(2, 1, 3, 4, 5),
            new TimeSpan(2, 3, 3, 4, 5),
            new TimeSpan(2, 5, 3, 4, 5),
            new TimeSpan(2, 7, 3, 4, 5),
            new TimeSpan(2, 9, 3, 4, 5),
            new TimeSpan(2, 0, 3, 4, 5),
        ]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 Time");
        Console.WriteLine(string.Join(", ", plc.ReadTime(1, 230, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 Time");
        await plc.WriteTimeAsync(1, 230, new TimeSpan(3, 2, 3, 4, 5));
        await plc.WriteTimeAsync(1, 234, new TimeSpan(3, 2, 3, 4, 5));
        await plc.WriteTimeAsync(1, 238, new TimeSpan(3, 2, 3, 4, 5));
        await plc.WriteTimeAsync(1, 242, new TimeSpan(3, 2, 3, 4, 5));
        await plc.WriteTimeAsync(1, 246, new TimeSpan(3, 2, 3, 4, 5));
        await plc.WriteTimeAsync(1, 250, new TimeSpan(3, 2, 3, 4, 5));

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 Time");
        Console.WriteLine(await plc.ReadTimeAsync(1, 230));
        Console.WriteLine(await plc.ReadTimeAsync(1, 234));
        Console.WriteLine(await plc.ReadTimeAsync(1, 238));
        Console.WriteLine(await plc.ReadTimeAsync(1, 242));
        Console.WriteLine(await plc.ReadTimeAsync(1, 246));
        Console.WriteLine(await plc.ReadTimeAsync(1, 250));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 Time");
        await plc.WriteTimeAsync(1, 230, [
            new TimeSpan(10, 1, 3, 4, 5),
            new TimeSpan(10, 3, 3, 4, 5),
            new TimeSpan(10, 5, 3, 4, 5),
            new TimeSpan(10, 7, 3, 4, 5),
            new TimeSpan(10, 9, 3, 4, 5),
            new TimeSpan(10, 0, 3, 4, 5),
        ]);


        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 Time");
        Console.WriteLine(string.Join(", ", await plc.ReadTimeAsync(1, 230, 6)));
    }
}
