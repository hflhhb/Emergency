﻿using LeaRun.ResourceManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.ResourceManage.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 HFL
    /// 创 建：admin
    /// 日 期：2017-09-15 18:12
    /// 描 述：GasStation
    /// </summary>
    public class GasStationMap : EntityTypeConfiguration<GasStationEntity>
    {
        public GasStationMap()
        {
            #region 表、主键
            //表
            this.ToTable("RC_GasStation");
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
