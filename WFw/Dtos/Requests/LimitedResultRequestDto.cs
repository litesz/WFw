using WFw.IDtos.Requests;

namespace WFw.Dtos.Requests
{
    /// <summary>
    /// 限制查询大小
    /// </summary>
    public class LimitedResultRequestDto : ILimitedResultRequestDto, IRequestDto
    {
        /// <summary>
        /// 
        /// </summary>
        private int pageSize = 10;

        /// <summary>
        /// 查询大小,1-1000
        /// </summary>
        public virtual int PageSize
        {
            get
            {
                if (pageSize > 1_00)
                {
                    return 1_00;
                }
                else if (pageSize < 0)
                {
                    return 1;
                }

                return pageSize;
            }
            set => pageSize = value;
        }

    }
}
