using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaRun.Definitions.Enums
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum DutyNoteTypeEnum
    {
        /// <summary>
        /// 其他信息
        /// </summary>
        [Description("其他信息")]
        Other = 0,
        /// <summary>
        /// 突发事件
        /// </summary>
        [Description("突发事件")]
        Event = 1
    }
}