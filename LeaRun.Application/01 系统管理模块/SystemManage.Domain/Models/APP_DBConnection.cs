using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LeaRun.SystemManage.Entity
{
    /// <summary>
    /// 数据库连接从属于应用系统，一个应用系统可以有多个数据库连接。
    /// </summary>
    public class APP_DBConnection : LeaRun.Data.BaseEntity
    {
        /// <summary>
        /// 数据库链接 GUID
        /// </summary>
        [Key]
        public Guid db_Guid { get; set; }


        /// <summary>
        /// 所属应用
        /// </summary>
        public string db_App { get; set; }

        /// <summary>
        /// 数据库英文名
        /// </summary>
        public string db_Name { get; set; }

        /// <summary>
        /// 数据库中文名
        /// </summary>
        public string db_Desc { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public string db_Type { get; set; }


        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        public string db_ConnectionString { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string db_Note { get; set; }
         
    }
}
