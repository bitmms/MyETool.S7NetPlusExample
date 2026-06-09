using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test
{
    public static class UdIntTest
    {
        public static async Task Test()
        {
            const string plcIp = "192.168.2.200";
            Console.WriteLine(111);
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
            plc.WriteUdInt(1, 6, 1001);
            plc.WriteUdInt(1, 10, 1002);
            plc.WriteUdInt(1, 14, 1003);

            Console.WriteLine("2. 开始同步读 ==========");
            uint uint1 = await plc.ReadUdIntAsync(1, 6);
            uint uint2 = await plc.ReadUdIntAsync(1, 10);
            uint uint3 = await plc.ReadUdIntAsync(1, 14);
            Console.WriteLine(uint1);
            Console.WriteLine(uint2);
            Console.WriteLine(uint3);


            Console.WriteLine("3. 开始异步写 ==========");
            await plc.WriteDIntAsync(1, 6, 3001);
            await plc.WriteDIntAsync(1, 10, 3002);
            await plc.WriteDIntAsync(1, 14, 3003);

            Console.WriteLine("4. 开始异步读 ==========");
            uint uint4 = await plc.ReadUdIntAsync(1, 6);
            uint uint5 = await plc.ReadUdIntAsync(1, 10);
            uint uint6 = await plc.ReadUdIntAsync(1, 14);
            Console.WriteLine(uint4);
            Console.WriteLine(uint5);
            Console.WriteLine(uint6);
        }
    }
}
