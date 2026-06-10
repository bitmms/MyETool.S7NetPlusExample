using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class CharTest
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
        plc.WriteChar(1, 466, '+');
        plc.WriteChar(1, 467, '-');
        plc.WriteChar(1, 468, '*');

        Console.WriteLine("2. 开始同步读 ==========");
        char c1 = plc.ReadChar(1, 466);
        char c2 = plc.ReadChar(1, 467);
        char c3 = plc.ReadChar(1, 468);
        Console.WriteLine(c1);
        Console.WriteLine(c2);
        Console.WriteLine(c3);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteCharAsync(1, 466, 'a');
        await plc.WriteCharAsync(1, 467, 'b');
        await plc.WriteCharAsync(1, 468, 'c');

        Console.WriteLine("4. 开始异步读 ==========");
        char c4 = await plc.ReadCharAsync(1, 466);
        char c5 = await plc.ReadCharAsync(1, 467);
        char c6 = await plc.ReadCharAsync(1, 468);
        Console.WriteLine(c4);
        Console.WriteLine(c5);
        Console.WriteLine(c6);
    }
}
