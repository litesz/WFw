using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using WFw.Entity;

namespace WFw.Identity.Entities
{
    [SugarTable("Identity_Role")]
    public class Role : FullAuditEntityBase<int>
    {

       


        [SugarColumn(Length = 16)]
        public string Name { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsSystem { get; set; }
    }
}
