using LeaRun.WorkflowEngine.Entity;
using LeaRun.WorkflowEngine.IService;
using LeaRun.Data; 
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.Web;
using System;
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
    /// 描 述：表单管理（支持：SqlServer）
    /// </summary>
    public class WFFrmMainService : DaoFactory, WFFrmMainIService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public WFFrmMainService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 获取表单列表分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        public DataTable GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT
	                            w.FrmMainId,
	                            w.FrmCode,
	                            w.FrmName,
	                            w.FrmType,
	                            t2.ItemName AS FrmTypeName,
	                            w.FrmDbId,
	                            t1.DBName,
	                            w.FrmTable,
                                w.FrmTableId,
                                w.isSystemTable,
	                            w.FrmContent,
	                            w.SortCode,
	                            w.DeleteMark,
	                            w.EnabledMark,
	                            w.Description,
	                            w.CreateDate,
	                            w.CreateUserId,
	                            w.CreateUserName,
	                            w.ModifyDate,
	                            w.ModifyUserId,
	                            w.ModifyUserName
                            FROM
	                            WF_FrmMain w
                            LEFT JOIN 
	                            Base_DatabaseLink t1 ON t1.DatabaseLinkId = w.FrmDbId
                            LEFT JOIN 
	                            Base_DataItemDetail t2 ON t2.ItemDetailId = w.FrmType
                            WHERE w.DeleteMark = 0 ");
                var parameter = new List<DbParameter>();
                var queryParam = queryJson.ToJObject();
                //数据库Id查询
                if (!queryParam["FrmType"].IsEmpty())
                {
                    strSql.Append(" AND w.FrmType = @FrmType ");
                    parameter.Add(DbParameters.CreateDbParameter("@FrmType", queryParam["FrmType"].ToString()));
                }
                else if (!queryParam["Keyword"].IsEmpty())//关键字查询
                {
                    string keyord = queryParam["Keyword"].ToString();
                    strSql.Append(@" AND ( w.FrmCode LIKE @keyword 
                                        or w.FrmName LIKE @keyword 
                                        or w.Description LIKE @keyword 
                    )");
                    
                    parameter.Add(DbParameters.CreateDbParameter("@keyword", '%' + keyord + '%'));
                }
                return base.db.FindTable(strSql.ToString(), parameter.ToArray(), pagination);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 获取表单数据ALL(用于下拉框)
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT
	                            w.FrmMainId,
	                            w.FrmName,
	                            w.FrmType,
							    t2.ItemName AS FrmTypeName
                            FROM
	                            WF_FrmMain w
						    LEFT JOIN 
                                Base_DataItemDetail t2 ON t2.ItemDetailId = w.FrmType
                            WHERE w.DeleteMark = 0 and w.EnabledMark = 1 order by w.FrmType");
                var parameter = new List<DbParameter>();
                return base.db.FindTable(strSql.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 设置表单
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public WFFrmMainEntity GetForm(string keyValue)
        {
            try
            {
                return base.db.FindEntity<WFFrmMainEntity>(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除表单
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                WFFrmMainEntity entity = new WFFrmMainEntity();
                entity.Modify(keyValue);
                entity.DeleteMark = 1;
                base.db.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存表单
        /// </summary>
        /// <param name="entity">表单模板实体类</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public int SaveForm(string keyValue,WFFrmMainEntity entity)
        {
            try
            {
                if (string.IsNullOrEmpty(keyValue))
                {
                    entity.Create();
                    base.db.Insert(entity);
                }
                else
                {
                    entity.Modify(keyValue);
                    base.db.Update(entity);
                }
                return 1;
            }
            catch(Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 更新表单模板状态（启用，停用）
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="status">状态 1:启用;0.停用</param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                WFFrmMainEntity entity = new WFFrmMainEntity();
                entity.Modify(keyValue);
                entity.EnabledMark = state;
                base.db.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
