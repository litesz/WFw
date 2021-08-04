using WFw.Identity;

namespace WFw.IDbContext
{
    /// <summary>
    /// 默认审计信息处理程序
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimary"></typeparam>
    public interface IAuditHandler<TEntity, TPrimary>
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsSoftDelete { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="entities"></param>
        void InsertEntitiesAudit(ICurrentUser user, params TEntity[] entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="entities"></param>
        void UpdateEntitiesAudit(ICurrentUser user, params TEntity[] entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        bool DeleteEntitiesAudit(ICurrentUser user, params TEntity[] entities);
    }
}
