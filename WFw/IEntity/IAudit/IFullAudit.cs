﻿using WFw.IEntity.IAudit;

namespace WFw.IEntity
{
    /// <summary>
    /// 仅状态审计接口
    /// </summary>
    public interface IFullAudit : IOnlyNewAudited, ISoftDeletable
    { }


}

