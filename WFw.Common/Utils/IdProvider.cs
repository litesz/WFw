using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class IdProvider
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// 
        /// </summary>
        public static string MachineId { get; set; } = "01";

        /// <summary>
        /// 
        /// </summary>
        public static string DateTimeFormat { get; set; } = "yyyyMMddHHmmss";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string NewGuid(string format = "N")
        {
            return Guid.NewGuid().ToString(format);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string NewSnowId(int length = 4)
        {
            return MachineId + DateTime.UtcNow.ToString(DateTimeFormat) + random.NextNumberString(length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string NewNanoId(string alphabet = "_-0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", int size = 21)
        {
            return Nanoid.Nanoid.Generate(alphabet, size);
        }

    }
}
