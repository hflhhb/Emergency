using LeaRun.WebBase;
using LeaRun.AuthorizeManage.Entity;
using LeaRun.UserManage.Entity;
using LeaRun.AuthorizeManage.IService;
using LeaRun.Data; 
using LeaRun.Util.Extension;
using LeaRun.Util.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.AuthorizeManage.Service
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 HFL
    /// 创建人：HFL
    /// 日 期：2017.10.14 18:35
    /// 描 述：授权认证(以部门为基础）
    /// </summary>
    public class DeptAuthorizeService<T> : Dao<T>, IAuthorizeService<T> where T : class,new()
    { 
        private AuthorizeService authorizeService = null;

        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public DeptAuthorizeService(DbContextBase dbcontext) : base(dbcontext)
        {
            authorizeService = new AuthorizeService(dbcontext);
        }

        #region 带权限的数据源查询
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IQueryable<T> Queryable()
        {
            if (GetReadDeptId() == "")
            {
                return base.Queryable();
            }
            else
            {
                var condition = CreateDeptExpression();
                return base.Queryable(condition);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public override IQueryable<T> Queryable(Expression<Func<T, bool>> condition)
        {
            if (GetReadDeptId() != "")
            {
                condition = CreateDeptExpression(condition);
            }
            return db.Queryable<T>(condition);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public override IEnumerable<T> FindList(Pagination pagination)
        {
            if (GetReadDeptId() == "")
            {
                return base.FindList(pagination);
            }
            else
            {
                var condition = CreateDeptExpression();
                return base.FindList(condition, pagination);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public override IEnumerable<T> FindList(Expression<Func<T, bool>> condition, Pagination pagination)
        {
            if (GetReadDeptId() != "")
            {
                condition = CreateDeptExpression(condition);
            }
            return base.FindList(condition, pagination);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public override IEnumerable<T> FindList(string strSql)
        {
            strSql = CreateInSql(strSql);
            return base.FindList(strSql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dbParameter"></param>
        /// <returns></returns>
        public override IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter)
        {
            strSql = CreateInSql(strSql);
            return base.FindList(strSql, dbParameter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public override IEnumerable<T> FindList(string strSql, Pagination pagination)
        {
            strSql = CreateInSql(strSql);
            return base.FindList(strSql, pagination);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dbParameter"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public override IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter, Pagination pagination)
        {
            strSql = CreateInSql(strSql);
            return base.FindList(strSql, dbParameter, pagination);
        }
        #endregion

        #region 取数据权限用户

        private Expression<Func<T, bool>> CreateDeptExpression(Expression<Func<T, bool>> condition = null)
        {
            var parameter = Expression.Parameter(typeof(T), "t");
            //
            var subwhere = LinqExtensions.False<T>();

            var userConditon = Expression.Constant(GetCurrentUserId()).Equal(parameter.Property("CreateUserId"));
            subwhere = subwhere.Or(userConditon.ToLambda<Func<T, bool>>(parameter));

            //var authorConditon = Expression.Constant(GetReadDeptId()).Call("Contains", parameter.Property("CreateDeptId"));
            var strType = typeof(string);
            var concat = strType.GetMethod("Concat", new Type[] { strType, strType });
            var authorConditon = Expression.Constant(GetReadDeptId()).Call("Contains", Expression.Call(concat, parameter.Property("CreateDeptId"), Expression.Constant(",")));
            subwhere = subwhere.Or(authorConditon.ToLambda<Func<T, bool>>(parameter));
            if (condition != null)
            {
                condition = condition.And(subwhere);
            }
            else
            {
                condition = subwhere;
            }
            return condition;
        }

        private string CreateInSql(string strSql)
        {
            var deptSql = GetReadDeptSql();
            return strSql + (deptSql == "" ? "" : $"and (CreateUserId = {GetCurrentUserId()} or CreateDeptId in({deptSql})");
        }

        private string GetCurrentUserId()
        {
            return OperatorProvider.Provider.Current().UserId;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetReadDeptSql()
        {
            var deptIds = OperatorProvider.Provider.Current().DataAuthorize.ReadAutorizeDeptIds;

            return deptIds == null ? "" : $"'{deptIds.StringJoin("','")}'";
        }
        private string GetReadDeptId()
        {
            var deptIds = OperatorProvider.Provider.Current().DataAuthorize.ReadAutorizeDeptIds;

            StringBuilder sbDept = new StringBuilder("");
            if (deptIds != null)
            {
                foreach (var item in deptIds)
                {
                    sbDept.Append(item);
                    sbDept.Append(",");
                }
            }
            return sbDept.ToString();
        }

        private List<string> GetReadDeptIdList()
        {
            return OperatorProvider.Provider.Current().DataAuthorize.ReadAutorizeDeptIds;
        }

        #endregion
    }
}
