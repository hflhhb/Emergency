using LeaRun.PublicInfoManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.PublicInfoManage.Mapping
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.12.7 16:40
    /// 描 述：新闻中心
    /// </summary>
    public class NewsMap : EntityTypeConfiguration<NewsEntity>
    {
        public NewsMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_News");
            //主键
            this.HasKey(t => t.NewsId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
