using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using LeaRun.Util.Web; 

namespace LeaRun.Data
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.10.10
    /// 描 述：定义仓储模型中的数据标准操作
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    public class Dao<TEntity> : IDao<TEntity> where TEntity : class,new()
    {
        public DbContextBase db = null;
        /// <summary>
        /// 带UnitOfWork工作单元参数的构造函数
        /// </summary>
        /// <param name="dbcontext">数据库上下文</param>
        public Dao(DbContextBase dbcontext)
        {
            this.db = dbcontext;
        }

        #region 执行 SQL 语句
        public virtual int ExecuteNonQuery(string strSql)
        {
            return db.ExecuteNonQuery(strSql);
        }
        public virtual int ExecuteNonQuery(string strSql, params DbParameter[] dbParameter)
        {
            return db.ExecuteNonQuery(strSql, dbParameter);
        }
        public virtual int ExecuteProc(string procName)
        {
            return db.ExecuteProc(procName);
        }
        public virtual int ExecuteProc(string procName, params DbParameter[] dbParameter)
        {
            return db.ExecuteProc(procName, dbParameter);
        }
        #endregion

        #region 对象实体 添加、修改、删除
        public virtual int Insert(TEntity entity, bool submitImmediately = true)
        {
            return db.Insert<TEntity>(entity, submitImmediately);
        }

        public virtual int Insert<T>(T entity, bool submitImmediately = true) where T : class
        {
            return db.Insert<T>(entity, submitImmediately); 
        }
        public virtual int Insert(List<TEntity> entity, bool submitImmediately = true)
        {
            return db.Insert<TEntity>(entity, submitImmediately);
        }
        //public virtual int Delete()
        //{
        //    return db.Delete<T>();
        //}
        public virtual int Delete(TEntity entity, bool submitImmediately = true)
        {
            return db.Delete<TEntity>(entity, submitImmediately);
        }
        public virtual int Delete<T>(T entity, bool submitImmediately) where T : class
        {
            return db.Delete<T>(entity);
        }
        public virtual int Delete(List<TEntity> entity, bool submitImmediately = true)
        {
            return db.Delete<TEntity>(entity, submitImmediately);
        }
        public virtual int Delete(Expression<Func<TEntity, bool>> condition, bool submitImmediately = true)
        {
            return db.Delete<TEntity>(condition, submitImmediately);
        }
        public virtual int Delete<T>(Expression<Func<T, bool>> predicate, bool submitImmediately) where T : class,new()
        {
            return db.Delete<T>(predicate, submitImmediately);
        }

        public virtual int Delete(object keyValue)
        {
            return db.Delete<TEntity>(keyValue);
        }
        public virtual int Delete(object[] keyValue)
        {
            return db.Delete<TEntity>(keyValue);
        }
        public virtual int Delete(object propertyValue, string propertyName)
        {
            return db.Delete<TEntity>(propertyValue, propertyName);
        }
        public virtual int Update(TEntity entity, bool submitImmediately = true)
        {
            return db.Update<TEntity>(entity, submitImmediately);
        }
        public virtual int Update<T>(T entity, bool submitImmediately) where T : class
        {
            return db.Update<T>(entity, submitImmediately);
        }
        public virtual int Update(List<TEntity> entity, bool submitImmediately = true)
        {
            return db.Update<TEntity>(entity, submitImmediately);
        }
        public virtual int Update(Expression<Func<TEntity, bool>> condition, bool submitImmediately = true)
        {
            return db.Update<TEntity>(condition, submitImmediately);
        }
        #endregion

        #region 对象实体 查询
        public virtual TEntity FindEntity(object keyValue)
        {
            return db.FindEntity<TEntity>(keyValue);
        }
        public virtual TEntity FindEntity(Expression<Func<TEntity, bool>> condition)
        {
            return db.FindEntity<TEntity>(condition);
        }
        public virtual IQueryable<TEntity> Queryable()
        {
            return db.Queryable<TEntity>();
        }
        public virtual IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> condition)
        {
            return db.Queryable<TEntity>(condition);
        }
        public virtual IEnumerable<TEntity> FindList(string strSql)
        {
            return db.FindList<TEntity>(strSql);
        }
        public virtual IEnumerable<TEntity> FindList(string strSql, DbParameter[] dbParameter)
        {
            return db.FindList<TEntity>(strSql, dbParameter);
        }
        public virtual IEnumerable<TEntity> FindList(Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindList<TEntity>(pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public virtual IEnumerable<TEntity> FindList(Expression<Func<TEntity, bool>> condition, Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindList<TEntity>(condition, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public virtual IEnumerable<TEntity> FindList(string strSql, Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindList<TEntity>(strSql, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public virtual IEnumerable<TEntity> FindList(string strSql, DbParameter[] dbParameter, Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindList<TEntity>(strSql, dbParameter, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        #endregion

        #region 数据源 查询
        public virtual DataTable FindTable(string strSql)
        {
            return db.FindTable(strSql);
        }
        public virtual DataTable FindTable(string strSql, DbParameter[] dbParameter)
        {
            return db.FindTable(strSql, dbParameter);
        }
        public virtual DataTable FindTable(string strSql, Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindTable(strSql, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public virtual DataTable FindTable(string strSql, DbParameter[] dbParameter, Pagination pagination)
        {
            int total = pagination.records;
            var data = db.FindTable(strSql, dbParameter, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public virtual object FindObject(string strSql)
        {
            return db.FindObject(strSql);
        }
        public virtual object FindObject(string strSql, DbParameter[] dbParameter)
        {
            return db.FindObject(strSql, dbParameter);
        }
        #endregion
    }
}
