using LeaRun.SystemManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.SystemManage.Mapping
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.25 11:02
    /// 描 述：数据库备份
    /// </summary>
    public class DataBaseBackupMap : EntityTypeConfiguration<DatabaseBackupEntity>
    {
        public DataBaseBackupMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_DatabaseBackup");
            //主键
            this.HasKey(t => t.DatabaseBackupId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
