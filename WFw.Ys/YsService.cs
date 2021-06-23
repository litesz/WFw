using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Ys
{
    public interface IYsService
    {

    }

    public class YsService : IYsService
    {
        private readonly IServiceProvider serviceProvider;
        public YsService(IServiceProvider sp)
        {
            serviceProvider = sp;
        }





    }
}
