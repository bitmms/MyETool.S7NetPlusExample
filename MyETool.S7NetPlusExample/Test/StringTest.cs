using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class StringTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 String");
        plc.WriteString(1, 254, "123456_hello_1", 254);
        plc.WriteString(1, 510, "123456_hello_2", 254);
        plc.WriteString(1, 766, "123456_hello_3", 254);
        plc.WriteString(1, 1022, "123456_hello_4", 254);
        plc.WriteString(1, 1278, "123456_hello_5", 254);
        plc.WriteString(1, 1534, "123456_hello_6", 254);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 String");
        Console.WriteLine(plc.ReadString(1, 254, 254));
        Console.WriteLine(plc.ReadString(1, 510, 254));
        Console.WriteLine(plc.ReadString(1, 766, 254));
        Console.WriteLine(plc.ReadString(1, 1022, 254));
        Console.WriteLine(plc.ReadString(1, 1278, 254));
        Console.WriteLine(plc.ReadString(1, 1534, 254));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 String");
        plc.WriteString(1, 254, [
            "hello_1",
            "hello_2",
            "hello_3",
            "hello_4",
            "hello_5",
            "hello_6",
        ], 254);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 String");
        Console.WriteLine(string.Join(", ", plc.ReadString(1, 254, 6, 254)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 String");
        await plc.WriteStringAsync(1, 254, "abc111", 254);
        await plc.WriteStringAsync(1, 510, "abc222", 254);
        await plc.WriteStringAsync(1, 766, "abc333", 254);
        await plc.WriteStringAsync(1, 1022, "abc444", 254);
        await plc.WriteStringAsync(1, 1278, "abc555", 254);
        await plc.WriteStringAsync(1, 1534, "abc666", 254);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 String");
        Console.WriteLine(await plc.ReadStringAsync(1, 254, 254));
        Console.WriteLine(await plc.ReadStringAsync(1, 510, 254));
        Console.WriteLine(await plc.ReadStringAsync(1, 766, 254));
        Console.WriteLine(await plc.ReadStringAsync(1, 1022, 254));
        Console.WriteLine(await plc.ReadStringAsync(1, 1278, 254));
        Console.WriteLine(await plc.ReadStringAsync(1, 1534, 254));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 String");
        await plc.WriteStringAsync(1, 254, [
            "123456_hello_1",
            "123456_hello_2",
            "123456_hello_3",
            "123456_hello_4",
            "123456_hello_5",
            "123456_hello_6",
        ], 254);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 String");
        Console.WriteLine(string.Join(", ", await plc.ReadStringAsync(1, 254, 6, 254)));
    }
}
