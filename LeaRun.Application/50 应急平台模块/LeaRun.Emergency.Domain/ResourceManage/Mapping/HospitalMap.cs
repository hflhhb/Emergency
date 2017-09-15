using LeaRun.ResourceManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.ResourceManage.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 HFL
    /// 创 建：admin
    /// 日 期：2017-09-15 17:51
    /// 描 述：Hospital
    /// </summary>
    public class HospitalMap : EntityTypeConfiguration<HospitalEntity>
    {
        public HospitalMap()
        {
            #region 表、主键
            //表
            this.ToTable("RC_Hospital");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
