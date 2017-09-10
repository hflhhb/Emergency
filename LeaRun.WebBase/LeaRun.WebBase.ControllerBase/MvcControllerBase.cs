using LeaRun.WebBase;
using LeaRun.Util;
using LeaRun.Util.Log;
using LeaRun.Util.Web;
using System;
using System.Web.Mvc;

namespace LeaRun.WebBase
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.9 10:45
    /// 描 述：控制器基类
    /// </summary>
    [HandlerLogin(LoginMode.Enforce)]
    public abstract class MvcControllerBase : Controller
    {
        private Log _logger;
        /// <summary>
        /// 日志操作
        /// </summary>
        public Log Logger
        {
            get { return _logger ?? (_logger = LogFactory.GetLogger(this.GetType().ToString())); }
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult ToJsonResult(object data)
        {
            return Content(data.ToJson());
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message)
        {
            return Content(new AjaxResult { type = ResultType.success, message = message }.ToJson());
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message, object data)
        {
            return Content(new AjaxResult { type = ResultType.success, message = message, resultdata = data }.ToJson());
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Error(string message)
        {
            return Content(new AjaxResult { type = ResultType.error, message = message }.ToJson());
        }

        /// <summary>
        /// 通用错误处理
        /// </summary>
        /// <param name="action"></param>
        /// <param name="successMsg"></param>
        /// <returns></returns>
        public JsonResult Try(Action action,string successMsg="Ok")
        {
            try
            {
                action();

                return Json(new AjaxResult { type = ResultType.success, message = successMsg });                
            }
            catch (ApplicationException ex)
            {
                return Json(new AjaxResult { type = ResultType.error, message = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new AjaxResult { type = ResultType.error, message = ex.Message });
            }   
        }

        /// <summary>
        /// 通用错误处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="successMsg"></param>
        /// <returns></returns>
        public JsonResult Try<T>(Func<T> action, string successMsg = "Ok")
        {
            try
            {
                action();
                return Json(new AjaxResult { type = ResultType.success, message = successMsg });
            }
            catch (ApplicationException ex)
            { 
                return Json(new AjaxResult { type = ResultType.error, message = ex.Message }); 
            }
            catch (Exception ex)
            {
                return Json(new AjaxResult { type = ResultType.error, message = ex.Message }); 
            }
        }

        /// <summary>
        /// 通用错误处理
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public ActionResult TryView(Func<ActionResult> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                if (ex is ApplicationException)
                {
                    return this.Error(ex.Message);
                }else
                {
                    return this.Error(ex.Message);
                } 
            }
        }
    }
}
