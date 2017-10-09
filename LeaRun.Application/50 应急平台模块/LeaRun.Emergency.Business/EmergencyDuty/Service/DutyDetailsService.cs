using LeaRun.EmergencyDuty.Entity;
using LeaRun.EmergencyDuty.IService;
using LeaRun.Data;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util.Extension;
using LeaRun.Util;
using LeaRun.AuthorizeManage.Service;
using LeaRun.AuthorizeManage.IService;

namespace LeaRun.EmergencyDuty.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 HFL
    /// 创 建：admin
    /// 日 期：2017-09-28 00:06
    /// 描 述：值班详情表
    /// </summary>
    public class DutyDetailsService : Dao<DutyDetailsEntity>, IDutyDetailsService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public DutyDetailsService(DbContextBase dbcontext) : base(dbcontext)
        {
        }

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<DutyDetailsEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<DutyDetailsEntity>();
            var queryParam = queryJson.ToJObject();

            if (!queryParam["DutyId"].IsEmpty())
            {
                var dutyId = queryParam["DutyId"].ToString();
                expression = expression.And(t => t.DutyId == dutyId);
            }

            return base.Queryable(expression).ToList();
        }
        #endregion
    }
}
