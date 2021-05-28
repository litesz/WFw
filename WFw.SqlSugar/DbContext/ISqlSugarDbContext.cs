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
        SqlSugarClient Db
        {
            get;
        }


    }

}

