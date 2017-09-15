using LeaRun.ResourceManage.Entity;
using LeaRun.ResourceManage.IService;
using LeaRun.Data;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util.Extension;
using LeaRun.Util;

namespace LeaRun.ResourceManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创 建：HFL
    /// 日 期：2017-09-13 00:46
    /// 描 述：Camera
    /// </summary>
    public class CameraService : Dao<CameraEntity>, ICameraService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public CameraService(DbContextBase dbcontext) : base(dbcontext)
        {
        }

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<CameraEntity> GetList(string queryJson)
        {
            return base.Queryable().OrderByDescending(t => t.CreateTime).ToList();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<CameraEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<CameraEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "Code":            //编号
                        expression = expression.And(t => t.Code.Contains(keyword));
                        break;
                    case "Area":            //区域
                        expression = expression.And(t => t.Area.Contains(keyword));
                        break;
                    case "Address":        //地址
                        expression = expression.And(t => t.Address.Contains(keyword));
                        break;
                    default:
                        break;
                }
            }
            return base.FindList(expression, pagination);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public CameraEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, CameraEntity entity)
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
