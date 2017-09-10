using System;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

using Microsoft.Practices.Unity;
using LeaRun.Util.Ioc; 

namespace LeaRun.Data
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.10.10
    /// 描 述：数据库建立工厂
    /// </summary>
    public class DbFactory
    {
        #region 平台和基础数据库对象
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <param name="DbType">数据库类型</param>
        /// <returns></returns>
        public static DbContextBase GetDBByName(string connString, DatabaseType DbType)
        {
            DbHelper.DbType = DbType;
            DbContextBase dbContext =(DbContextBase)UnityIocHelper.DBInstance.GetService<IDbContext>(new ParameterOverride(
              "connString", connString), new ParameterOverride(
              "DbType", DbType.ToString()));

            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;
            dbContext.Configuration.LazyLoadingEnabled = false;
            dbContext.Configuration.ProxyCreationEnabled = false;

            return dbContext;

        }
        /// <summary>
        /// 系统管理和基础数据库
        /// </summary>
        /// <returns></returns>
        public static DbContextBase Base()
        {
            DbHelper.DbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), UnityIocHelper.GetmapToByName("DBcontainer", "IDbContext"));
            return (DbContextBase)UnityIocHelper.DBInstance.GetService<IDbContext>(new ParameterOverride(
             "connString", "BaseDb"), new ParameterOverride(
              "DbType", ""));
        }

        /// <summary>
        /// 平台数据库
        /// </summary>
        /// <returns></returns>
        public static DbContextBase Platform()
        {
            DbHelper.DbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), UnityIocHelper.GetmapToByName("DBcontainer", "IDbContext"));
            return (DbContextBase)UnityIocHelper.DBInstance.GetService<IDbContext>(new ParameterOverride(
             "connString", "PlatformDb"), new ParameterOverride(
              "DbType", ""));
        }

        /// <summary>
        /// CRM 客户关系数据库
        /// </summary>
        /// <returns></returns>
        public static DbContextBase CRM()
        {
            DbHelper.DbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), UnityIocHelper.GetmapToByName("DBcontainer", "IDbContext"));
            return (DbContextBase)UnityIocHelper.DBInstance.GetService<IDbContext>(new ParameterOverride(
             "connString", "CRMDb"), new ParameterOverride(
              "DbType", ""));
        }

        /// <summary>
        /// OA 文档发布及OA数据库
        /// </summary>
        /// <returns></returns>
        public static DbContextBase OA()
        {
            DbHelper.DbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), UnityIocHelper.GetmapToByName("DBcontainer", "IDbContext"));
            return (DbContextBase)UnityIocHelper.DBInstance.GetService<IDbContext>(new ParameterOverride(
             "connString", "OADb"), new ParameterOverride(
              "DbType", ""));
        }
        #endregion

    }
}
