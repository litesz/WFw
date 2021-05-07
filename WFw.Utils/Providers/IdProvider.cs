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
        public static string NewGuidId(string format = "N")
        {
            return Guid.NewGuid().ToString(format);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SnowId(int length = 4)
        {
            return MachineId + DateTime.UtcNow.ToString(DateTimeFormat) + random.NextNumberString(length);
        }

    }
}
