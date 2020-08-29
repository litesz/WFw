using Newtonsoft.Json;

namespace WFw.GeTui.Models.Push.ToApp
{
    /// <summary>
    /// 推送条件
    /// </summary>
    /// <remarks>
    /// 不同key之间是交集，同一个key之间是根据opt_type操作
    /// 需要发送给城市在A,B,C里面，没有设置tagtest标签，手机型号为android的用户，用条件交并补功能可以实现，city(A|B|C) and !tag(tagtest) and phonetype(android)
    /// </remarks>
    public class AudienceTag
    {
        /// <summary>
        /// 查询条件(phone_type 手机类型; region 省市; custom_tag 用户标签
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 查询条件值列表，其中
        /// 手机型号使用如下参数android和ios；
        /// 省市使用编号
        /// </summary>
        public string[] Values { get; set; }

        /// <summary>
        /// or(或),and(与),not(非)，values间的交并补操作
        /// </summary>
        [JsonProperty("opt_type")]
        public string Type { get; set; }

    }
}
