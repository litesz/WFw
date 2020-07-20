using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using WFw.Exceptions;

namespace WFw.Identity
{
    public class CurrentUser : ICurrentUser
    {
        public bool IsAuthenticated { get; set; }
        public string GroupId => GetByOrder(ClaimTypes.GroupSid, "groupid");
        public string UserId => GetByOrder(ClaimTypes.NameIdentifier, "userid");
        public string Phone => GetByOrder(ClaimTypes.MobilePhone, "phone");
        public string[] Roles => GetByOrder(ClaimTypes.Role, "role")?.Split("&&") ?? new string[0];

        private readonly Dictionary<string, string> _claims = new Dictionary<string, string>();

        public void AddClaim(string key, string value)
        {

            if (_claims.ContainsKey(key))
            {
                _claims[key] = _claims[key] + "&&" + value;
            }
            else
            {
                _claims.Add(key, value);

            }
        }

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

        public T UserIdAs<T>()
        {
            if (UserId == null)
            {
                throw new BadRequestException(Data.OperationResultType.NotExist, "签名用户");
            }
            return (T)Convert.ChangeType(UserId, typeof(T));
        }

        public T GroupIdAs<T>()
        {
            if (GroupId == null)
            {
                throw new BadRequestException(Data.OperationResultType.NotExist, "签名组");
            }
            return (T)Convert.ChangeType(GroupId, typeof(T));
        }

        public bool ContainRole(string role)
        {
            if (!IsAuthenticated)
            {
                return false;
            }

            return Roles.Contains(role);
        }

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

        public string Get(string key)
        {
            if (_claims.ContainsKey(key))
            {
                return _claims[key];
            }
            return default;
        }

        public int GetInt(string key) => Get<int>(key);


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