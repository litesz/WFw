using System.Collections.Generic;
using WFw.IDtos.Requests;
using WFw.IDtos.Responses;

namespace WFw.Dtos.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class PagedResponseDataWithTimeStampDto<TEntity> : PagedResponseDataDto<TEntity>, IPagedResponseDataWithTimeStampDto<TEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        public long TimeStamp { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public PagedResponseDataWithTimeStampDto() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="total"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="timeStamp"></param>
        public PagedResponseDataWithTimeStampDto(IEnumerable<TEntity> items, int total, int pageIndex, int pageSize, long timeStamp) : base(items, total, pageIndex, pageSize)
        {
            TimeStamp = timeStamp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="total"></param>
        /// <param name="timeStamp"></param>
        /// <param name="request"></param>
        public PagedResponseDataWithTimeStampDto(IEnumerable<TEntity> items, int total, long timeStamp, IPagedResultRequestDto request)
            : this(items, total, request.PageIndex, request.PageSize, timeStamp)
        {
        }

    }
}
