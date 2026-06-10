# 使用 C# 读写西门子 PLC

> 基于 [S7NetPlus](https://github.com/S7NetPlus/s7netplus) 二次封装，已经测试的 PLC 版本：S7-1200

> 已实现功能
>
> * 根据 **DB 块字节偏移地址**进行**单点读写**【同步读写、异步读写】
>
>   - [x] Bool
>   - [x] Byte
>   - [x] SInt
>   - [x] USInt
>   - [x] Int
>   - [x] UInt
>   - [x] DInt
>   - [x] UDInt
>   - [x] Real
>   - [x] LReal
>   - [x] Char
>   - [x] WChar
>   - [x] Word
>   - [x] DWord
>   - [x] Date
>   - [x] Time
>   - [x] String：在 S7-1200 中默认仅支持 `Encoding.ASCII` 编码
>   - [x] WString：在 S7-1200 中默认仅支持 `Encoding.BigEndianUnicode` 编码
> * 根据 **DB 块字节偏移地址**进行**连续的批量读写**【同步读写、异步读写】
>
>   - [x] Bool
>   - [ ] Byte
>   - [ ] SInt
>   - [ ] USInt
>   - [ ] Int
>   - [ ] UInt
>   - [ ] DInt
>   - [ ] UDInt
>   - [x] Real
>   - [ ] LReal
>   - [ ] Char
>   - [ ] WChar
>   - [ ] Word
>   - [ ] DWord
>   - [ ] Date
>   - [ ] Time
>   - [ ] String：在 S7-1200 中默认仅支持 `Encoding.ASCII` 编码
>   - [ ] WString：在 S7-1200 中默认仅支持 `Encoding.BigEndianUnicode` 编码
> * 根据**字符串地址**进行**单点读写**【同步读写、异步读写】
>
>   - [ ] Bool
>   - [ ] Byte
>   - [ ] SInt
>   - [ ] USInt
>   - [ ] Int
>   - [ ] UInt
>   - [ ] DInt
>   - [ ] UDInt
>   - [ ] Real
>   - [ ] LReal
>   - [ ] Char
>   - [ ] WChar
>   - [ ] Word
>   - [ ] DWord
>   - [ ] Date
>   - [ ] Time
>   - [ ] String：在 S7-1200 中默认仅支持 `Encoding.ASCII` 编码
>   - [ ] WString：在 S7-1200 中默认仅支持 `Encoding.BigEndianUnicode` 编码

## S7-1200 和 C# 的对比

| S7-1200 | S7-1200 占用空间 | C#             | C# 占用空间 | 说明                                                |
| ------- | ---------------- | -------------- | ----------- | --------------------------------------------------- |
| Bool    | 1bit             | bool           | 1 Byte      | 布尔值                                              |
| Byte    | 1 Byte           | byte           | 1 Byte      | 字节，0-255                                         |
|         |                  |                |             |                                                     |
| SInt    | 1 Byte           | sbyte          | 1 Byte      | 有符号 1 字节整数：-128 到 127                      |
| USInt   | 1 Byte           | byte           | 1 Byte      | 无符号 1 字节整数：0-255                            |
|         |                  |                |             |                                                     |
| Int     | 2 Byte           | Int16、short   | 2 Byte      | 有符号 2 字节整数                                   |
| UInt    | 2 Byte           | UInt16、ushort | 2 Byte      | 无符号 2 字节整数                                   |
|         |                  |                |             |                                                     |
| DInt    | 4 Byte           | Int32、int     | 4 Byte      | 有符号 4 字节整数                                   |
| UDInt   | 4 Byte           | UInt32、uint   | 4 Byte      | 无符号 4 字节整数                                   |
|         |                  |                |             |                                                     |
| Real    | 4 Byte           | float          | 4 Byte      | 单精度 4 字节浮点数                                 |
| LReal   | 8 Byte           | double         | 8 Byte      | 双精度 8 字节浮点数                                 |
|         |                  |                |             |                                                     |
| Char    | 1 Byte，单字节   | char           | 2 Byte      | C# 使用 Unicode UTF-16 双字节小端                   |
| WChar   | 2 Byte，双字节   | char           | 2 Byte      | PLC 使用 Unicode UTF-16 双字节大端                  |
|         |                  |                |             |                                                     |
| Word    | 2 Byte           | UInt16、ushort | 2 Byte      | 和 UInt 完全一样，只是用途命名不同                  |
| DWord   | 4 Byte           | UInt32、uint   | 4 Byte      | 和 UDInt 完全一样，只是用途命名不同                 |
|         |                  |                |             |                                                     |
| Date    | 2 Byte           | UInt16、ushort | 2 Byte      | 无符号 2 字节整数，表示从 1990-01-01 经过了多少天   |
| Time    | 4 Byte           | Int32、int     | 4 Byte      | 有符号 4 字节整数，表示从 0 开始，经过了多少毫秒    |
|         |                  |                |             |                                                     |
| String  | (1+1+n) Byte     | string         | 不定        | 总长度 (1 Byte)+ 有效长度 (1 Byte)+ 字符 (n Byte)   |
| WString | (2+2+2n) Byte    | string         | 不定        | 总长度 (2 Byte)+ 有效长度 (2 Byte)+ 字符 (n*2 Byte) |

## 示例

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

