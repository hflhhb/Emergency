using System;
using System.Data.Entity.Infrastructure;

namespace LeaRun.Data
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.04.07
    /// 描 述：数据库连接接口 
    /// </summary>
    public interface IDbContext : IDisposable, IObjectContextAdapter
    {
    }
}
