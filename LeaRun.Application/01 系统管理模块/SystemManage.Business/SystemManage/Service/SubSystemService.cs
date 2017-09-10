using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Data;
using LeaRun.SystemManage.Entity;
using LeaRun.Util;
using System.Data.Entity;

namespace LeaRun.SystemManage.Service
{
    public class SubSystemService : Dao<APP_Application>, ISubSystemService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public SubSystemService(DbContextBase dbcontext) : base(dbcontext){ }

        public System.Data.DataTable GetPageDataTable(string strSql,string orderField, bool isAsc,int pageSize,int pageIndex, out int totalRecord)
        {
            using (var db =  DbFactory.Base())
            {
                return db.FindTable(strSql, orderField, isAsc, pageSize, pageIndex, out totalRecord); 
            } 
        }

        public APP_Application GetById(string app_Id)
        {  
            int iId =StringUtil.getInt(app_Id);
            using (var db = DbFactory.Base())
            {
                var app = db.Queryable<APP_Application>().FirstOrDefault(x => x.app_Id == iId);
                //var app = db.Apps.FirstOrDefault(x => x.app_Id  == iId);
                //var app = db.Set<APP_Application>().FirstOrDefault(x => x.app_Id == iId);
                if (app == null)
                {
                    throw new ApplicationException("该子系统ID不存在：" + app_Id);
                }
                return app;
            } 
        }

        public bool DeleteById(string app_Id)
        {
            int iId = StringUtil.getInt(app_Id);
            using (var db = DbFactory.Base())
            {
                var app = db.Set<APP_Application>().FirstOrDefault(x => x.app_Id == iId);
                if (app == null)
                {
                    throw new ApplicationException("该子系统ID不存在：" + app_Id);
                }
                db.Set<APP_Application>().Remove(app); 
            }
            return true;
        }
    }
}
