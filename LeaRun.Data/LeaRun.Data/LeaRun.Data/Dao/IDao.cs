using LeaRun.Util.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace LeaRun.Data
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.10.10
    /// 描 述：定义仓储模型中的数据标准操作接口
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    public interface IDao<TEntity> where TEntity : class,new()
    {
        int ExecuteNonQuery(string strSql);
        int ExecuteNonQuery(string strSql, params DbParameter[] dbParameter);
        int ExecuteProc(string procName);
        int ExecuteProc(string procName, params DbParameter[] dbParameter);

        int Insert(TEntity entity, bool submitImmediately);
        int Insert(List<TEntity> entity, bool submitImmediately);

        int Insert<T>(T entity, bool submitImmediately) where T : class;

        //int Delete();
        int Delete(TEntity entity, bool submitImmediately); 
        int Delete<T>(T entity, bool submitImmediately) where T : class;
        int Delete(List<TEntity> entity, bool submitImmediately); 
        int Delete(Expression<Func<TEntity, bool>> condition, bool submitImmediately); 
        int Delete<T>(Expression<Func<T, bool>> predicate, bool submitImmediately) where T : class,new();

        int Delete(object keyValue);
        int Delete(object[] keyValue);
        int Delete(object propertyValue, string propertyName);
        int Update(TEntity entity, bool submitImmediately);
        int Update<T>(T entity, bool submitImmediately) where T : class;
        int Update(List<TEntity> entity, bool submitImmediately);
        int Update(Expression<Func<TEntity, bool>> condition, bool submitImmediately);

        TEntity FindEntity(object keyValue);
        TEntity FindEntity(Expression<Func<TEntity, bool>> condition);
        IQueryable<TEntity> Queryable();
        IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> condition);
        IEnumerable<TEntity> FindList(string strSql);
        IEnumerable<TEntity> FindList(string strSql, DbParameter[] dbParameter);
        IEnumerable<TEntity> FindList(Pagination pagination);
        IEnumerable<TEntity> FindList(Expression<Func<TEntity, bool>> condition, Pagination pagination);
        IEnumerable<TEntity> FindList(string strSql, Pagination pagination);
        IEnumerable<TEntity> FindList(string strSql, DbParameter[] dbParameter, Pagination pagination);

        DataTable FindTable(string strSql);
        DataTable FindTable(string strSql, DbParameter[] dbParameter);
        DataTable FindTable(string strSql, Pagination pagination);
        DataTable FindTable(string strSql, DbParameter[] dbParameter, Pagination pagination);
        object FindObject(string strSql);
        object FindObject(string strSql, DbParameter[] dbParameter);
    }
}
