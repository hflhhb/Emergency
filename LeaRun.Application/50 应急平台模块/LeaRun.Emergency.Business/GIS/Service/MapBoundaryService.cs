using LeaRun.GIS.Entity;
using LeaRun.GIS.IService;
using LeaRun.Data;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.GIS.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 HFL
    /// 创 建：admin
    /// 日 期：2017-09-17 21:31
    /// 描 述：MapBoundary
    /// </summary>
    public class MapBoundaryService : Dao<MapBoundaryEntity>, IMapBoundaryService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public MapBoundaryService(DbContextBase dbcontext) : base(dbcontext)
        {
        }
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<MapBoundaryEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return base.FindList(pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<MapBoundaryEntity> GetList(string queryJson)
        {
            return base.Queryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public MapBoundaryEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, MapBoundaryEntity entity)
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
