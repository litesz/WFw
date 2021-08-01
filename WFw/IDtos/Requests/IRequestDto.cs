
namespace WFw.IDtos.Requests
{
    /// <summary>
    /// 请求dto
    /// </summary>
    public interface IRequestDto : IDto {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        (bool isOk, string errMsg) ValidateParams();
    }
}
