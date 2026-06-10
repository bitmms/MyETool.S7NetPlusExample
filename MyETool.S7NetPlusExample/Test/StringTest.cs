using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class StringTest
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
        plc.WriteString(1, 84, "Nothing is impossible...", 254);
        plc.WriteString(1, 596, "abcdefg1234567", 254);
        plc.WriteString(1, 852, "qwertyuiop", 10);

        Console.WriteLine("2. 开始同步读 ==========");
        Console.WriteLine(plc.ReadString(1, 84, 256));
        Console.WriteLine(plc.ReadString(1, 596, 254));
        Console.WriteLine(plc.ReadString(1, 852, 10));

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteStringAsync(1, 84, "Goodbye", 254);
        await plc.WriteStringAsync(1, 596, "You're welcome", 254);
        await plc.WriteStringAsync(1, 852, "Every day is new", 10);

        Console.WriteLine("4. 开始异步读 ==========");
        Console.WriteLine(await plc.ReadStringAsync(1, 84, 256));
        Console.WriteLine(await plc.ReadStringAsync(1, 596, 254));
        Console.WriteLine(await plc.ReadStringAsync(1, 852, 10));
    }
}
