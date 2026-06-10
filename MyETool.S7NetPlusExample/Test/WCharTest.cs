using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class WCharTest
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
        plc.WriteWChar(1, 2166, '中');
        plc.WriteWChar(1, 2168, '国');

        Console.WriteLine("2. 开始同步读 ==========");
        Console.WriteLine(plc.ReadWChar(1, 2166));
        Console.WriteLine(plc.ReadWChar(1, 2168));

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteWCharAsync(1, 2166, '你');
        await plc.WriteWCharAsync(1, 2168, '好');

        Console.WriteLine("4. 开始异步读 ==========");
        Console.WriteLine(await plc.ReadWCharAsync(1, 2166));
        Console.WriteLine(await plc.ReadWCharAsync(1, 2168));
    }
}
