using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using LeaRun.Data;

namespace LeaRun.Data
{
    /// <summary>
    /// Unit Of Work 工作单元实现类
    /// </summary>
    public class DbContextBase : DbContext, IDbContext 
    {
        #region 带数据库连接名参数的构造函数
        /// <summary>
        /// 带连接名参数的构造函数
        /// </summary>
        /// <param name="connStringName">数据库连接名或者数据库连接字符串</param>
        public DbContextBase(string connStringName)
            : base(connStringName)
        {

        }
        #endregion


        #region 各类型视图DAO扩展方法
        /// <summary>
        /// 各类型视图DAO扩展方法
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public Dao<T> Dao<T>() where T : class, new()
        {
            return new Dao<T>(this);
        }
        #endregion

        #region 事物提交
        /// <summary>
        /// 事务开始
        /// </summary>
        /// <returns></returns>
        public DbContextTransaction BeginTrans()
        {

            if (this.Database.Connection.State == ConnectionState.Closed)
            {
                this.Database.Connection.Open();
            }
            return this.Database.BeginTransaction();
        }

        /// <summary>
        /// 提交当前操作的结果
        /// </summary>
        public int Commit()
        {
            try
            {
                var returnValue = this.SaveChanges();
                if (this.Database.CurrentTransaction != null)
                {
                    this.Database.CurrentTransaction.Commit();
                }

                if (this.Database.Connection.State == ConnectionState.Open)
                {
                    this.Database.Connection.Close();
                }
                return returnValue;
            }
            catch (Exception)
            {
                if (this.Database.CurrentTransaction != null)
                {
                    this.Database.CurrentTransaction.Rollback();
                }
                throw;
            }
        }

        /// <summary>
        /// 把当前操作回滚成未提交状态
        /// </summary>
        public void Rollback()
        {
            this.Database.CurrentTransaction.Rollback();
            this.Database.CurrentTransaction.Dispose();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Commit();
            }
        }
        #endregion 

    }


}
