using S7.Net;

namespace MyETool.S7NetPlusExample;

public static class App
{
    private static async Task Main()
    {
        Console.WriteLine("Hello, S7NetPlusExample!");

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

        // await Test.BoolTest.Test(plc);
        // await Test.ByteTest.Test(plc);

        // await Test.SIntTest.Test(plc);
        // await Test.UsIntTest.Test(plc);

        // await Test.IntTest.Test(plc);
        // await Test.UIntTest.Test(plc);

        // await Test.DIntTest.Test(plc);
        // await Test.UdIntTest.Test(plc);

        // await Test.RealTest.Test(plc);
        // await Test.LRealTest.Test(plc);

        // await Test.CharTest.Test(plc);
        // await Test.WCharTest.Test(plc);

        // await Test.WordTest.Test(plc);
        // await Test.DWordTest.Test(plc);

        // await Test.DateTest.Test(plc);
        // await Test.TimeTest.Test(plc);

        // await Test.StringTest.Test(plc);
        // await Test.WStringTest.Test(plc);
    }
}
