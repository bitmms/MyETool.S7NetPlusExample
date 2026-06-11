using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class WStringTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 String");
        plc.WriteWString(1, 1790, "今天开始我要自己上厕所_1", 508);
        plc.WriteWString(1, 2302, "今天开始我要自己上厕所_2", 508);
        plc.WriteWString(1, 2814, "今天开始我要自己上厕所_3", 508);
        plc.WriteWString(1, 3326, "今天开始我要自己上厕所_4", 508);
        plc.WriteWString(1, 3838, "今天开始我要自己上厕所_5", 508);
        plc.WriteWString(1, 4350, "今天开始我要自己上厕所_6", 508);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 String");
        Console.WriteLine(plc.ReadWString(1, 1790, 508));
        Console.WriteLine(plc.ReadWString(1, 2302, 508));
        Console.WriteLine(plc.ReadWString(1, 2814, 508));
        Console.WriteLine(plc.ReadWString(1, 3326, 508));
        Console.WriteLine(plc.ReadWString(1, 3838, 508));
        Console.WriteLine(plc.ReadWString(1, 4350, 508));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 String");
        plc.WriteWString(1, 1790, [
            "中国中国你好_1",
            "中国中国你好_2",
            "中国中国你好_3",
            "中国中国你好_4",
            "中国中国你好_5",
            "中国中国你好_6",
        ], 508);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 String");
        Console.WriteLine(string.Join(", ", plc.ReadWString(1, 1790, 6, 508)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 String");
        await plc.WriteWStringAsync(1, 1790, "hello_今天开始我要自己上厕所_1", 508);
        await plc.WriteWStringAsync(1, 2302, "hello_今天开始我要自己上厕所_2", 508);
        await plc.WriteWStringAsync(1, 2814, "hello_今天开始我要自己上厕所_3", 508);
        await plc.WriteWStringAsync(1, 3326, "hello_今天开始我要自己上厕所_4", 508);
        await plc.WriteWStringAsync(1, 3838, "hello_今天开始我要自己上厕所_5", 508);
        await plc.WriteWStringAsync(1, 4350, "hello_今天开始我要自己上厕所_6", 508);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 String");
        Console.WriteLine(await plc.ReadWStringAsync(1, 1790, 508));
        Console.WriteLine(await plc.ReadWStringAsync(1, 2302, 508));
        Console.WriteLine(await plc.ReadWStringAsync(1, 2814, 508));
        Console.WriteLine(await plc.ReadWStringAsync(1, 3326, 508));
        Console.WriteLine(await plc.ReadWStringAsync(1, 3838, 508));
        Console.WriteLine(await plc.ReadWStringAsync(1, 4350, 508));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 String");
        await plc.WriteWStringAsync(1, 1790, [
            "中国你好_1",
            "中国你好_2",
            "中国你好_3",
            "中国你好_4",
            "中国你好_5",
            "中国你好_6",
        ], 508);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 String");
        Console.WriteLine(string.Join(", ", await plc.ReadWStringAsync(1, 1790, 6, 508)));
    }
}
