
namespace LeaRun.SystemManage.Entity
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.24 13:32
    /// 描 述：数据库实体
    /// </summary>
    public class DatabaseEntity
    {
        /// <summary>
        /// 数据库英文名
        /// </summary>
        public string  Name { get; set; }
        /// <summary>
        /// 数据库中文名称
        /// </summary>
        public string  Description { get; set; } 

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
