using LeaRun.WorkflowEngine.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.WorkflowEngine.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.01.14 09:58
    /// 描 述：表单管理
    /// </summary>
    public class WFFrmMainMap : EntityTypeConfiguration<WFFrmMainEntity>
    {
        public WFFrmMainMap()
        {
            #region 表、主键
            //表
            this.ToTable("WF_FrmMain");
            //主键
            this.HasKey(t => t.FrmMainId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
