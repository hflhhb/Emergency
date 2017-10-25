using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Definitions.Enums
{
    /// <summary>
    /// 大事件类型
    /// </summary>
    public enum EventTypeEnum
    {
        /// <summary>
        /// 自然灾害
        /// </summary>
        [Description("自然灾害")]
        Natural = 1,

        /// <summary>
        /// 事故灾害
        /// </summary>
        [Description("事故灾害")]
        Accident = 2,

        /// <summary>
        /// 公共卫生事件
        /// </summary>
        [Description("公共卫生事件")]
        Health = 3,

        /// <summary>
        /// 社会安全事件
        /// </summary>
        [Description("社会安全事件")]
        Secure = 4,

        /// <summary>
        /// 其它
        /// </summary>
        [Description("其它")]
        Other = 5
    }
}
