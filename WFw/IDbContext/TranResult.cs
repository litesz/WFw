namespace WFw.IDbContext
{
    /// <summary>
    /// 事务运行结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TranResult<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Exception ErrorException { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }
    }
}
