﻿using System;

namespace WFw.GeTui
{
    public static class Time
    {
        /// <summary>
        /// 时间转换 毫秒级别的时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToMillisecondTimeStamp(this DateTime dateTime)
        {
            //北京时间相差8小时
            DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 8, 0, 0, 0), TimeZoneInfo.Local);
            long t = (dateTime.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位   
            return t.ToString();
        }

        public static DateTime ToDateTime(this long timeStamp)
        {
            DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 8, 0, 0, 0), TimeZoneInfo.Local);
            return startTime.AddMilliseconds(timeStamp);
        }
    }
}
