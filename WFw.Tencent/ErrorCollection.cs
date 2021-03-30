using System.Collections.Generic;
using WFw.Tencent.Responses;

namespace WFw.Tencent
{
    public static class ErrorCollection
    {

        private static Dictionary<int, string> items = new Dictionary<int, string> {

            { -1,"系统繁忙，此时请开发者稍候再试"},
            { 0,"请求成功"},
            { 40029,"code无效"},
            { 40163,"code已使用"},
            { 45011,"频率限制，每个用户每分钟100次"},
            //
        };

        public static string GetErrTxt(BaseResponse response)
        {
            if (items.ContainsKey(response.Errcode))
            {
                return items[response.Errcode];
            }
            return response.ErrMsg;
        }


       

    }
}
