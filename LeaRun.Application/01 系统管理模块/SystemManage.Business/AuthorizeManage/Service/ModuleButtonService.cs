using LeaRun.AuthorizeManage.Entity;
using LeaRun.AuthorizeManage.IService;
using LeaRun.Data;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.UserManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.08.01 14:00
    /// 描 述：系统按钮
    /// </summary>
    public class ModuleButtonService : Dao<ModuleButtonEntity>, IModuleButtonService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public ModuleButtonService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <returns></returns>
        public List<ModuleButtonEntity> GetList()
        {
            return base.Queryable().OrderBy(t => t.SortCode).ToList();
        }
        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public List<ModuleButtonEntity> GetList(string moduleId)
        {
            var expression = LinqExtensions.True<ModuleButtonEntity>();
            expression = expression.And(t => t.ModuleId.Equals(moduleId));
            return base.Queryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleButtonEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="moduleButtonEntity">按钮实体</param>
        public void AddEntity(ModuleButtonEntity moduleButtonEntity)
        {
            moduleButtonEntity.Create();
            base.Insert(moduleButtonEntity);
        }
        #endregion
    }
}
