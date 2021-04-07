using System;

namespace WFw.Cache
{
    /// <summary>
    /// 
    /// </summary>
    public class CacheItemOptions
    {

        private DateTimeOffset? _absoluteExpiration;

        private TimeSpan? _absoluteExpirationRelativeToNow;

        private TimeSpan? _slidingExpiration;

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset? AbsoluteExpiration
        {
            get
            {
                return _absoluteExpiration;
            }
            set
            {
                _absoluteExpiration = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? AbsoluteExpirationRelativeToNow
        {
            get
            {
                return _absoluteExpirationRelativeToNow;
            }
            set
            {
                if (value <= TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("AbsoluteExpirationRelativeToNow", value, "The relative expiration value must be positive.");
                }

                _absoluteExpirationRelativeToNow = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? SlidingExpiration
        {
            get
            {
                return _slidingExpiration;
            }
            set
            {
                if (value <= TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("SlidingExpiration", value, "The sliding expiration value must be positive.");
                }

                _slidingExpiration = value;
            }
        }

        /// <summary>
        /// 返回过期秒
        /// </summary>
        /// <returns></returns>
        public int GetAbsluteExpirationSecs()
        {
            int s = GetSlidingExpirationSecs();
            if (s > -1)
            {
                return s;
            }

            if (_absoluteExpirationRelativeToNow.HasValue)
            {
                return (int)_absoluteExpirationRelativeToNow.Value.TotalSeconds;

            }

            if (_absoluteExpiration.HasValue)
            {
                return (int)(_absoluteExpiration.Value - DateTimeOffset.UtcNow).TotalSeconds;

            }

            return 25200;

        }

        /// <summary>
        /// 返回滑动过期秒
        /// </summary>
        /// <returns></returns>
        public int GetSlidingExpirationSecs()
        {
            if (SlidingExpiration.HasValue == false)
            {
                return -1;
            }

            return (int)SlidingExpiration.Value.TotalSeconds;
        }
    }
}
