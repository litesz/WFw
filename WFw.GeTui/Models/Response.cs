namespace WFw.GeTui.Models
{
    public class Response<T>
    {
        public string Msg { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }
    }
}
