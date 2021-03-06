﻿using LeaRun.EmergencyDuty.Entity;
using LeaRun.Util.Web;
using System.Collections.Generic;

namespace LeaRun.EmergencyDuty.IService
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创 建：admin
    /// 日 期：2017-09-28 00:06
    /// 描 述：值班表
    /// </summary>
    public interface IDutiesService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<DutiesEntity> GetList(string queryJson);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<DutiesEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        DutiesEntity GetEntity(string keyValue);

        /// <summary>
        /// 所选部门的最新值班安排
        /// </summary>
        /// <param name="dutyClass"></param>
        /// <param name="deptId"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        DutiesEntity GetDeptDuty(int dutyClass, string deptId, string month);

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <param name="dutyDetailList">明细实体对象</param>
        /// <returns></returns>
        void SaveForm(string keyValue, DutiesEntity entity, List<DutyDetailsEntity> dutyDetailList);
        #endregion
    }
}
