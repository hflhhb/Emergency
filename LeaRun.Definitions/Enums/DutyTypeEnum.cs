using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaRun.Definitions.Enums
{
    /// <summary>
    /// 值班类型
    /// </summary>
    public enum DutyTypeEnum
    {

        /// <summary>
        /// 白班
        /// </summary>
        [Description("白班")]
        Daytime = 5,
        /// <summary>
        /// 中班
        /// </summary>
        [Description("中班")]
        Noon = 4,
        /// <summary>
        /// 夜班
        /// </summary>
        [Description("夜班")]
        Night = 3,
        /// <summary>
        /// 节假日 
        /// </summary>
        [Description("节假日")]
        Holiday = 2,
        /// <summary>
        /// 非正常 
        /// </summary>
        [Description("非正常")]
        Abnormal = 1,
        /// <summary>
        /// 领导 
        /// </summary>
        [Description("领导")]
        Leader = 27,
        /// <summary>
        /// 日备 
        /// </summary>
        [Description("日备")]
        DayBackup = 423,

    }
}