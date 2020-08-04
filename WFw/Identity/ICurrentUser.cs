namespace WFw.Identity
{
    /// <summary>
    /// 当前用户信息
    /// </summary>
    public interface ICurrentUser
    {
        /// <summary>
        /// 是否已登录
        /// </summary>
        bool IsAuthenticated { get; set; }

        /// <summary>
        /// 组号
        /// </summary>
        string GroupId { get; }

        /// <summary>
        /// 用户id
        /// </summary>
        string UserId { get; }

        /// <summary>
        /// 角色
        /// </summary>
        string[] Roles { get; }

        /// <summary>
        /// 手机号
        /// </summary>
        string Phone { get; }

        /// <summary>
        /// 获得claim值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 添加claim值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        void AddClaim(string key, string value);

        /// <summary>
        /// 获得claim值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        string this[string key] { get; }

        /// <summary>
        /// 是否包含角色
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        bool ContainRole(string role);

    }
}
