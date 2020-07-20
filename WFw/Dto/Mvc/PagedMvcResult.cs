using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Dto.Mvc
{
    public class PagedMvcResult<T> : PagedResult<T>, IOutputDto
        where T : class
    {

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return ((PageIndex * PageSize) < Total);
            }
        }

        public string PrevDisabled => HasPreviousPage == false ? "disabled" : "";
        public string NextDisabled => HasNextPage == false ? "disabled" : "";

        public PagedMvcResult(PagedResult<T> result) : base(result)
        {
        }



    }
}
