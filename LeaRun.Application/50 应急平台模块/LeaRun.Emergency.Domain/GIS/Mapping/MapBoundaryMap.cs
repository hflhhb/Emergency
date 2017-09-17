using LeaRun.GIS.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.GIS.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 HFL
    /// 创 建：admin
    /// 日 期：2017-09-17 21:31
    /// 描 述：MapBoundary
    /// </summary>
    public class MapBoundaryMap : EntityTypeConfiguration<MapBoundaryEntity>
    {
        public MapBoundaryMap()
        {
            #region 表、主键
            //表
            this.ToTable("GIS_MapBoundary");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
