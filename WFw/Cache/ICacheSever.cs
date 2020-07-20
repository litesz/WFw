using System;

namespace WFw.Cache
{
    public interface ICacheManager
    {
        #region key
        bool ContainsKey<V>(string key);
        bool ContainsKey(string key);
        void Del(params string[] keys);

        #endregion
        void Set<V>(string key, V value);
        void Set<V>(string key, V value, int cacheDurationInSeconds);

        V Get<V>(string key);
        string Get(string key);
        #region string


        #endregion

        #region key


        bool Compare(string key, string value);
        

        #endregion
    }


}
