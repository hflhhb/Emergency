using LeaRun.CustomerManage.Entity;
using LeaRun.CustomerManage.IService;
using LeaRun.CustomerManage.Service;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System;

namespace LeaRun.CustomerManage.Business
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创 建：westinfeng
    /// 日 期：2016-04-06 17:24
    /// 描 述：应收账款
    /// </summary>
    public class ReceivableBLL
    {
        private IReceivableService service = new ReceivableService(LeaRun.Data.DbFactory.CRM());

        #region 获取数据
        /// <summary>
        /// 获取收款单列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<OrderEntity> GetPaymentPageList(Pagination pagination, string queryJson)
        {
            return service.GetPaymentPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取收款记录列表
        /// </summary>
        /// <param name="orderId">订单主键</param>
        /// <returns></returns>
        public IEnumerable<ReceivableEntity> GetPaymentRecord(string orderId)
        {
            return service.GetPaymentRecord(orderId);
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
            try
            {
                service.SaveForm(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}