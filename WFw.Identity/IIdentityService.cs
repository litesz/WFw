using System.Threading.Tasks;
using WFw.Core.Identity.Entities;
using WFw.Identity.Dtos;

namespace WFw.Identity
{
    public interface IIdentityService
    {
        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="dto">注册信息</param>
        /// <returns>业务操作结果</returns>
        Task RegisterWithOrganization(RegisterWithOrganizationDto dto, bool isLock);
        Task<LoginResultDto> Login(LoginDto dto);
        Task Logout();


        Task<PagedUserQueryOutputDto> GetPagedUser(PagedUserQueryInputDto inputDto);

        Task<PagedUserWithOrganizationQueryOutputDto> GetPagedUserWithOrganization(PagedUserWithOrganizationQueryInputDto inputDto);

        Task AgreeUserAduit(int id);
        Task RefuseUserAduit(int id);
        Task LockOrganization(int id);
        Task UnLockOrganization(int id);
        Task BindRole(int userId, int roleId);
        Task<bool> ValidPassword(int id, string password);
        Task UpdatePassword(string phone, string newPassword);
    }
}
