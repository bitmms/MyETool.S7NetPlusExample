using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class TimeTest
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
        plc.WriteTime(1, 72, new TimeSpan(1, 2, 3, 4, 5));
        plc.WriteTime(1, 76, new TimeSpan(1, 2, 3, 4, 5));
        plc.WriteTime(1, 80, new TimeSpan(1, 2, 3, 4, 5));

        Console.WriteLine("2. 开始同步读 ==========");
        TimeSpan t1 = plc.ReadTime(1, 72);
        TimeSpan t2 = plc.ReadTime(1, 76);
        TimeSpan t3 = plc.ReadTime(1, 80);
        Console.WriteLine(t1);
        Console.WriteLine(t2);
        Console.WriteLine(t3);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteTimeAsync(1, 72, new TimeSpan(2, 2, 3, 4, 5));
        await plc.WriteTimeAsync(1, 76, new TimeSpan(2, 2, 3, 4, 5));
        await plc.WriteTimeAsync(1, 80, new TimeSpan(2, 2, 3, 4, 5));

        Console.WriteLine("4. 开始异步读 ==========");
        TimeSpan t4 = await plc.ReadTimeAsync(1, 72);
        TimeSpan t5 = await plc.ReadTimeAsync(1, 76);
        TimeSpan t6 = await plc.ReadTimeAsync(1, 80);
        Console.WriteLine(t4);
        Console.WriteLine(t5);
        Console.WriteLine(t6);
    }
}
