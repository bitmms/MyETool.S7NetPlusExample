using MyETool.S7NetPlusExample.Util;
using S7.Net;

namespace MyETool.S7NetPlusExample.Test;

public static class ByteTest
{
    public static async Task Test(Plc plc)
    {
        Console.WriteLine("1. 开始单点同步写 Byte");
        plc.WriteByte(1, 158, 101);
        plc.WriteByte(1, 159, 102);
        plc.WriteByte(1, 160, 103);
        plc.WriteByte(1, 161, 104);
        plc.WriteByte(1, 162, 105);
        plc.WriteByte(1, 163, 106);

        await Task.Delay(1000);

        Console.WriteLine("2. 开始单点同步读 Byte");
        Console.WriteLine(plc.ReadByte(1, 158));
        Console.WriteLine(plc.ReadByte(1, 159));
        Console.WriteLine(plc.ReadByte(1, 160));
        Console.WriteLine(plc.ReadByte(1, 161));
        Console.WriteLine(plc.ReadByte(1, 162));
        Console.WriteLine(plc.ReadByte(1, 163));

        await Task.Delay(1000);

        Console.WriteLine("3. 开始连续同步写 Byte");
        plc.WriteByte(1, 158, [111, 112, 113, 114, 115, 116]);

        await Task.Delay(1000);

        Console.WriteLine("4. 开始连续同步读 Byte");
        Console.WriteLine(string.Join(", ", plc.ReadByte(1, 158, 6)));

        await Task.Delay(1000);

        Console.WriteLine("5. 开始单点异步写 Byte");
        await plc.WriteByteAsync(1, 158, 121);
        await plc.WriteByteAsync(1, 159, 122);
        await plc.WriteByteAsync(1, 160, 123);
        await plc.WriteByteAsync(1, 161, 124);
        await plc.WriteByteAsync(1, 162, 125);
        await plc.WriteByteAsync(1, 163, 126);

        await Task.Delay(1000);

        Console.WriteLine("6. 开始单点异步读 Byte");
        Console.WriteLine(await plc.ReadByteAsync(1, 158));
        Console.WriteLine(await plc.ReadByteAsync(1, 159));
        Console.WriteLine(await plc.ReadByteAsync(1, 160));
        Console.WriteLine(await plc.ReadByteAsync(1, 161));
        Console.WriteLine(await plc.ReadByteAsync(1, 162));
        Console.WriteLine(await plc.ReadByteAsync(1, 163));

        await Task.Delay(1000);

        Console.WriteLine("7. 开始连续异步写 Byte");
        await plc.WriteByteAsync(1, 158, [11, 12, 13, 14, 15, 16]);

        await Task.Delay(1000);

        Console.WriteLine("8. 开始连续异步读 Byte");
        Console.WriteLine(string.Join(", ", await plc.ReadByteAsync(1, 158, 6)));
    }
}
