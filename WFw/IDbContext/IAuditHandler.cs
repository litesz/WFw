using WFw.IEntity;

namespace WFw.IDbContext
{
    /// <summary>
    /// 默认审计信息处理程序
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimary"></typeparam>
    public interface IAuditHandler<TEntity, TPrimary> where TEntity : class, IEntity<TPrimary>, new()
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsSoftDelete { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        void InsertEntitiesAudit(params TEntity[] entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        void UpdateEntitiesAudit(params TEntity[] entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        bool DeleteEntitiesAudit(params TEntity[] entities);
    }
}
