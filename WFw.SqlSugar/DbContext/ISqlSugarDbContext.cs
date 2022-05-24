using SqlSugar;

namespace WFw.DbContext
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISqlSugarDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        ISqlSugarClient Db
        {
            get;
        }


    }

}

