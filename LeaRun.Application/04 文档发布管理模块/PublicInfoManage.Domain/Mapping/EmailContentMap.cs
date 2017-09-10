using LeaRun.PublicInfoManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.PublicInfoManage.Mapping
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.12.8 11:31
    /// 描 述：邮件内容
    /// </summary>
    public class EmailContentMap : EntityTypeConfiguration<EmailContentEntity>
    {
        public EmailContentMap()
        {
            #region 表、主键
            //表
            this.ToTable("Email_Content");
            //主键
            this.HasKey(t => t.ContentId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
