﻿using LeaRun.WorkflowEngine.Entity;

namespace LeaRun.WorkflowEngine.IService
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.03.18 15:54
    /// 描 述：工作流实例节点转化记录操作接口（支持：SqlServer）
    /// </summary>
    public interface WFProcessTransitionHistoryIService
    {
        #region 获取数据
        /// <summary>
        /// 获取流转实体
        /// </summary>
        /// <param name="processId">流程实例ID</param>
        /// <param name="toNodeId">流转到的节点Id</param>
        /// <returns></returns>
        WFProcessTransitionHistoryEntity GetEntity(string processId, string toNodeId);
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存实例
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        int SaveEntity(string keyValue, WFProcessTransitionHistoryEntity entity);
        #endregion
    }
}
