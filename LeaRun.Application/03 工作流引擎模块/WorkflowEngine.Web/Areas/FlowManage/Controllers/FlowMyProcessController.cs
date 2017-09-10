using LeaRun.WebBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.FlowManage.Controllers
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.03.19 13:57
    /// 描 述:我的流程
    /// </summary>
    public class FlowMyProcessController : MvcControllerBase
    {
        #region 视图功能
        //
        // GET: /FlowManage/FlowMyProcess/
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 进度查看
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProcessLookForm()
        {
            return View();
        }
        /// <summary>
        /// 进程再次提交
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProcessAgainNewForm()
        {
            return View();
        }
        #endregion
    }
}
