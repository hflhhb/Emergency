using LeaRun.UserManage.Business;
using LeaRun.UserManage.Entity;
using LeaRun.Cache.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.UserManage.Cache
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.3.4 9:56
    /// 描 述：部门信息缓存
    /// </summary>
    public class DepartmentCache
    {
        private DepartmentBLL busines = new DepartmentBLL();

        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> GetList()
        {
            var cacheList = CacheFactory.Cache().GetCache<IEnumerable<DepartmentEntity>>(busines.cacheKey);
            if (cacheList == null)
            {
                var data = busines.GetList();
                CacheFactory.Cache().WriteCache(data, busines.cacheKey);
                return data;
            }
            else
            {
                return cacheList;
            }
        }
        /// <summary>
        /// 部门列表
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> GetList(string organizeId)
        {
            var data = this.GetList();
            if (!string.IsNullOrEmpty(organizeId))
            {
                data = data.Where(t => t.OrganizeId == organizeId);
            }
            return data;
        }

        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        public DepartmentEntity GetEntity(string departmentId)
        {
            var data = this.GetList();
            if(!string.IsNullOrEmpty(departmentId))
            {
                var d = data.Where(t => t.DepartmentId == departmentId).ToList<DepartmentEntity>();
                if (d.Count > 0)
                {
                    return d[0];
                }
            }
            return new DepartmentEntity();
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        /// <param name="departmentId">部门ID</param>
        /// <returns></returns>
        public string ToDeptName(string departmentId)
        {
            var data = this.GetEntity(departmentId);

            return data?.FullName;
        }
    }
}
