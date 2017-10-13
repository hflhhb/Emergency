using LeaRun.EmergencyDuty.Entity;
using LeaRun.EmergencyDuty.IService;
using LeaRun.Data;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util.Extension;
using LeaRun.Util;
using LeaRun.AuthorizeManage.Service;
using LeaRun.AuthorizeManage.IService;
using System;

namespace LeaRun.EmergencyDuty.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 HFL
    /// 创 建：admin
    /// 日 期：2017-09-28 00:06
    /// 描 述：值班表
    /// </summary>
    public class DutiesService : Dao<DutiesEntity>, IDutiesService
    {
        private IAuthorizeService<DutiesEntity> iauthorizeservice = null;
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public DutiesService(DbContextBase dbcontext) : base(dbcontext)
        {
            iauthorizeservice = new AuthorizeService<DutiesEntity>(dbcontext);
        }

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<DutiesEntity> GetList(string queryJson)
        {           
            return base.Queryable().ToList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<DutiesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<DutiesEntity>();
            var queryParam = queryJson.ToJObject();

            if (!queryParam["DutyClass"].IsEmpty())
            {
                var dutyClass = queryParam["DutyClass"].ToIntOrNull();
                expression = expression.And(t => t.DutyClass == dutyClass);
            }

            if (!queryParam["Contracts"].IsEmpty())
            {
                var contracts = queryParam["Contracts"].ToString();
                expression = expression.And(t => t.Contacts.Contains(contracts));
            }

            if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                var startMonth = queryParam["StartTime"].ToString().ToDateOrNull();
                var endMonth = queryParam["EndTime"].ToString().ToDateOrNull();
                if (startMonth.HasValue)
                {
                    expression = expression.And(t => t.StartedOn >= startMonth);
                }
                if (endMonth.HasValue)
                {
                    expression = expression.And(t => t.StartedOn < endMonth);
                }
            }

            return base.FindList(expression, pagination);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DutiesEntity GetEntity(string keyValue)
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
            db.BeginTrans();
            try
            {
                db.Delete<DutiesEntity>(keyValue);
                db.Delete<DutyDetailsEntity>(t => t.DutyId.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dutyEntity">实体对象</param>
        /// <param name="dutyDetailList">明细实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DutiesEntity dutyEntity, List<DutyDetailsEntity> dutyDetailList)
        {
            db.BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //主表
                    dutyEntity.Modify(keyValue);
                    db.Update(dutyEntity);
                    //明细
                    db.Delete<DutyDetailsEntity>(t => t.DutyId.Equals(keyValue));
                }
                else
                {
                    //主表
                    dutyEntity.Create();
                    db.Insert(dutyEntity);
                    
                }
                //明细
                foreach (var dutyDetail in dutyDetailList)
                {
                    if (dutyDetail.Id.IsNullOrEmpty()) dutyDetail.Create();
                    dutyDetail.DutyId = dutyEntity.Id;
                    db.Insert(dutyDetail);
                }
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
