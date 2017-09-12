using LeaRun.CustomerManage.Business;
using LeaRun.CustomerManage.Entity;
using LeaRun.Util.Extension;
using LeaRun.WebBase;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LeaRun.CustomerManage.Controllers
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创 建：westinfeng
    /// 日 期：2016-03-32 16:51
    /// 描 述：跟进记录
    /// </summary>
    public class TrailRecordController : MvcControllerBase
    {
        private TrailRecordBLL chancetrailbll = new TrailRecordBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="objectId">Id</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string objectId)
        {
            var data = chancetrailbll.GetList(objectId);
            Dictionary<string, string> dictionaryDate = new Dictionary<string, string>();
            foreach (TrailRecordEntity item in data)
            {
                string key = item.CreateDate.ToDate().ToString("yyyy-MM-dd");
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd");
                if (item.CreateDate.ToDate().ToString("yyyy-MM-dd") == currentTime)
                {
                    key = "今天";
                }
                if (!dictionaryDate.ContainsKey(key))
                {
                    dictionaryDate.Add(key, item.CreateDate.ToDate().ToString("yyyy-MM-dd"));
                }
            }
            var jsonData = new
            {
                timeline = dictionaryDate,
                rows = data,
            };
            return ToJsonResult(jsonData);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, TrailRecordEntity entity)
        {
            chancetrailbll.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }
}
