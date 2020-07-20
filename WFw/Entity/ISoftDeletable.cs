using System;

namespace WFw.Entity
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
        DateTime DeletedTime { get; set; }
      

    }

}
