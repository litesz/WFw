
using System;
using WFw.Exceptions;
using WFw.Results;

namespace WFw.Identity
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 以字符串获得
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(this ICurrentUser currentUser, string key) => currentUser.Get<string>(key);

        /// <summary>
        /// 以int32获得
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetInt(this ICurrentUser currentUser, string key) => currentUser.Get<int>(key);

        /// <summary>
        /// 泛型用户id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T UserIdAs<T>(this ICurrentUser currentUser)
        {
            if (currentUser.UserId == null)
            {
                throw new BadRequestException(OperationResultType.NotExist, "签名用户");
            }
            return (T)Convert.ChangeType(currentUser.UserId, typeof(T));
        }

        /// <summary>
        /// 泛型组id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GroupIdAs<T>(this ICurrentUser currentUser)
        {
            if (currentUser.GroupId == null)
            {
                throw new BadRequestException(OperationResultType.NotExist, "签名组");
            }
            return (T)Convert.ChangeType(currentUser.GroupId, typeof(T));
        }
    }
}
