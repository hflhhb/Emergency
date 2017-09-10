﻿using LeaRun.MessageManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.MessageManage.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.11.26 18:23
    /// 描 述：即时通信未读消息表
    /// </summary>
    public class IMReadMap : EntityTypeConfiguration<IMReadEntity>
    {
        public IMReadMap()
        {
            #region 表、主键
            //表
            this.ToTable("IM_Read");
            //主键
            this.HasKey(t => t.ReadId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
