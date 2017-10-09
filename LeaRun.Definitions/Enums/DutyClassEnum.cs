using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaRun.Definitions.Enums
{
    /// <summary>
    /// 值班表分类
    /// </summary>
    public enum DutyClassEnum
    {
        /// <summary>
        /// 月值班表
        /// </summary>
        [Description("月值班表")]
        Month = 397,
        /// <summary>
        /// 午值班表 
        /// </summary>
        [Description("午值班表")]
        Noon = 396,
        /// <summary>
        /// 机动值班表 
        /// </summary>
        [Description("机动值班表")]
        Flexible = 395,
        /// <summary>
        /// 驾驶员值班表 
        /// </summary>
        [Description("驾驶员值班表")]
        Driver = 394,
        /// <summary>
        /// 节假日领导值班表 
        /// </summary>
        [Description("节假日领导值班表")]
        HolidayLeader = 448,

    }
}