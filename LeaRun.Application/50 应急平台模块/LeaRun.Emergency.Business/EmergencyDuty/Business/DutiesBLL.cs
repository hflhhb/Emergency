using LeaRun.EmergencyDuty.Entity;
using LeaRun.EmergencyDuty.IService;
using LeaRun.EmergencyDuty.Service;
using LeaRun.Data;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System;
using LeaRun.Util;

namespace LeaRun.EmergencyDuty.Business
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创 建：admin
    /// 日 期：2017-09-28 00:06
    /// 描 述：值班表
    /// </summary>
    public class DutiesBLL
    {
        private IDutiesService service = new DutiesService(DbFactory.Applicate());
        private IDutyDetailsService detailSvc = new DutyDetailsService(DbFactory.Applicate()); 

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<DutiesEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<DutiesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DutiesEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }

        public IEnumerable<DutyDetailsEntity> GetDutyDetails(string dutyId)
        {
            return detailSvc.GetList(new { DutyId = dutyId }.ToJson());
        }

        public DutiesEntity GetDeptDuty(int dutyClass, string deptId, string month)
        {
            return service.GetDeptDuty(dutyClass, deptId, month);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <param name="dutyDetailList">明细实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DutiesEntity entity, List<DutyDetailsEntity> dutyDetailList)
        {
            try
            {
                service.SaveForm(keyValue, entity, dutyDetailList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
