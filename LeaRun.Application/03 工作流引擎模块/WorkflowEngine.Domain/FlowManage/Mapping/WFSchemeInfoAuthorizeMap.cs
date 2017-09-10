using LeaRun.WorkflowEngine.Entity;
using System.Data.Entity.ModelConfiguration;
namespace LeaRun.WorkflowEngine.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.03.18 09:58
    /// 描 述：工作流模板权限表
    /// </summary>
    public class WFSchemeInfoAuthorizeMap : EntityTypeConfiguration<WFSchemeInfoAuthorizeEntity>
    {
        public WFSchemeInfoAuthorizeMap()
        {
            #region 表、主键
            //表
            this.ToTable("WF_SchemeInfoAuthorize");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
