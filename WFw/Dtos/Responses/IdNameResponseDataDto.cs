namespace WFw.Dtos.Responses
{
    /// <summary>
    /// 返回主键和名称
    /// </summary>
    public class IdNameResponseDataDto<TId> : IdResponseDataDto<TId>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public IdNameResponseDataDto(TId id, string name) : base(id)
        {
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        public IdNameResponseDataDto() { }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }



}
