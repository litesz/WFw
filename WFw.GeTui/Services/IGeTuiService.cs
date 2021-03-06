﻿using System.Threading.Tasks;

namespace WFw.GeTui.Services
{
    public partial interface IGeTuiService
    {
        /// <summary>
        /// 获得token
        /// </summary>
        /// <returns></returns>
        Task LoadToken(bool isRefresh = false);

        /// <summary>
        /// 注销token
        /// </summary>
        /// <returns></returns>
        Task DeleteToken();
    }
}
