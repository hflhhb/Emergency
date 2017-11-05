using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaRun.Definitions.Enums
{
    /// <summary>
    /// 数据字典编码
    /// </summary>
    public enum DataItemCodeEnum
    {
        /// <summary>
        /// 接报形式
        /// </summary>
        [Description("接报形式")]
        ReceivedType = 2,
        /// <summary>
        /// 事发区域 
        /// </summary>
        [Description("事发区域")]
        EventArea = 3,
        /// <summary>
        /// 人员状态 
        /// </summary>
        [Description("人员状态")]
        EmployeeStatus = 4,
        /// <summary>
        /// 报告类别 
        /// </summary>
        [Description("报告类别")]
        ReportType = 5,
        /// <summary>
        /// 信息来源 
        /// </summary>
        [Description("信息来源")]
        InfoSource = 9,

    }
}