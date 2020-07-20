using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Mapping
{



    /// <summary>
    /// 标注当前类型映射到目标类型的Mapping映射关系
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MapFromAttribute : Attribute
    {
        /// <summary>
        /// 初始化一个<see cref="MapFromAttribute"/>类型的新实例
        /// </summary>
        public MapFromAttribute(params Type[] targetTypes)
        {
            // Check.NotNull(targetTypes, nameof(targetTypes));
            TargetTypes = targetTypes;
        }

        /// <summary>
        /// 目标类型
        /// </summary>
        public Type[] TargetTypes { get; }
    }
}
