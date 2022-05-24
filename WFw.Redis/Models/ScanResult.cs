namespace WFw.Redis
{
    /// <summary>
    /// scan结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ScanResult<T>
    {

        private readonly long _cursor;

        private readonly T[] _items;

        /// <summary>
        /// 指针
        /// </summary>
        public long Cursor => _cursor;

        /// <summary>
        /// 值
        /// </summary>
        public T[] Items => _items;


        internal ScanResult(long cursor, T[] items)
        {
            _cursor = cursor;
            _items = items;
        }

        internal ScanResult(CSRedis.RedisScan<T> redisScan)
        {
            _cursor = redisScan.Cursor;
            _items = redisScan.Items;
        }

    }

    
}
