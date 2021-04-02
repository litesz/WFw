namespace WFw.Cache
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICache
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetValue<T>(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        (T output, bool IsOk) Get<T>(string key);

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="keys"></param>
        long Remove(params string[] keys);


        /// <summary>
        /// 写入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        bool Set<T>(string key, T value, CacheItemOptions options);



    }


}
