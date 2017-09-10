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
    /// 描 述：定义仓储对象工厂模式
    /// </summary> 
    public  class DaoFactory  
    {
        public DbContextBase db = null;

        #region 带UnitOfWork工作单元参数的构造函数

        /// <summary>
        /// 带UnitOfWork工作单元参数的构造函数
        /// </summary>
        /// <param name="dbcontext">数据库上下文</param>
        public DaoFactory(DbContextBase dbcontext)
        {
            this.db = dbcontext;
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
            return new Dao<T>(this.db);
        }
        #endregion
    }
}
