using System.Collections.Generic;
using WFw.Tencent.Responses;

namespace WFw.Tencent
{
    public static class ErrorCollection
    {

        private static Dictionary<int, string> items = new Dictionary<int, string> {

            { -1,"系统繁忙，此时请开发者稍候再试"},
            { 0,"请求成功"},
            { 40001,"AppSecret 错误，或者 access_token 无效"},
            { 40002,"请确保grant_type字段值为client_credential"},
            { 40013,"appid无效"},
            { 40029,"code无效"},
            { 40163,"code已使用"},
            { 40164,"调用接口的IP地址不在白名单中"},
            { 45011,"频率限制，每个用户每分钟100次"},
            { 89501,"此IP正在等待管理员确认,请联系管理员"},
            { 89503,"此IP调用需要管理员确认,请联系管理员"},
            { 89506,"24小时内该IP被管理员拒绝调用两次，24小时内不可再使用该IP调用"},
            { 89507,"1小时内该IP被管理员拒绝调用一次，1小时内不可再使用该IP调用"},
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
