using LeaRun.CustomerManage.Entity;
using LeaRun.CustomerManage.IService;
using LeaRun.Data;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.CustomerManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创 建：westinfeng
    /// 日 期：2016-04-06 17:24
    /// 描 述：应收账款
    /// </summary>
    public class ReceivableService : Dao<ReceivableEntity>, IReceivableService
    {
        private IOrderService orderIService = null;

        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public ReceivableService(DbContextBase dbcontext) : base(dbcontext){
            orderIService = new OrderService(dbcontext);
        }

        #region 获取数据
        /// <summary>
        /// 获取收款单列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<OrderEntity> GetPaymentPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<OrderEntity>();
            var queryParam = queryJson.ToJObject();
            //单据日期
            if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                DateTime startTime = queryParam["StartTime"].ToDate();
                DateTime endTime = queryParam["EndTime"].ToDate().AddDays(1);
                expression = expression.And(t => t.OrderDate >= startTime && t.OrderDate <= endTime);
            }
            //单据编号
            if (!queryParam["OrderCode"].IsEmpty())
            {
                string OrderCode = queryParam["OrderCode"].ToString();
                expression = expression.And(t => t.OrderCode.Contains(OrderCode));
            }
            //客户名称
            if (!queryParam["CustomerName"].IsEmpty())
            {
                string CustomerName = queryParam["CustomerName"].ToString();
                expression = expression.And(t => t.CustomerName.Contains(CustomerName));
            }
            //销售人员
            if (!queryParam["SellerName"].IsEmpty())
            {
                string SellerName = queryParam["SellerName"].ToString();
                expression = expression.And(t => t.SellerName.Contains(SellerName));
            }
            return base.db.FindList<OrderEntity>(expression, pagination);
        }
        /// <summary>
        /// 获取收款记录列表
        /// </summary>
        /// <param name="orderId">订单主键</param>
        /// <returns></returns>
        public IEnumerable<ReceivableEntity> GetPaymentRecord(string orderId)
        {
            return base.Queryable(t => t.OrderId.Equals(orderId)).OrderByDescending(t => t.CreateDate).ToList();
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存表单（新增）
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(ReceivableEntity entity)
        {
            ICashBalanceService icashbalanceservice = new CashBalanceService(LeaRun.Data.DbFactory.CRM());
            OrderEntity orderEntity = orderIService.GetEntity(entity.OrderId);

            db.BeginTrans();
            try
            {
                //更改订单状态
                orderEntity.ReceivedAmount = orderEntity.ReceivedAmount + entity.PaymentPrice;
                if (orderEntity.ReceivedAmount == orderEntity.Accounts)
                {
                    orderEntity.PaymentState = 3;
                }
                else
                {
                    orderEntity.PaymentState = 2;
                }
                db.Update(orderEntity);
                //添加收款
                entity.Create();
                db.Insert(entity);
                //添加账户余额
                icashbalanceservice.AddBalance(new CashBalanceEntity
                {
                    ObjectId = entity.ReceivableId,
                    ExecutionDate = entity.PaymentTime,
                    CashAccount = entity.PaymentAccount,
                    Receivable = entity.PaymentPrice,
                    Abstract = entity.Description
                });

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}