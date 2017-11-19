using LeaRun.EmergencyDuty.Entity;
using LeaRun.EmergencyDuty.Business;
using LeaRun.Util;
using LeaRun.Util.Web;
using LeaRun.WebBase;
using System.Web.Mvc;
using LeaRun.UserManage.Cache;
using LeaRun.EmergencyDuty.Model;
using System.Collections.Generic;
using LeaRun.Util.Extension;
using LeaRun.Definitions.Enums;
using LeaRun.Definitions;

namespace LeaRun.EmergencyDuty.Controllers
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 HFL
    /// 创 建：admin
    /// 日 期：2017-11-01 21:55
    /// 描 述：突发事件上报
    /// </summary>
    public class EmergencyReportsController : MvcControllerBase
    {
        private DepartmentCache departmentCache = new DepartmentCache();
        private DataItemCache dataItemCache = new DataItemCache();
        private EmergencyReportsBLL emergencyreportsbll = new EmergencyReportsBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = emergencyreportsbll.GetPageList(pagination, queryJson);
            foreach (var vm in data)
            {
                vm.EvtClassDesc = vm.EvtClass.ToEnum<EventClassEnum>().ToDescription();
                vm.EvtSubClassDesc = dataItemCache.ToItemName("EventClass", vm.EvtSubClass);
                vm.EvtAreaName = dataItemCache.ToItemName("EventArea", vm.EvtArea);
                vm.SendDeptName = departmentCache.ToDeptName(vm.SendDept);
            }

            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = emergencyreportsbll.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = emergencyreportsbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            emergencyreportsbll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, EmergencyReportsEntity entity)
        {
            emergencyreportsbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
