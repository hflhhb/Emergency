using LeaRun.CustomerManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.CustomerManage.Mapping
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创 建：westinfeng
    /// 日 期：2016-04-20 11:23
    /// 描 述：费用支出
    /// </summary>
    public class ExpensesMap : EntityTypeConfiguration<ExpensesEntity>
    {
        public ExpensesMap()
        {
            #region 表、主键
            //表
            this.ToTable("Client_Expenses");
            //主键
            this.HasKey(t => t.ExpensesId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
