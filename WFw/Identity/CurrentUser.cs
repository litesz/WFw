using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WFw.Exceptions;
using WFw.Results;

namespace WFw.Identity
{
    /// <summary>
    /// 当前用户信息
    /// </summary>
    public class CurrentUser : ICurrentUser
    {
        private static readonly string[] _separatingStrings = { "&&" };

        /// <summary>
        /// 已登录
        /// </summary>
        public bool IsAuthenticated { get; set; }
        /// <summary>
        /// 组id
        /// </summary>
        public string GroupId => GetByOrder(ClaimTypes.GroupSid, "groupid");
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId => GetByOrder(ClaimTypes.NameIdentifier, "userid");

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone => GetByOrder(ClaimTypes.MobilePhone, "phone");

        /// <summary>
        /// 角色
        /// </summary>
        public string[] Roles => GetByOrder(ClaimTypes.Role, "role")?.Split(_separatingStrings, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];

        /// <summary>
        /// 票据集合
        /// </summary>
        private readonly Dictionary<string, string> _claims = new Dictionary<string, string>();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddClaim(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
            {
                throw new BadRequestException(OperationResultType.IsEmpty, "claim");
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
        /// 获得
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                if (_claims.ContainsKey(key))
                {
                    return _claims[key];
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
            if (_claims.ContainsKey(key))
            {
                var type = typeof(T);

                if (type.IsEnum)
                {
                    return (T)Enum.Parse(type, _claims[key]);
                }
                else
                {
                    return (T)Convert.ChangeType(_claims[key], type);
                }
            }
            return default;
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
    }
}