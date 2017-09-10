using LeaRun.CustomerManage.Entity;
using LeaRun.CustomerManage.IService;
using LeaRun.Data;
using LeaRun.Util.Web;
using LeaRun.Util.Extension;
using LeaRun.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.CustomerManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创 建：westinfeng
    /// 日 期：2016-04-28 16:48
    /// 描 述：现金余额
    /// </summary>
    public class CashBalanceService : Dao<CashBalanceEntity>, ICashBalanceService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public CashBalanceService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<CashBalanceEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<CashBalanceEntity>();
            var queryParam = queryJson.ToJObject();
            //单据日期
            if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                DateTime startTime = queryParam["StartTime"].ToDate();
                DateTime endTime = queryParam["EndTime"].ToDate().AddDays(1);
                expression = expression.And(t => t.ExecutionDate >= startTime && t.ExecutionDate <= endTime);
            }
            return base.Queryable(expression).OrderBy(t => t.CreateDate).ToList();
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 添加收支余额
        /// </summary>
        /// <param name="db"></param>
        /// <param name="cashBalanceEntity"></param>
        public void AddBalance(CashBalanceEntity cashBalanceEntity)
        {
            decimal balance = 0;
            var data = db.Queryable<CashBalanceEntity>(t => t.CashAccount == cashBalanceEntity.CashAccount).OrderByDescending(t => t.CreateDate);
            if (data.Count() > 0)
            {
                balance = data.First().Balance.ToDecimal();
            }
            if (cashBalanceEntity.Receivable != null)
            {
                cashBalanceEntity.Balance = cashBalanceEntity.Receivable + balance;
            }
            if (cashBalanceEntity.Expenses != null)
            {
                cashBalanceEntity.Balance = balance - cashBalanceEntity.Expenses;
            }
            cashBalanceEntity.Create();
            db.Insert(cashBalanceEntity);
        }
        #endregion
    }
}
