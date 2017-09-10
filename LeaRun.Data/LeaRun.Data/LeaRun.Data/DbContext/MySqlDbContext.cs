using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using System.Linq;
using System.Web;
using System.IO;

namespace LeaRun.Data
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.10.10
    /// 描 述：数据访问(MySql) 上下文
    /// </summary>
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySqlDbContext : DbContextBase, IDbContext
    {
        #region 构造函数
        /// <summary>
        /// 初始化一个 使用指定数据连接名称或连接串 的数据访问上下文类 的新实例
        /// </summary>
        /// <param name="connString"></param>
        public MySqlDbContext(string connString)
            : base(connString)
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        #endregion


        #region 重载  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string dllpath = Assembly.GetExecutingAssembly().CodeBase.Replace("LeaRun.Data.DLL", "").Replace("file:///", "");

            foreach (string file in Directory.EnumerateFiles(dllpath, "*.Mapping.dll"))
            {
                var assembly = Assembly.Load(AssemblyName.GetAssemblyName(file));  
                modelBuilder.Configurations.AddFromAssembly(assembly);
            }
            foreach (string file in Directory.EnumerateFiles(dllpath, "*.Domain.dll"))
            {
                var assembly = Assembly.Load(AssemblyName.GetAssemblyName(file));
                modelBuilder.Configurations.AddFromAssembly(assembly);
            }
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
