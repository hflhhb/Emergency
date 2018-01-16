using LeaRun.EmergencyDuty.Entity;
using LeaRun.EmergencyDuty.IService;
using LeaRun.Data;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.EmergencyDuty.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 HFL
    /// 创 建：HFL
    /// 日 期：2017-11-01 21:39
    /// 描 述：值班人员表
    /// </summary>
    public class DutyUsersService : Dao<DutyUsersEntity>, IDutyUsersService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public DutyUsersService(DbContextBase dbcontext) : base(dbcontext)
        {
        }
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<DutyUsersEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return base.FindList(pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<DutyUsersEntity> GetList(string queryJson)
        {
            return base.Queryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DutyUsersEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            base.Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DutyUsersEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                base.Update(entity);
            }
            else
            {
                entity.Create();
                base.Insert(entity);
            }
        }
        #endregion
    }
}
