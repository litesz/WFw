using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WFw.Tencent.Responses;

namespace WFw.WxMiniProgram.Dtos.Wxa
{
    public class GetPaidUnionIdResponse : BaseResponse
    {

        [JsonProperty("unionid")]
        public string UnionId { get; set; }
    }

    public class GetPaidUnionIdRequest
    {

        public string TransactionId { get; set; }

        public string OutTradeNo { get; set; }
        public string MchId { get; set; }

        public string OpenId { get; set; }
        public string AccessToken { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(AccessToken) || string.IsNullOrWhiteSpace(OpenId))
            {
                throw new WFwException(Results.OperationResultType.IsEmpty, "AccessToken 或 OpenId", $"AccessToken:{AccessToken}|OpenId:{OpenId}");
            }

            if (!string.IsNullOrWhiteSpace(TransactionId))
            {
                return $"access_token={AccessToken}&openid={OpenId}&transaction_id={TransactionId}";
            }
            else if (!string.IsNullOrWhiteSpace(OutTradeNo))
            {
                return $"access_token={AccessToken}&openid={OpenId}&mch_id={MchId}&out_trade_no=OutTradeNo";
            }
            return $"access_token={AccessToken}&openid={OpenId}";
        }

    }
}
