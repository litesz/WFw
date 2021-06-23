using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Ys.Options
{
    public class YsOptions
    {
        public const string Position = "Ys";
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
    }

    public interface IAccountInfo
    {
        string AppKey { get;  }
        string AppSecret { get;  }
    }
}
