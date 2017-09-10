using System; 
using System.Data; 
using System.Web.Mvc; 
using LeaRun.Util;  
using LeaRun.SystemManage.Entity;
using LeaRun.SystemManage.Service; 
using LeaRun.WebBase;

namespace LeaRun.SystemManage.Controllers
{
    /// <summary>
    /// 子系统(一级菜单) MVC控制器
    /// </summary>
    public class SubSystemController : MvcControllerBase
    {
        protected BjuiResponse BjuiResponse = new BjuiResponse();
   
        /// <summary>
        /// 显示子系统主页面 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 列表区域
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {

            string strOrderBy = " app_Id  ";
            int iRowCount = 0;

            PageInfo pager = new PageInfo();
            pager.PageSize = Convert.ToInt32(Request.Params["pageSize"]);
            pager.PageIndex = Convert.ToInt32(Request.Params["PageIndex"]);
            if (pager.PageSize == 0)
                pager.PageSize = 10;
            if (pager.PageIndex == 0)
                pager.PageIndex = 1;
            string sql = GetQuerySQL();

            DataTable dtMenu = null;
            ISubSystemService service = new SubSystemService(LeaRun.Data.DbFactory.Base());
            dtMenu = service.GetPageDataTable(sql,strOrderBy,true, pager.PageSize, pager.PageIndex, out iRowCount);
            pager.RowCount = iRowCount;

            if (iRowCount % pager.PageSize == 0)
            {
                pager.PageCount = iRowCount / pager.PageSize;
            }
            else
            {
                pager.PageCount = (iRowCount / pager.PageSize) + 1;
            }

            ViewBag.Pager = pager;
             
            return View(dtMenu); 
        }


        /// <summary>
        /// 拼写查询SQL
        /// </summary>
        /// <returns></returns>
        private string GetQuerySQL()
        {
            string strWhere = " 1=1 ";
            string strKeyWord = StringUtil.cEmpty(Request["KeyWord"]);
            if (strKeyWord.Length > 0)
            {
                strWhere += string.Format(" and ( app.app_Name='{0}' Or app.app_Code='{0}') ", strKeyWord);
            }

            string str_app_Code = StringUtil.cEmpty(Request["app_Code"]);
            if (str_app_Code.Length > 0)
            {
                strWhere += string.Format(" and app.app_Code like'%{0}%'  ", str_app_Code);
            }

            string str_app_Name = StringUtil.cEmpty(Request["app_Name"]);
            if (str_app_Name.Length > 0)
            {
                strWhere += string.Format(" and app.app_Name like'%{0}%'  ", str_app_Name);
            }

            string str_app_App = StringUtil.cEmpty(Request["app_App"]);
            if (str_app_App.Length > 0)
            {
                strWhere += string.Format(" and app.app_App like'%{0}%'  ", str_app_App);
            }

            string str_app_Type = StringUtil.cEmpty(Request["app_Type"]);
            if (str_app_Type.Length > 0)
            {
                strWhere += string.Format(" and app.app_Type ='{0}'  ", str_app_Type);
            }

            string str_app_Url = StringUtil.cEmpty(Request["app_Url"]);
            if (str_app_Url.Length > 0)
            {
                strWhere += string.Format(" and app.app_Url like '%{0}%'  ", str_app_Url);
            }

            string str_app_Icon = StringUtil.cEmpty(Request["app_Icon"]);
            if (str_app_Icon.Length > 0)
            {
                strWhere += string.Format(" and app.app_Icon like '%{0}%'  ", str_app_Icon);
            }


            string strSQL = "SELECT  * From APP_Application  app   \n";
            if (strWhere.Length > 5)
            {
                strSQL += " Where " + strWhere;
            }
            return strSQL;
        }

        //#region 导出Excel
        ///// <summary>
        ///// 导出Excel
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult Export()
        //{
        //    try
        //    {
        //        System.Data.DataTable dtTable = null;
        //        using (IDbConnection db = Database.GetConnection(AppConstant.AppPlatformDB))
        //        {
        //            string sql = GetQuerySQL();
        //            dtTable = db.GetDataTable(sql);
        //        }
        //        if (dtTable != null)
        //        {
        //            string strSheetTitle = "子系统(顶部导航菜单)";

        //            ExportColumn[] arrColumn = new ExportColumn[] {  
        //                    new ExportColumn("app_Code","子系统代码"),
        //                    new ExportColumn("app_Name","子系统名称"),
        //                    new ExportColumn("app_Type","类型"),
        //                    new ExportColumn("app_App","所属应用"),
        //                    new ExportColumn("app_Url","子系统URL") ,
        //                    new ExportColumn("app_Icon","子系统图标") , 
        //                    new ExportColumn("app_IP","子系统IP和端口") , 
        //                    new ExportColumn("app_Rank","顺序号") 
        //            };
        //            string strShowFileName = ExcelUtils.dataTable2Excel(dtTable, arrColumn, strSheetTitle, null);
        //            string strSaveFilePath = System.Configuration.ConfigurationManager.AppSettings["ReportSavePath"];
        //            //以字符流的形式下载文件                         
        //            var fs = new FileStream(strSaveFilePath + strShowFileName, FileMode.Open);
        //            var bytes = new byte[(int)fs.Length];
        //            fs.Read(bytes, 0, bytes.Length);
        //            fs.Close();

        //            Response.ContentType = "application/vnd.ms-excel";
        //            //通知浏览器下载文件而不是打开
        //            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(strShowFileName, Encoding.UTF8));
        //            Response.BinaryWrite(bytes);
        //            Response.Flush();
        //            Response.End();
        //        }
        //        return new EmptyResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion


        /// <summary>
        /// 添加代码区域
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        { 
            return View();
        }

        ///// <summary>
        ///// 添加代码
        ///// </summary>
        ///// <param name="form"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public JsonResult Add(FormatException form)
        //{
        //    try
        //    {
        //        APP_Application app = new APP_Application(); 
        //        app.app_Code = Request.Params["app_Code"];
        //        app.app_Name = Request.Params["app_Name"];
        //        app.app_Type = Request.Params["app_Type"];
        //        app.app_App = Request.Params["app_App"];
        //        app.app_Icon = Request.Params["app_Icon"];
        //        app.app_Url = Request.Params["app_Url"];
        //        app.app_IP = Request.Params["app_IP"]; 
        //        app.app_Rank = Convert.ToInt32(Request.Params["app_Rank"]);

        //        using (IDbConnection db = Database.GetConnection(AppConstant.AppPlatformDB))
        //        {
        //            db.Insert(app);
        //        } 
        //        BjuiResponse.message = "新增成功！";
        //        BjuiResponse.closeCurrent = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        BjuiResponse.statusCode = "300";
        //        BjuiResponse.message = ex.Message;
        //    }

        //    return Json(BjuiResponse);
        //}


        /// <summary>
        /// 编辑代码区域
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            string app_Id = ID.ToString();
            return base.TryView(() =>
            {
                ISubSystemService service = new SubSystemService(LeaRun.Data.DbFactory.Base());
                //var service = Ioc.Get<ISubSystemService>(); 
                APP_Application act = service.GetById(app_Id);
                return View("Edit", act);
            }); 
        }

        ///// <summary>
        ///// 修改代码
        ///// </summary>
        ///// <param name="form"></param>
        ///// <returns></returns> 
        //[HttpPost]
        //public JsonResult Edit(FormatException form)
        //{
        //    try
        //    {
        //        APP_Application app = new APP_Application();
        //        app.app_Id = Convert.ToInt32(Request.Params["hid_app_Id"]);
        //        using (IDbConnection db = Database.GetConnection(AppConstant.AppPlatformDB))
        //        {
        //            app = db.GetSingle<APP_Application>("select top 1  * from APP_Application where app_Id='" + app.app_Id + "'");

        //            app.app_Code = Request.Params["app_Code"];
        //            app.app_Name = Request.Params["app_Name"];
        //            app.app_Type = Request.Params["app_Type"];
        //            app.app_App = Request.Params["app_App"];
        //            app.app_Icon = Request.Params["app_Icon"];
        //            app.app_Url = Request.Params["app_Url"];
        //            app.app_IP = Request.Params["app_IP"];
        //            app.app_Rank = Convert.ToInt32(Request.Params["app_Rank"]);

        //            int res = db.Update<APP_Application>(app);

        //            BjuiResponse.message = "更新成功！";
        //            BjuiResponse.closeCurrent = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        BjuiResponse.statusCode = "300";
        //        BjuiResponse.message = ex.Message;
        //    }

        //    return Json(BjuiResponse);
        //}


        /// <summary>
        /// 删除对象
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        public JsonResult Delete()
        {
            string app_Id = Convert.ToInt32(Request.Params["ID"]).ToString();
            return base.Try(() =>
            {
                ISubSystemService service = new SubSystemService(LeaRun.Data.DbFactory.Base());
                //var service = Ioc.Get<ISubSystemService>(); 
                service.DeleteById(app_Id); 
            }, "删除成功！");
        }
          
    }
}