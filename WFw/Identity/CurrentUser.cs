using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace WFw.Identity
{
    /// <summary>
    /// 当前用户信息
    /// </summary>
    public class CurrentUser : ICurrentUser
    {
        private static readonly string[] _separatingStrings = { "&&" };

        /// <summary>
        /// 票据集合
        /// </summary>
        private readonly Dictionary<string, string> _claims = new Dictionary<string, string>();

        /// <summary>
        /// 已登录
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// 组id
        /// </summary>
        public string GroupId => GetByOrder(ClaimTypes.GroupSid, "groupid");

        /// <summary>
        /// 主组id
        /// </summary>
        public string PGroupId => GetByOrder(ClaimTypes.PrimaryGroupSid, "pgroupid");

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name => GetByOrder(ClaimTypes.Name, "name");

        /// <summary>
        /// 组id
        /// </summary>
        public string[] GroupIds => GetByOrder(ClaimTypes.GroupSid, "groupid")
            ?.Split(_separatingStrings, StringSplitOptions.RemoveEmptyEntries)
            ?? new string[0];

        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId => GetByOrder(ClaimTypes.NameIdentifier, "userid");

        /// <summary>
        /// 安全id
        /// </summary>
        public string SId => GetByOrder(ClaimTypes.Sid, "sid");


        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone => GetByOrder(ClaimTypes.MobilePhone, "phone");

        /// <summary>
        /// 角色
        /// </summary>
        public string[] Roles => GetByOrder(ClaimTypes.Role, "role")
            ?.Split(_separatingStrings, StringSplitOptions.RemoveEmptyEntries)
            ?? new string[0];

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddClaim(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            string lowKey = key.ToLower();
            if (_claims.ContainsKey(lowKey))
            {
                _claims[lowKey] = _claims[lowKey] + "&&" + value;
            }
            else
            {
                _claims.Add(lowKey, value);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="claim"></param>
        public void AddClaim(Claim claim)
        {
            AddClaim(claim.Type, claim.Value);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="claims"></param>
        public void AddClaims(IEnumerable<Claim> claims)
        {
            foreach (var item in claims)
            {
                AddClaim(item);
            }
        }

        /// <summary>
        /// 获得
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                var lowKey = key.ToLower();
                if (_claims.ContainsKey(lowKey))
                {
                    return _claims[lowKey];
                }
                return null;
            }
        }

        /// <summary>
        /// 是否包含指定角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool ContainRole(string role)
        {
            if (!IsAuthenticated)
            {
                return false;
            }

            return Roles.Contains(role);
        }

        /// <summary>
        /// 获得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            var lowKey = key.ToLower();
            if (_claims.ContainsKey(lowKey))
            {
                var type = typeof(T);

                if (type.IsEnum)
                {
                    return (T)Enum.Parse(type, _claims[lowKey]);
                }
                else
                {
                    return (T)Convert.ChangeType(_claims[lowKey], type);
                }
            }
            return default;
        }

        /// <summary>
        /// 获得数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T[] GetArray<T>(string key)
        {
            var lowKey = key.ToLower();
            if (_claims.ContainsKey(lowKey))
            {
                string[] infos = _claims[lowKey]?.Split(_separatingStrings, StringSplitOptions.RemoveEmptyEntries);

                if (infos == null || infos.Length == 0)
                {
                    return new T[0];
                }

                T[] output = new T[infos.Length];

                var type = typeof(T);

                for (int i = 0; i < infos.Length; i++)
                {

                    if (type.IsEnum)
                    {
                        output[i] = (T)Enum.Parse(type, infos[i]);
                    }
                    else
                    {
                        output[i] = (T)Convert.ChangeType(infos[i], type);
                    }
                }
            }
            return new T[0];
        }

        /// <summary>
        /// 顺序获得
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public string GetByOrder(params string[] keys)
        {
            if (keys == null || keys.Length == 0)
            {
                return null;
            }

            foreach (string key in keys)
            {
                var val = this[key];
                if (val != null)
                {
                    return val;
                }
            }

            return null;
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void Clear()
        {
            _claims.Clear();
        }
    }
}