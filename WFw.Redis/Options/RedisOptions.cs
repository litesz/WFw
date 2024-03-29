﻿using Microsoft.Extensions.Options;

namespace WFw.Redis.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class RedisOptions : IOptions<RedisOptions>
    {
        /// <summary>
        /// 
        /// </summary>
        public RedisOptions Value => this;

        /// <summary>
        /// 
        /// </summary>
        public const string Position = "Redis";

        /// <summary>
        /// 
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConfigurationOptions ConfigurationOptions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Configuration))
            {
                return ConfigurationOptions.ToString();
            }
            return Configuration;
        }
    }
}
