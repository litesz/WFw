﻿namespace WFw.Identity
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
        /// 主要组
        /// </summary>
        string PGroupId { get; }

        /// <summary>
        /// 用户名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 组号
        /// </summary>
        string GroupId { get; }

        /// <summary>
        /// 组号
        /// </summary>
        string[] GroupIds { get; }

        /// <summary>
        /// 用户id
        /// </summary>
        string UserId { get; }

        /// <summary>
        /// 角色
        /// </summary>
        string[] Roles { get; }

        /// <summary>
        /// 安全id
        /// </summary>
        string SId { get; }

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
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddClaim(string key, string value);

        /// <summary>
        /// 获得claim值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string this[string key] { get; }

        /// <summary>
        /// 是否包含角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        bool ContainRole(string role);

        /// <summary>
        /// 获得数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T[] GetArray<T>(string key);

        /// <summary>
        /// 清理所有
        /// </summary>
        void Clear();

        /// <summary>
        /// 清理指定
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// 替换
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddOrUpdate(string key, string value);
    }
}
