using LeaRun.ResourceManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.ResourceManage.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 HFL
    /// 创 建：admin
    /// 日 期：2017-09-15 19:03
    /// 描 述：School
    /// </summary>
    public class SchoolMap : EntityTypeConfiguration<SchoolEntity>
    {
        public SchoolMap()
        {
            #region 表、主键
            //表
            this.ToTable("RC_School");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            this.Property(o => o.Longitude).IsRequired().HasPrecision(19, 16);
            this.Property(o => o.Latitude).IsRequired().HasPrecision(19, 16);
            #endregion
        }
    }
}
