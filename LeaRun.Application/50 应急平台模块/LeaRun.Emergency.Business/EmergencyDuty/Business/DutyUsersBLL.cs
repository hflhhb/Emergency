using LeaRun.EmergencyDuty.Entity;
using LeaRun.EmergencyDuty.IService;
using LeaRun.EmergencyDuty.Service;
using LeaRun.Data;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System;

namespace LeaRun.EmergencyDuty.Business
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创 建：HFL
    /// 日 期：2017-11-01 21:39
    /// 描 述：值班人员表
    /// </summary>
    public class DutyUsersBLL
    {
        private IDutyUsersService service = new DutyUsersService(DbFactory.Applicate());

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<DutyUsersEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<DutyUsersEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DutyUsersEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
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
        /// <returns></returns>
        public void SaveForm(string keyValue, DutyUsersEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
