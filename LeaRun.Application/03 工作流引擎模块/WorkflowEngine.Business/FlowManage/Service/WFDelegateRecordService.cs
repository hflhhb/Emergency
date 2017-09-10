using LeaRun.WorkflowEngine.Entity;
using LeaRun.WorkflowEngine.IService;
using LeaRun.Data; 
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace LeaRun.WorkflowEngine.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.01.14 11:02
    /// 描 述：工作流委托记录操作类（支持：SqlServer）
    /// </summary>
    public class WFDelegateRecordService : DaoFactory, WFDelegateRecordIService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public WFDelegateRecordService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 获取分页数据(type 1：委托记录，其他：被委托记录)
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <param name="type"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetPageList(Pagination pagination, string queryJson,int type, string userId = null)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT
	                                w.Id,
	                                w.WFDelegateRuleId,
	                                w.FromUserId,
	                                w.FromUserName,
	                                w.ToUserId,
	                                w.ToUserName,
	                                w.CreateDate,
	                                w.ProcessId,
	                                w.ProcessCode,
	                                w.ProcessName
                                FROM
	                                WF_DelegateRecord w
                                Where 1=1 
                               ");
                var parameter = new List<DbParameter>();
                var queryParam = queryJson.ToJObject();
                if (!string.IsNullOrEmpty(userId))
                {
                    if (type == 1)
                    {
                        strSql.Append(@" AND ( w.FromUserId = @UserId )");
                    }
                    else
                    {
                        strSql.Append(@" AND ( w.ToUserId = @UserId )");
                    }
                    parameter.Add(DbParameters.CreateDbParameter("@UserId", userId));
                }
                if (!queryParam["Keyword"].IsEmpty())//关键字查询
                {
                    string keyord = queryParam["Keyword"].ToString();
                    strSql.Append(@" AND ( w.ToUserName LIKE @keyword  or w.ProcessName LIKE @keyword or w.ProcessCode  LIKE @keyword  )");
                    parameter.Add(DbParameters.CreateDbParameter("@keyword", '%' + keyord + '%'));
                }
                return base.db.FindTable(strSql.ToString(), parameter.ToArray(), pagination);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存实体数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(string keyValue, WFDelegateRecordEntity entity)
        {
            try
            {
                int num;
                if (string.IsNullOrEmpty(keyValue))
                {
                    entity.Create();
                    num = base.db.Insert(entity);
                }
                else
                {
                    entity.Modify(keyValue);
                    num = base.db.Update(entity);
                }
                return num;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
