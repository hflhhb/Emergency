using LeaRun.WorkflowEngine.IService;
using LeaRun.Data;
using LeaRun.WorkflowEngine.Entity;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.Common; 

namespace LeaRun.WorkflowEngine.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.03.04 16:58
    /// 描 述：工作流模板内容表操作（支持：SqlServer）
    /// </summary>
    public class WFSchemeContentService : DaoFactory, WFSchemeContentIService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public WFSchemeContentService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="wfSchemeInfoId">工作流模板信息表主键</param>
        /// <param name="schemeVersion">模板版本号</param>
        /// <returns></returns>
        public WFSchemeContentEntity GetEntity(string wfSchemeInfoId, string schemeVersion)
        {
            try
            {
                var expression = LinqExtensions.True<WFSchemeContentEntity>();
                expression = expression.And(t => t.WFSchemeInfoId == wfSchemeInfoId).And(t => t.SchemeVersion == schemeVersion);
                return  base.db.FindEntity<WFSchemeContentEntity>(expression);
            }
            catch {
                throw;            
            }
        }
        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="wfSchemeInfoId">工作流模板信息表Id</param>
        /// <returns></returns>
        public IEnumerable<WFSchemeContentEntity> GetEntityList(string wfSchemeInfoId)
        {
            var expression = LinqExtensions.True<WFSchemeContentEntity>();
            expression = expression.And(t => t.WFSchemeInfoId == wfSchemeInfoId);
            return base.db.FindList<WFSchemeContentEntity>(expression);
        }
        /// <summary>
        /// 获取对象列表（不包括模板内容）
        /// </summary>
        /// <param name="wfSchemeInfoId">工作流模板信息表Id</param>
        /// <returns></returns>
        public DataTable GetTableList(string wfSchemeInfoId)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT
	                            w.Id,
                                w.WFSchemeInfoId,
                                w.SchemeVersion,
	                            w.CreateDate,
	                            w.CreateUserId,
	                            w.CreateUserName
                            FROM
	                            WF_SchemeContent w
                            where w.WFSchemeInfoId = @wfSchemeInfoId
                            Order by  w.SchemeVersion DESC ");

                var parameter = new List<DbParameter>();

                parameter.Add(DbParameters.CreateDbParameter("@wfSchemeInfoId", wfSchemeInfoId));
                return base.db.FindTable(strSql.ToString(), parameter.ToArray());
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存对象
        /// </summary>
        /// <param name="entity">类</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public int SaveEntity(WFSchemeContentEntity entity, string keyValue)
        {
            try
            {
                if (string.IsNullOrEmpty(keyValue))
                {
                    entity.Create();
                    return base.db.Insert<WFSchemeContentEntity>(entity);
                }
                else
                {
                    entity.Modify(keyValue);
                    return base.db.Update<WFSchemeContentEntity>(entity);
                }
            }
            catch {
                throw;
            }
        }
        #endregion
    }
}
