using LeaRun.SystemManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.SystemManage.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 肖海根
    /// 创 建：admin
    /// 日 期：2017-03-12 07:58
    /// 描 述：数据库表字段
    /// </summary>
    public class DBTableFieldMap : EntityTypeConfiguration<DBTableFieldEntity>
    {
        public DBTableFieldMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_DBTableField");
            //主键
            this.HasKey(t => t.Field_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
