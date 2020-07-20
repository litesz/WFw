namespace WFw.Dto
{

    public class LimitedResultRequestDto : ILimitedResultRequestDto, IInputDto
    {
        private int pageSize = 10;

        public virtual int PageSize
        {
            get
            {
                if (pageSize > 1_000)
                {
                    return 1_000;
                }
                else if (pageSize < 0)
                {
                    return 0;
                }

                return pageSize;
            }
            set => pageSize = value;
        }

    }
}
