using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class BoolTest
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
        plc.WriteBool(1, 0, 0, true);
        plc.WriteBool(1, 0, 1, true);
        plc.WriteBool(1, 0, 2, true);

        Console.WriteLine("2. 开始同步读 ==========");
        bool b1 = plc.ReadBool(1, 0, 0);
        bool b2 = plc.ReadBool(1, 0, 1);
        bool b3 = plc.ReadBool(1, 0, 2);
        Console.WriteLine(b1);
        Console.WriteLine(b2);
        Console.WriteLine(b3);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteBoolAsync(1, 0, 0, false);
        await plc.WriteBoolAsync(1, 0, 1, false);
        await plc.WriteBoolAsync(1, 0, 2, false);

        Console.WriteLine("4. 开始异步读 ==========");
        bool b4 = await plc.ReadBoolAsync(1, 0, 0);
        bool b5 = await plc.ReadBoolAsync(1, 0, 1);
        bool b6 = await plc.ReadBoolAsync(1, 0, 2);
        Console.WriteLine(b4);
        Console.WriteLine(b5);
        Console.WriteLine(b6);
    }
}
