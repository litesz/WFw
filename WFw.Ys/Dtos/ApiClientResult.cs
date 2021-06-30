namespace WFw.Ys.Dtos
{
    public class ApiClientResult
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public bool IsSuccess => Code == 200;

    }


    public class ApiClientResult<T> : ApiClientResult
    {

        public T Data { get; set; }

    }


}
