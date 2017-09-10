using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Core.Metadata.Edm;
using System.Text.RegularExpressions;
using LeaRun.Util.Extension;
using LeaRun.Util;
using LeaRun.Util.Web;

namespace LeaRun.Data
{

    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.10.10
    /// 描 述：操作数据库
    /// </summary>
    public static class DbContextBaseExtension
    { 
  
        #region 执行 SQL 语句
        public static int ExecuteNonQuery(this DbContextBase dbcontext,string strSql)
        { 
            return dbcontext.Database.ExecuteSqlCommand(strSql);  
        }
        public static int ExecuteNonQuery(this DbContextBase dbcontext,string strSql, params DbParameter[] dbParameter)
        {
            return dbcontext.Database.ExecuteSqlCommand(strSql, dbParameter); 
        }
        public static int ExecuteProc(this DbContextBase dbcontext, string procName)
        {
            return dbcontext.Database.ExecuteSqlCommand(DatabaseCommon.BuilderProc(procName));
        }
        public static int ExecuteProc(this DbContextBase dbcontext, string procName, params DbParameter[] dbParameter)
        {
            return dbcontext.Database.ExecuteSqlCommand(DatabaseCommon.BuilderProc(procName, dbParameter), dbParameter);
        }

        public static string ExecuteScalar(this DbContextBase dbcontext, string strSql, params DbParameter[] dbParameter)
        {
            var dbConnection = dbcontext.Database.Connection;
            object objValue = new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, strSql, dbParameter);
             
            if (objValue !=null )
            {
                return StringUtil.cEmpty(objValue);
            } 
            return string.Empty;
        }
        #endregion

        #region 对象实体 添加、修改、删除
        public static int Insert<T>(this DbContextBase dbcontext, T entity , bool submitImmediately=true) where T : class
        {
            if (entity is IList)
            {
                IList  entities = (IList)entity ;
                foreach (var bean in entities)
                {
                    dbcontext.Entry(bean).State = EntityState.Added;
                }
            }
            else
            { 
                dbcontext.Entry<T>(entity).State = EntityState.Added;
            }
            return (submitImmediately ? dbcontext.SaveChanges() : 0);
        }
        public static int Insert<T>(this DbContextBase dbcontext, IEnumerable<T> entities, bool submitImmediately = true) where T : class
        {
            foreach (var entity in entities)
            {
                dbcontext.Entry<T>(entity).State = EntityState.Added;
            }
            return (submitImmediately ? dbcontext.SaveChanges() : 0);
        }
        public static int Delete<T>(this DbContextBase dbcontext ) where T : class
        {
            EntitySet entitySet = DatabaseCommon.GetEntitySet<T>(dbcontext);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                return DbContextBaseExtension.ExecuteNonQuery(dbcontext, DatabaseCommon.DeleteSql(tableName).ToString());
            }
            return -1;
        }
        public static int Delete<T>(this DbContextBase dbcontext, T entity, bool submitImmediately = true) where T : class
        {
            dbcontext.Set<T>().Attach(entity);
            dbcontext.Set<T>().Remove(entity);
            return (submitImmediately ? dbcontext.SaveChanges() : 0);
        }
        public static int Delete<T>(this DbContextBase dbcontext, IEnumerable<T> entities, bool submitImmediately = true) where T : class
        {
            foreach (var entity in entities)
            {
                dbcontext.Set<T>().Attach(entity);
                dbcontext.Set<T>().Remove(entity);
            }
            return (submitImmediately ? dbcontext.SaveChanges() : 0);
        }
        public static int Delete<T>(this DbContextBase dbcontext, Expression<Func<T, bool>> condition, bool submitImmediately = true) where T : class,new()
        {
            IEnumerable<T> entities = dbcontext.Set<T>().Where(condition).ToList();
            return DbContextBaseExtension.Delete(dbcontext, entities, submitImmediately);
        }
        public static int Delete<T>(this DbContextBase dbcontext, object keyValue) where T : class
        {
            EntitySet entitySet = DatabaseCommon.GetEntitySet<T>(dbcontext);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                string keyFlied = entitySet.ElementType.KeyMembers[0].Name;
                return DbContextBaseExtension.ExecuteNonQuery(dbcontext, DatabaseCommon.DeleteSql(tableName, keyFlied, keyValue));
            }
            return -1;
        }
        public static int Delete<T>(this DbContextBase dbcontext, object[] keyValue) where T : class
        {
            EntitySet entitySet = DatabaseCommon.GetEntitySet<T>(dbcontext);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                string keyFlied = entitySet.ElementType.KeyMembers[0].Name;
                return DbContextBaseExtension.ExecuteNonQuery(dbcontext, DatabaseCommon.DeleteSql(tableName, keyFlied, keyValue));
            }
            return -1;
        }
        public static int Delete<T>(this DbContextBase dbcontext, object propertyValue, string propertyName) where T : class
        {
            EntitySet entitySet = DatabaseCommon.GetEntitySet<T>(dbcontext);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                return DbContextBaseExtension.ExecuteNonQuery(dbcontext, DatabaseCommon.DeleteSql(tableName, propertyName, propertyValue));
            }
            return -1;
        }
        public static int Update<T>(this DbContextBase dbcontext, T entity, bool submitImmediately = true) where T : class
        {
            dbcontext.Set<T>().Attach(entity);
            Hashtable props = ConvertExtension.GetPropertyInfo<T>(entity);
            foreach (string item in props.Keys)
            {
                object value = dbcontext.Entry(entity).Property(item).CurrentValue;
                if (value != null)
                {
                    if (value.ToString() == "&nbsp;")
                        dbcontext.Entry(entity).Property(item).CurrentValue = null;
                    dbcontext.Entry(entity).Property(item).IsModified = true;
                }
            }
            return (submitImmediately ? dbcontext.SaveChanges() : 0);
        }
        public static int Update<T>(this DbContextBase dbcontext, IEnumerable<T> entities, bool submitImmediately = true) where T : class
        {
            foreach (var entity in entities)
            {
                DbContextBaseExtension.Update(dbcontext, entity);
            }
            return (submitImmediately ? dbcontext.SaveChanges() : 0);
        }
        public static int Update<T>(this DbContextBase dbcontext, Expression<Func<T, bool>> condition, bool submitImmediately = true) where T : class,new()
        {
            IEnumerable<T> entities = dbcontext.Set<T>().Where(condition).ToList();
            return DbContextBaseExtension.Update(dbcontext, entities, submitImmediately);
        }
        #endregion

        #region 对象实体 查询
        public static T FindEntity<T>(this DbContextBase dbcontext, object keyValue) where T : class
        {
            return dbcontext.Set<T>().Find(keyValue);
        }
        public static T FindEntity<T>(this DbContextBase dbcontext, Expression<Func<T, bool>> condition) where T : class,new()
        {
            return dbcontext.Set<T>().Where(condition).FirstOrDefault();
        }
        public static IQueryable<T> Queryable<T>(this DbContextBase dbcontext) where T : class,new()
        {
            return dbcontext.Set<T>();
        }
        public static IQueryable<T> Queryable<T>(this DbContextBase dbcontext, Expression<Func<T, bool>> condition) where T : class,new()
        {
            return dbcontext.Set<T>().Where(condition);
        }
        public static IEnumerable<T> FindList<T>(this DbContextBase dbcontext) where T : class,new()
        {
            return dbcontext.Set<T>().ToList();
        }
        public static IEnumerable<T> FindList<T>(this DbContextBase dbcontext, Func<T, object> keySelector) where T : class,new()
        {
            return dbcontext.Set<T>().OrderBy(keySelector).ToList();
        }
        public static IEnumerable<T> FindList<T>(this DbContextBase dbcontext, Expression<Func<T, bool>> condition) where T : class,new()
        {
            return dbcontext.Set<T>().Where(condition).ToList();
        }
        public static IEnumerable<T> FindList<T>(this DbContextBase dbcontext, Expression<Func<T, bool>> condition, Pagination pagination) where T : class, new()
        {
            int total = pagination.records;
            var data = dbcontext.FindList<T>(condition, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }

        public static IEnumerable<T> FindList<T>(this DbContextBase dbcontext, string strSql) where T : class
        {
            return DbContextBaseExtension.FindList<T>(dbcontext,strSql, null);
        }
        public static IEnumerable<T> FindList<T>(this DbContextBase dbcontext, string strSql, DbParameter[] dbParameter) where T : class
        {
            var dbConnection = dbcontext.Database.Connection;
            using (var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, strSql, dbParameter))
            {
                return ConvertExtension.IDataReaderToList<T>(IDataReader);
            } 
        }


        public static IEnumerable<T> FindList<T>(this DbContextBase dbcontext,string strSql, DbParameter[] dbParameter, Pagination pagination) where T : class, new()
        {
            int total = pagination.records;
            var data = DbContextBaseExtension.FindList<T>(dbcontext,strSql, dbParameter, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }

        public static IEnumerable<T> FindList<T>(this DbContextBase dbcontext, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class,new()
        {
            string[] _order = orderField.Split(',');
            MethodCallExpression resultExp = null;
            var tempData = dbcontext.Set<T>().AsQueryable();
            foreach (string item in _order)
            {
                string _orderPart = item;
                _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
                string[] _orderArry = _orderPart.Split(' ');
                string _orderField = _orderArry[0];
                bool sort = isAsc;
                if (_orderArry.Length == 2)
                {
                    isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                }
                var parameter = Expression.Parameter(typeof(T), "t");
                var property = typeof(T).GetProperty(_orderField);
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(T), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
            }
            tempData = tempData.Provider.CreateQuery<T>(resultExp);
            total = tempData.Count();
            tempData = tempData.Skip<T>(pageSize * (pageIndex - 1)).Take<T>(pageSize).AsQueryable();
            return tempData.ToList();
        }
        public static IEnumerable<T> FindList<T>(this DbContextBase dbcontext, Expression<Func<T, bool>> condition, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class,new()
        {
            string[] _order = orderField.Split(',');
            MethodCallExpression resultExp = null;
            var tempData = dbcontext.Set<T>().Where(condition);
            foreach (string item in _order)
            {
                string _orderPart = item;
                _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
                string[] _orderArry = _orderPart.Split(' ');
                string _orderField = _orderArry[0];
                bool sort = isAsc;
                if (_orderArry.Length == 2)
                {
                    isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                }
                var parameter = Expression.Parameter(typeof(T), "t");
                var property = typeof(T).GetProperty(_orderField);
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(T), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
            }
            tempData = tempData.Provider.CreateQuery<T>(resultExp);
            total = tempData.Count();
            tempData = tempData.Skip<T>(pageSize * (pageIndex - 1)).Take<T>(pageSize).AsQueryable();
            return tempData.ToList();
        }
        public static IEnumerable<T> FindList<T>(this DbContextBase dbcontext, string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class
        {
            return DbContextBaseExtension.FindList<T>(dbcontext, strSql, null, orderField, isAsc, pageSize, pageIndex, out total);
        }
        public static IEnumerable<T> FindList<T>(this DbContextBase dbcontext, string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class
        {

            StringBuilder sb = new StringBuilder();
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            int num = (pageIndex - 1) * pageSize;
            int num1 = (pageIndex) * pageSize;
            string OrderBy = "";

            if (!string.IsNullOrEmpty(orderField))
            {
                if (orderField.ToUpper().IndexOf("ASC") + orderField.ToUpper().IndexOf("DESC") > 0)
                {
                    OrderBy = "Order By " + orderField;
                }
                else
                {
                    OrderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                }
            }
            else
            {
                OrderBy = "order by (select 0)";
            }
            sb.Append("Select * From (Select ROW_NUMBER() Over (" + OrderBy + ")");
            sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");

            var dbConnection = dbcontext.Database.Connection;
            total = Convert.ToInt32(new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, "Select Count(1) From (" + strSql + ") As t", dbParameter));
            using (var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, sb.ToString(), dbParameter))
            {
                return ConvertExtension.IDataReaderToList<T>(IDataReader);
            }
        }
        #endregion

        #region 数据源查询
        public static DataTable FindTable(this DbContextBase dbcontext, string strSql)
        {
            return DbContextBaseExtension.FindTable(dbcontext, strSql, null);
        }
        public static DataTable FindTable(this DbContextBase dbcontext, string strSql, DbParameter[] dbParameter)
        {
            var dbConnection = dbcontext.Database.Connection;
            using (var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, strSql, dbParameter))
            {
                return ConvertExtension.IDataReaderToDataTable(IDataReader);
            }
        }

        public static DataTable FindTable(this DbContextBase dbcontext, string strSql, DbParameter[] dbParameter, Pagination pagination)
        {
            int total = pagination.records;
            var data = DbContextBaseExtension.FindTable(dbcontext,strSql, dbParameter, pagination.sidx, pagination.sord.ToLower() == "asc" ? true : false, pagination.rows, pagination.page, out total);
            pagination.records = total;
            return data;
        }
        public static DataTable FindTable(this DbContextBase dbcontext, string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total)
        {
            return DbContextBaseExtension.FindTable(dbcontext, strSql, null, orderField, isAsc, pageSize, pageIndex, out total);
        }
        public static DataTable FindTable(this DbContextBase dbcontext, string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total)
        {

            StringBuilder sb = new StringBuilder();
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            int num = (pageIndex - 1) * pageSize;
            int num1 = (pageIndex) * pageSize;
            string OrderBy = "";

            if (!string.IsNullOrEmpty(orderField))
            {
                if (orderField.ToUpper().IndexOf("ASC") + orderField.ToUpper().IndexOf("DESC") > 0)
                {
                    OrderBy = "Order By " + orderField;
                }
                else
                {
                    OrderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                }
            }
            else
            {
                OrderBy = "order by (select 0)";
            }
            sb.Append("Select * From (Select ROW_NUMBER() Over (" + OrderBy + ")");
            sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");

            var dbConnection = dbcontext.Database.Connection; 
            total = Convert.ToInt32(new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, "Select Count(1) From (" + strSql + ") As t", dbParameter));
            using (var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, sb.ToString(), dbParameter))
            {
                DataTable resultTable = ConvertExtension.IDataReaderToDataTable(IDataReader);
                resultTable.Columns.Remove("rowNum");
                return resultTable; 
            }
        }
        public static object FindObject(this DbContextBase dbcontext, string strSql)
        {
            return DbContextBaseExtension.FindObject(dbcontext ,strSql, null);
        }
        public static object FindObject(this DbContextBase dbcontext, string strSql, DbParameter[] dbParameter)
        {
            var dbConnection = dbcontext.Database.Connection; 
            return new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, strSql, dbParameter); 
        }
        #endregion
    }
}
