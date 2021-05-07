using WFw.IDtos.Responses;

namespace WFw.Dtos.Responses
{
    /// <summary>
    /// 返回主键
    /// </summary>
    public class IdResponseDataDto<T> : IResponseDataDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public IdResponseDataDto(T id)
        {
            Id = id;
        }
        /// <summary>
        /// 
        /// </summary>
        public IdResponseDataDto() { }
    }
}
