namespace WFw.GeTui.Models
{
    /// <summary>
    /// 通用返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> : Response
    {
        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }
    }

    /// <summary>
    /// 仅验证状态
    /// </summary>
    public class Response
    {
        /// <summary>
        /// 
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
    }


}
