using S7.Net;

namespace MyETool.S7NetPlusExample.Util
{
    /// <summary>
    /// 已经测试的 PLC 版本：S7-1200
    /// </summary>
    /// <example>
    /// https://github.com/S7NetPlus/s7netplus
    /// </example>
    public static partial class S7Util
    {
        /// <summary>
        /// 通用泛型同步读取，支持地址：DB1.DBX0.0 / DB1.DBB10 / DB1.DBD20
        /// </summary>
        public static T Read<T>(this Plc plc, string address)
        {
            object? read = plc.Read(address);
            if (read == null)
            {
                throw new Exception("Read returned null");
            }

            return (T)read;
        }

        /// <summary>
        /// 通用泛型同步写入
        /// </summary>
        public static void Write<T>(this Plc plc, string address, T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            plc.Write(address, value);
        }

        /// <summary>
        /// 通用泛型异步读取
        /// </summary>
        public static async Task<T> ReadAsync<T>(this Plc plc, string address, CancellationToken cancellationToken = default)
        {
            object? readAsync = await plc.ReadAsync(address, cancellationToken);
            if (readAsync == null)
            {
                throw new Exception("Read returned null");
            }

            return (T)readAsync;
        }

        /// <summary>
        /// 通用泛型异步写入
        /// </summary>
        public static async Task WriteAsync<T>(this Plc plc, string address, T value, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            await plc.WriteAsync(address, value, cancellationToken);
        }
    }
}
