using System.ComponentModel;

namespace LeaRun.Util.Enums
{
    /// <summary>
    /// 数据类型
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// 未知
        /// </summary>
        None,
        /// <summary>
        /// 整型
        /// </summary>
        Int,
        /// <summary>
        /// 数字
        /// </summary>
        Number,
        /// <summary>
        /// 日期
        /// </summary>
        DateTime,
        /// <summary>
        /// 布尔值
        /// </summary>
        Bool,
        /// <summary>
        /// 枚举
        /// </summary>
        Enum
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    public enum SQLDataType
    {
        [Description("整型")]
        Int,


        [Description("数值")]
        Decimal,
 
        [Description("日期")]
        DateTime,

        [Description("布尔值")]
        Bit,

        [Description("文本")]
        VarChar,

        [Description("本地语言文本")]
        NVarChar,

        [Description("长文本")]
        Text, 
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    public enum FieldDataSourceType
    {
        [Description("布尔值")]
        Boolean,


        [Description("枚举值")]
        Enum,

        [Description("选择值列表")]
        OptionList,

        [Description("数据字典")]
        Dictionary,

        [Description("外键字段")]
        ForeignField, 
    }


    /// <summary>
    /// 数据类型
    /// </summary>
    public enum enumDictValueField
    {
        [Description("Guid键值")]
        ItemDetailId,


        [Description("代码值")]
        ItemCode, 
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    public enum enumDictFilterField
    {
        [Description("数据域")]
        ItemDomain,
         
        [Description("地点")]
        ItemSite,

        [Description("应用程序名")]
        ItemApplication,

        [Description("父键Guid值")]
        ItemId, 
    }
}
