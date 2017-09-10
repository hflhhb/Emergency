using LeaRun.CustomerManage.Entity;
using LeaRun.CustomerManage.IService;
using LeaRun.Data;
using LeaRun.Util.Extension;
using LeaRun.Util.Web;
using LeaRun.Util;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.CustomerManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创 建：westinfeng
    /// 日 期：2016-03-19 14:25
    /// 描 述：客户联系人
    /// </summary>
    public class CustomerContactService : Dao<CustomerContactEntity>, ICustomerContactService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public CustomerContactService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<CustomerContactEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<CustomerContactEntity>();
            var queryParam = queryJson.ToJObject();
            //客户Id
            if (!queryParam["customerId"].IsEmpty())
            {
                string CustomerId = queryParam["customerId"].ToString();
                expression = expression.And(t => t.CustomerId == CustomerId);
            }
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "Contact":         //联系人
                        expression = expression.And(t => t.Contact.Contains(keyword));
                        break;
                    case "Mobile":          //手机
                        expression = expression.And(t => t.Mobile.Contains(keyword));
                        break;
                    case "Tel":             //电话
                        expression = expression.And(t => t.Tel.Contains(keyword));
                        break;
                    case "QQ":              //QQ
                        expression = expression.And(t => t.QQ.Contains(keyword));
                        break;
                    default:
                        break;
                }
            }
            return base.Queryable(expression).OrderByDescending(t => t.CreateDate).ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public CustomerContactEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            base.Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, CustomerContactEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                base.Update(entity);
            }
            else
            {
                try
                {
                    entity.Create();
                    base.Insert(entity);
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
            }
        }
        #endregion
    }
}