using System.Text;
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


        // 内存中使用：Encoding.Unicode，编码格式一致，节省时间
        // 存储中使用：Encoding.UTF8，动态编码长度，节省空间
        Encoding encoding = Encoding.Unicode;


        Console.WriteLine("1. 开始同步写 ==========");
        plc.WriteString(1, 84, "今天开始我要自己上厕所", 254, encoding);
        plc.WriteString(1, 340, "world", 254, encoding);
        plc.WriteString(1, 596, "宝宝巴士教我上厕所秘诀", 254, encoding);
        plc.WriteString(1, 852, "abcdefg123456789", 10, encoding);
        plc.WriteString(1, 864, "白日依山尽，黄河入海流。欲穷千里目，更上一层楼。", 20, encoding);
        plc.WriteString(1, 886, "待到山花烂漫时，她在丛中笑。", 254, encoding);

        Console.WriteLine("2. 开始同步读 ==========");
        Console.WriteLine(plc.ReadString(1, 84, 256, encoding));
        Console.WriteLine(plc.ReadString(1, 340, 254, encoding));
        Console.WriteLine(plc.ReadString(1, 596, 254, encoding));
        Console.WriteLine(plc.ReadString(1, 852, 10, encoding));
        Console.WriteLine(plc.ReadString(1, 864, 20, encoding));
        Console.WriteLine(plc.ReadString(1, 886, 254, encoding));

        Console.WriteLine("3. 开始异步写 ==========");
        await plc.WriteStringAsync(1, 84, "从明天起，做一个幸福的人", 254, encoding);
        await plc.WriteStringAsync(1, 340, "喂马、劈柴，周游世界", 254, encoding);
        await plc.WriteStringAsync(1, 596, "从明天起，关心粮食和蔬菜", 254, encoding);
        await plc.WriteStringAsync(1, 852, "我有一所房子，面朝大海，春暖花开", 10, encoding);
        await plc.WriteStringAsync(1, 864, "从明天起，和每一个亲人通信", 20, encoding);
        await plc.WriteStringAsync(1, 886, "告诉他们我的幸福", 254, encoding);

        Console.WriteLine("4. 开始异步读 ==========");
        Console.WriteLine(await plc.ReadStringAsync(1, 84, 256, encoding));
        Console.WriteLine(await plc.ReadStringAsync(1, 340, 254, encoding));
        Console.WriteLine(await plc.ReadStringAsync(1, 596, 254, encoding));
        Console.WriteLine(await plc.ReadStringAsync(1, 852, 10, encoding));
        Console.WriteLine(await plc.ReadStringAsync(1, 864, 20, encoding));
        Console.WriteLine(await plc.ReadStringAsync(1, 886, 254, encoding));
    }
}
