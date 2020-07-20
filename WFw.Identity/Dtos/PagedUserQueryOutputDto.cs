using System.Collections.Generic;
using WFw.Dto;

namespace WFw.Identity.Dtos
{
    public class PagedUserQueryOutputDto : PagedResultDto<UserQueryOutputDto>
    {
        public PagedUserQueryOutputDto(IEnumerable<UserQueryOutputDto> items, int total) : base(items, total)
        {
        }
    }
}
