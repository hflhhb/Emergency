using LeaRun.Definitions;
using LeaRun.Definitions.Enums;
using LeaRun.EmergencyDuty.Business;
using LeaRun.EmergencyDuty.Entity;
using LeaRun.EmergencyDuty.Model;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.Web;
using LeaRun.WebBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.EmergencyDuty.Controllers
{
    public class DutiesController : MvcControllerBase
    {
        private DutiesBLL dutiesbll = new DutiesBLL();

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

        [HttpGet]
        public ActionResult MonthDuty()
        {
            var model = new DutiesViewModel()
            {
                DutyClass = DutyClassEnum.Month
            };
            return View("Index", model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult NoonDuty()
        {
            var model = new DutiesViewModel()
            {
                DutyClass = DutyClassEnum.Noon
            };
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult HolidayDuty()
        {
            var model = new DutiesViewModel()
            {
                DutyClass = DutyClassEnum.Flexible
            };
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult DriverDuty()
        {
            var model = new DutiesViewModel()
            {
                DutyClass = DutyClassEnum.Driver
            };
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult HolidayLeaderDuty()
        {
            var model = new DutiesViewModel()
            {
                DutyClass = DutyClassEnum.HolidayLeader
            };
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult DutyDetailWriteView(int dutyClass, string keyValue, string month)
        {
            var model = new DutyDetailsViewModel()
            {
                DutyId = keyValue,
                DutyMonth = month.ToDate(),
                DutyClass = dutyClass.ToNullableEnum<DutyClassEnum>(),
                Readonly = false
            };
            return DutyDetailView(model);
        }

        [HttpGet]
        public ActionResult DutyDetailReadView(int dutyClass, string keyValue, string month)
        {
            var model = new DutyDetailsViewModel()
            {
                DutyId = keyValue,
                DutyMonth = month.ToDate(),
                DutyClass = dutyClass.ToNullableEnum<DutyClassEnum>(),
                Readonly = true
            };
            return DutyDetailView(model);
        }

        private ActionResult DutyDetailView(DutyDetailsViewModel model)
        {
            var dutyId = model.DutyId;
            //
            DutiesEntity duty = null;
            if (dutyId.IsNotEmpty())
            {
                duty = dutiesbll.GetEntity(dutyId);
            }

            if (duty == null)
            {
                model.Details = new List<DutyDetailsEntity>();
            }
            else
            {
                model.Details = dutiesbll.GetDutyDetails(dutyId).AsList();
            }

            return PartialView("_Detail", model);
        }

        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form(int? dutyClass, string keyValue)
        {
            var duty = dutiesbll.GetEntity(keyValue);
            if(duty == null)
            {
                duty = new DutiesEntity()
                {
                    DutyClass = dutyClass
                };
            }
            return View(duty);
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
            var data = dutiesbll.GetPageList(pagination, queryJson);
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
            var data = dutiesbll.GetList(queryJson);
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
            var data = dutiesbll.GetEntity(keyValue);
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
            dutiesbll.RemoveForm(keyValue);
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
        public ActionResult SaveForm(string keyValue, DutiesEntity entity)
        {
            dutiesbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }

}