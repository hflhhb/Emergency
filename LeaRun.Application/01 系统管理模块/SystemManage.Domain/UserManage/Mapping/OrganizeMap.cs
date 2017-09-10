using LeaRun.UserManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.UserManage.Mapping
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.11.02 14:27
    /// 描 述：机构管理
    /// </summary>
    public class OrganizeMap : EntityTypeConfiguration<OrganizeEntity>
    {
        public OrganizeMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_Organize");
            //主键
            this.HasKey(t => t.OrganizeId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
