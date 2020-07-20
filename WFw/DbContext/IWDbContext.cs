namespace WFw.DbContext
{
    public interface IWDbContext
    {
        void Init<TEntity>(params TEntity[] initData) where TEntity : class;
        IWQueryable<TEntity> Queryable<TEntity>();


        IWDeletable<TEntity> Deletable<TEntity>() where TEntity : class, new();

        IWDeletable<TEntity> Deletable<TEntity>(params dynamic[] ids) where TEntity : class, new();


        IWUpdatable<TEntity> Updatable<TEntity>() where TEntity : class, new();
        IWUpdatable<TEntity> Updatable<TEntity>(params TEntity[] objs) where TEntity : class, new();

        IWInsertable<T> Insertable<T>(params T[] insertObjs) where T : class, new();


    }
}
