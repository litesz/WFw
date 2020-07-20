using System.Collections.Generic;
using WFw.Core.Identity.Entities;
using WFw.Dto;

namespace WFw.Identity.Dtos
{
    public class PagedUserQueryInputDto : PagedResultRequestDto
    {
        public int? OrganizationId { get; set; }
    }


    public class PagedUserWithOrganizationQueryInputDto : PagedResultRequestDto
    {
        public int? ProvinceId { get; set; }
    }

    public class UserWithOrganizationQueryOutputDto : IOutputDto
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string OrganizationName { get; set; }
        public int OrganizationId { get; set; }
        public string Remark { get; set; }
        public int DistrictId { get; set; }
        public UserAuditType UserAuditState { get; set; }
    }

    public class PagedUserWithOrganizationQueryOutputDto : PagedResultDto<UserWithOrganizationQueryOutputDto>
    {
        public PagedUserWithOrganizationQueryOutputDto(IEnumerable<UserWithOrganizationQueryOutputDto> items, int total) : base(items, total)
        {
        }
    }
}
