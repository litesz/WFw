using System.Threading.Tasks;
using TencentCloud.Ocr.V20181119.Models;

namespace WFw.TencentCloud.Clients.Ocr
{
    public interface IWFwOcrClient
    {

        Task<BizLicenseOCRResponse> BizLicenseOCR(string imageUrl);
    }
}
