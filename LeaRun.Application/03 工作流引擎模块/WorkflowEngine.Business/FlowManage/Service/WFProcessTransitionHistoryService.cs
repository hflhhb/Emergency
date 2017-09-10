using LeaRun.WorkflowEngine.Entity;
using LeaRun.WorkflowEngine.IService;
using LeaRun.Data;
using LeaRun.Util.Extension;

namespace LeaRun.WorkflowEngine.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.03.18 15:54
    /// 描 述：工作流实例节点转化记录操作（支持：SqlServer）
    /// </summary>
    public class WFProcessTransitionHistoryService : DaoFactory, WFProcessTransitionHistoryIService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public WFProcessTransitionHistoryService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 获取流转实体
        /// </summary>
        /// <param name="processId">流程实例ID</param>
        /// <param name="toNodeId">流转到的节点Id</param>
        /// <returns></returns>
        public WFProcessTransitionHistoryEntity GetEntity(string processId,string toNodeId)
        {
            try
            {
                var Expression = LinqExtensions.True<WFProcessTransitionHistoryEntity>();
                Expression = Expression.And<WFProcessTransitionHistoryEntity>(t => t.ProcessId == processId);
                Expression = Expression.And<WFProcessTransitionHistoryEntity>(t => t.toNodeId == toNodeId);

                return base.db.FindEntity<WFProcessTransitionHistoryEntity>(Expression);
            }
            catch {
                throw;
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存实例
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(string keyValue, WFProcessTransitionHistoryEntity entity)
        {
            try
            {
                int num;
                if (string.IsNullOrEmpty(keyValue))
                {
                    entity.Create();
                    num = base.db.Insert(entity);
                }
                else
                {
                    entity.Modify(keyValue);
                    num = base.db.Update(entity);
                }
                return num;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
