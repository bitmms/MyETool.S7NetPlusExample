using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class DateTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 Date");
        plc.WriteDate(1, 218, new DateOnly(2026, 1, 11));
        plc.WriteDate(1, 220, new DateOnly(2026, 2, 12));
        plc.WriteDate(1, 222, new DateOnly(2026, 3, 13));
        plc.WriteDate(1, 224, new DateOnly(2026, 4, 14));
        plc.WriteDate(1, 226, new DateOnly(2026, 5, 15));
        plc.WriteDate(1, 228, new DateOnly(2026, 6, 16));

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 Date");
        Console.WriteLine(plc.ReadDate(1, 218));
        Console.WriteLine(plc.ReadDate(1, 220));
        Console.WriteLine(plc.ReadDate(1, 222));
        Console.WriteLine(plc.ReadDate(1, 224));
        Console.WriteLine(plc.ReadDate(1, 226));
        Console.WriteLine(plc.ReadDate(1, 228));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 Date");
        plc.WriteDate(1, 218, [
            new DateOnly(2026, 3, 21),
            new DateOnly(2026, 3, 22),
            new DateOnly(2026, 3, 23),
            new DateOnly(2026, 3, 24),
            new DateOnly(2026, 3, 25),
            new DateOnly(2026, 3, 26),
        ]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 Date");
        Console.WriteLine(string.Join(", ", plc.ReadDate(1, 218, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 Date");
        await plc.WriteDateAsync(1, 218, new DateOnly(2028, 1, 11));
        await plc.WriteDateAsync(1, 220, new DateOnly(2028, 2, 12));
        await plc.WriteDateAsync(1, 222, new DateOnly(2028, 3, 13));
        await plc.WriteDateAsync(1, 224, new DateOnly(2028, 4, 14));
        await plc.WriteDateAsync(1, 226, new DateOnly(2028, 5, 15));
        await plc.WriteDateAsync(1, 228, new DateOnly(2028, 6, 16));

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 Date");
        Console.WriteLine(await plc.ReadDateAsync(1, 218));
        Console.WriteLine(await plc.ReadDateAsync(1, 220));
        Console.WriteLine(await plc.ReadDateAsync(1, 222));
        Console.WriteLine(await plc.ReadDateAsync(1, 224));
        Console.WriteLine(await plc.ReadDateAsync(1, 226));
        Console.WriteLine(await plc.ReadDateAsync(1, 228));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 Date");
        await plc.WriteDateAsync(1, 218, [
            new DateOnly(2026, 9, 21),
            new DateOnly(2026, 9, 22),
            new DateOnly(2026, 9, 23),
            new DateOnly(2026, 9, 24),
            new DateOnly(2026, 9, 25),
            new DateOnly(2026, 9, 26),
        ]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 Date");
        Console.WriteLine(string.Join(", ", await plc.ReadDateAsync(1, 218, 6)));
    }
}
