namespace WFw.GeTui.Models
{
    /// <summary>
    /// 通用返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> : Response
    {

        public T Data { get; set; }
    }

    /// <summary>
    /// 仅验证状态
    /// </summary>
    public class Response
    {
        public string Msg { get; set; }
        public int Code { get; set; }
    }


}
