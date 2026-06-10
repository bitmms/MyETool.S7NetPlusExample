# 使用 C# 读写西门子 PLC

> 基于 [S7NetPlus](https://github.com/S7NetPlus/s7netplus) 二次封装，已经测试的 PLC 版本：S7-1200

> 已实现功能
>
> * 根据 **DB 块字节偏移地址**进行单点读写【同步读写、异步读写】
>
>   - [x] Bool
>
>   - [x] Byte
>   - [x] Char
>
>   - [x] Int
>   - [x] DInt
>
>   - [x] UInt
>   - [x] UDInt
>
>   - [x] Word
>   - [x] DWord
>   - [x] Real
>   - [x] LReal
>   - [x] Time
>   - [x] String：仅支持 `Encoding.ASCII` 编码
>   - [x] WString：仅支持 `Encoding.BigEndianUnicode` 编码
>   - [x] USInt
>   - [x] SInt
>
> * 根据**字符串地址**进行单点读写【同步读写、异步读写】
>
>   - [ ] Bool
>   - [ ] Byte
>   - [ ] Char
>
>   - [ ] Int
>   - [ ] DInt
>
>   - [ ] UInt
>   - [ ] UDInt
>
>   - [ ] Word
>   - [ ] DWord
>   - [ ] Real
>   - [ ] LReal
>   - [ ] Time
>   - [ ] String：仅支持 `Encoding.ASCII` 编码
>   - [ ] WString：仅支持 `Encoding.BigEndianUnicode` 编码
>   - [ ] USInt
>   - [ ] SInt



> 示例

```shell
dotnet add package S7netplus
```

```c#
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

// 单点读写 S7-1200 的 Real 类型
await plc.WriteRealAsync(1, 36, 3.14f);
float ff = await plc.ReadRealAsync(1, 36);
Console.WriteLine(ff);

// 单点读写 S7-1200 的 Time 类型
await plc.WriteTimeAsync(1, 72, new TimeSpan(2, 2, 3, 4, 5));
TimeSpan timeSpan = await plc.ReadTimeAsync(1, 72);
Console.WriteLine(timeSpan);
```

