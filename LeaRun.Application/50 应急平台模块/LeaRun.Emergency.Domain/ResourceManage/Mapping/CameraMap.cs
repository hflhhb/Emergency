using LeaRun.ResourceManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.ResourceManage.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 肖海根
    /// 创 建：HFL
    /// 日 期：2017-09-13 00:46
    /// 描 述：Camera
    /// </summary>
    public class CameraMap : EntityTypeConfiguration<CameraEntity>
    {
        public CameraMap()
        {
            #region 表、主键
            //表
            this.ToTable("RC_Camera");
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
