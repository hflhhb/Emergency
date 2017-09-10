
namespace LeaRun.SystemManage.Entity
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.24 13:32
    /// 描 述：数据库表实体
    /// </summary>
    public class DatabaseTableEntity
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 表说明
        /// </summary>
        public string tdescription { get; set; }

        /// <summary>
        /// 主键字段
        /// </summary>
        public string pk { get; set; }
        /// <summary>
        /// 表类型
        /// </summary>
        public string reserved { get; set; }
        /// <summary>
        /// 记录数
        /// </summary>
        public string sumrows { get; set; }
        /// <summary>
        /// 数据区大小
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 索引使用大小
        /// </summary>
        public string index_size { get; set; }
         
        /// <summary>
        /// 未使用空间
        /// </summary>
        public string unused { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string updatetime { get; set; }
    }
}
