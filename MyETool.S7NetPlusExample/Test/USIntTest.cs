using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class UsIntTest
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
        plc.WriteUsInt(1, 2170, 31);
        plc.WriteUsInt(1, 2171, 32);
        plc.WriteUsInt(1, 2172, 33);

        Console.WriteLine("2. 开始同步读 ==========");
        byte usint1 = plc.ReadUsInt(1, 2170);
        byte usint2 = plc.ReadUsInt(1, 2171);
        byte usint3 = plc.ReadUsInt(1, 2172);
        Console.WriteLine(usint1);
        Console.WriteLine(usint2);
        Console.WriteLine(usint3);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteUsIntAsync(1, 2170, 61);
        await plc.WriteUsIntAsync(1, 2171, 62);
        await plc.WriteUsIntAsync(1, 2172, 63);

        Console.WriteLine("4. 开始异步读 ==========");
        byte usint4 = await plc.ReadUsIntAsync(1, 2170);
        byte usint5 = await plc.ReadUsIntAsync(1, 2171);
        byte usint6 = await plc.ReadUsIntAsync(1, 2172);
        Console.WriteLine(usint4);
        Console.WriteLine(usint5);
        Console.WriteLine(usint6);
    }
}
