﻿using LeaRun.SystemManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.SystemManage.Mapping
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.11.12 16:40
    /// 描 述：区域管理
    /// </summary>
    public class ApplicationMap : EntityTypeConfiguration<APP_Application>
    {
        public ApplicationMap()
        {
            #region 表、主键
            //表
            this.ToTable("APP_Application");
            //主键
            this.HasKey(t => t.app_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
