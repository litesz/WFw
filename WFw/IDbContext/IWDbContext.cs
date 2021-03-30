namespace WFw.IDbContext
{
    /// <summary>
    /// 抽象上下文
    /// </summary>
    public interface IWDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        IAdo Ado { get; }

        /// <summary>
        /// 初始化表格
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="initData"></param>
        void Init<TEntity>(params TEntity[] initData) where TEntity : class;

        /// <summary>
        /// 如果不存在创建数据库
        /// </summary>
        void InitDatabase();

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IWQueryable<TEntity> Queryable<TEntity>();

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IWDeletable<TEntity> Deletable<TEntity>() where TEntity : class, new();

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        IWDeletable<TEntity> Deletable<TEntity>(params dynamic[] ids) where TEntity : class, new();

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IWUpdatable<TEntity> Updatable<TEntity>() where TEntity : class, new();

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="objs"></param>
        /// <returns></returns>
        IWUpdatable<TEntity> Updatable<TEntity>(params TEntity[] objs) where TEntity : class, new();

        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="insertObjs"></param>
        /// <returns></returns>
        IWInsertable<T> Insertable<T>(params T[] insertObjs) where T : class, new();


    }
}
