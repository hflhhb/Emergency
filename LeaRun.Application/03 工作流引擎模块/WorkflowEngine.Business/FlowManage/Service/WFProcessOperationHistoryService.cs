using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    /// 描 述：工作流实例操作记录表操作（支持：SqlServer）
    /// </summary>
    public class WFProcessOperationHistoryService : DaoFactory, WFProcessOperationHistoryIService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public WFProcessOperationHistoryService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据


        #endregion

        #region 提交数据
        /// <summary>
        /// 保存或更新实体对象
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        public void SaveEntity(string keyValue,WFProcessOperationHistoryEntity entity)
        {
            try
            {
                if(string.IsNullOrEmpty(keyValue))
                {
                    entity.Create();
                    base.db.Insert(entity);
                }
                else
                {
                    entity.Modify(keyValue);
                    base.db.Update(entity);
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
