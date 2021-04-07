using System;

namespace WFw.Utils
{
    /// <summary>
    /// 时间戳
    /// </summary>
    public static class TimeStampExtenisons
    {

        /// <summary>
        /// 年月日时分秒转时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToFormatTimeStamp(this DateTime dateTime)
        {
            return long.Parse(dateTime.ToString("yyyyMMddHHmmssff"));
        }

        /// <summary>
        /// 年月日时分秒时间戳转本地时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime FromFormatTimeStamp(this long timeStamp)
        {
            return DateTime.Parse(timeStamp.ToString());
        }


        /// <summary>
        /// 时间戳(秒)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long ToSecondeTimeStamp(this DateTime dt)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0);
            return (long)(dt - origin).TotalSeconds;
        }

        /// <summary>
        /// 时间戳转本地时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime FromSecondeTimeStamp(this long timeStamp)
        {
            DateTime output = new DateTime(1970, 1, 1);
            output.AddSeconds(timeStamp);
            return output;
        }


        /// <summary>
        /// UTC时间戳(秒)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long ToUtcSecondeTimeStamp(this DateTimeOffset dt)
        {
            DateTimeOffset origin = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            return (long)(dt - origin).TotalSeconds;
        }

        /// <summary>
        /// UTC时间戳转UTC时间(秒)
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTimeOffset FromUtcSecondeTimeStamp(this long timeStamp)
        {
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero).AddSeconds(timeStamp);
        }

        /// <summary>
        /// UTC时间戳(毫秒)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long ToUtcMillisecondsTimeStamp(this DateTimeOffset dt)
        {
            DateTimeOffset origin = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            return (long)(dt - origin).TotalMilliseconds;
        }

        /// <summary>
        /// UTC时间戳转UTC时间(毫秒)
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTimeOffset FromUtcMillisecondsTimeStamp(this long timeStamp)
        {
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero).AddMilliseconds(timeStamp);
        }

        /// <summary>
        /// UTC时间戳(tick)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long ToUtcTicksTimeStamp(this DateTimeOffset dt)
        {
            DateTimeOffset origin = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            return (long)(dt - origin).Ticks;
        }


        /// <summary>
        /// UTC时间戳转UTC时间(ticks)
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTimeOffset FromUtcTicksTimeStamp(this long timeStamp)
        {
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero).AddTicks(timeStamp);
        }







    }
}
