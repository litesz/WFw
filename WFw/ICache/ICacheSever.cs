namespace WFw.ICache
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICacheManager
    {
        #region key
        /// <summary>
        /// 检查是否存在指定索引的缓存
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        bool ContainsKey<V>(string key);

        /// <summary>
        /// 检查是否存在指定索引的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool ContainsKey(string key);

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="keys"></param>
        void Del(params string[] keys);

        /// <summary>
        /// 比较是否相等
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Compare(string key, string value);


        #endregion

        #region string

        /// <summary>
        /// 存缓存
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Set<V>(string key, V value);

        /// <summary>
        /// 存缓存
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheDurationInSeconds"></param>
        void Set<V>(string key, V value, int cacheDurationInSeconds);

        /// <summary>
        /// 取缓存
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        V Get<V>(string key);

        /// <summary>
        /// 取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string Get(string key);

        #endregion

    }


}
