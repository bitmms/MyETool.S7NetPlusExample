using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class DateTest
{
    public static async Task Test()
    {
        const string plcIp = "192.168.2.200";
        var plc = new Plc(
            cpu: CpuType.S71200,
            ip: plcIp,
            port: 102,
            rack: 0,
            slot: 1
        );
        await plc.OpenAsync();
        if (!plc.IsConnected) throw new InvalidOperationException($"PLC 连接失败：{plcIp}");
        Console.WriteLine($"PLC 连接成功：{plcIp}");


        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteDate(1, 2176, new DateOnly(1990, 1, 5));
        plc.WriteDate(1, 2178, new DateOnly(1990, 2, 5));
        plc.WriteDate(1, 2180, new DateOnly(1990, 3, 5));

        Console.WriteLine("2. 开始同步读 ==========");
        Console.WriteLine(plc.ReadDate(1, 2176));
        Console.WriteLine(plc.ReadDate(1, 2178));
        Console.WriteLine(plc.ReadDate(1, 2180));

        await Task.Delay(3000);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteDateAsync(1, 2176, new DateOnly(1991, 1, 5));
        await plc.WriteDateAsync(1, 2178, new DateOnly(1991, 2, 5));
        await plc.WriteDateAsync(1, 2180, new DateOnly(1991, 3, 5));

        Console.WriteLine("4. 开始异步读 ==========");
        Console.WriteLine(await plc.ReadDateAsync(1, 2176));
        Console.WriteLine(await plc.ReadDateAsync(1, 2178));
        Console.WriteLine(await plc.ReadDateAsync(1, 2180));
    }
}
