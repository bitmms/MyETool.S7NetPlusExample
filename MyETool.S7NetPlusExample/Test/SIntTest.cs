using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class SIntTest
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
        plc.WriteSInt(1, 2173, -31);
        plc.WriteSInt(1, 2174, 32);
        plc.WriteSInt(1, 2175, -33);

        Console.WriteLine("2. 开始同步读 ==========");
        sbyte sint1 = plc.ReadSInt(1, 2173);
        sbyte sint2 = plc.ReadSInt(1, 2174);
        sbyte sint3 = plc.ReadSInt(1, 2175);
        Console.WriteLine(sint1);
        Console.WriteLine(sint2);
        Console.WriteLine(sint3);

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteSIntAsync(1, 2173, 61);
        await plc.WriteSIntAsync(1, 2174, -62);
        await plc.WriteSIntAsync(1, 2175, 63);

        Console.WriteLine("4. 开始异步读 ==========");
        sbyte sint4 = await plc.ReadSIntAsync(1, 2173);
        sbyte sint5 = await plc.ReadSIntAsync(1, 2174);
        sbyte sint6 = await plc.ReadSIntAsync(1, 2175);
        Console.WriteLine(sint4);
        Console.WriteLine(sint5);
        Console.WriteLine(sint6);
    }
}
