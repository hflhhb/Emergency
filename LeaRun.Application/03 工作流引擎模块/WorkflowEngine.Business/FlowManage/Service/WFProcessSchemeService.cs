using LeaRun.WorkflowEngine.Entity;
using LeaRun.WorkflowEngine.IService;
using LeaRun.Data;

namespace LeaRun.WorkflowEngine.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.03.18 15:54
    /// 描 述：工作流实例模板内容表操作（支持：SqlServer）
    /// </summary>
    public class WFProcessSchemeService:DaoFactory, WFProcessSchemeIService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public WFProcessSchemeService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 获取实体对象
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public WFProcessSchemeEntity GetEntity(string keyValue)
        {
            try
            {
                return base.db.FindEntity<WFProcessSchemeEntity>(keyValue);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存实体数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        public void SaveEntity(string keyValue,WFProcessSchemeEntity entity)
        {
            try
            {
                if (string.IsNullOrEmpty(keyValue))
                {
                    entity.Create();
                    base.db.Insert<WFProcessSchemeEntity>(entity);
                }
                else {
                    entity.Modify(keyValue);
                    base.db.Update<WFProcessSchemeEntity>(entity);
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
