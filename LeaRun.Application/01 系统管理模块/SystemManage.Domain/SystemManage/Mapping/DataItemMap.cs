﻿using LeaRun.SystemManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.SystemManage.Mapping
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.11.17 9:56
    /// 描 述：数据字典分类
    /// </summary>
    public class DataItemMap : EntityTypeConfiguration<DataItemEntity>
    {
        public DataItemMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_DataItem");
            //主键
            this.HasKey(t => t.ItemId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
