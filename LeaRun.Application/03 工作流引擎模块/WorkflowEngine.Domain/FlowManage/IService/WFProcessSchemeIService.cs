﻿
using LeaRun.WorkflowEngine.Entity;
namespace LeaRun.WorkflowEngine.IService
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.03.18 15:54
    /// 描 述：工作流实例模板内容表操作接口（支持：SqlServer）
    /// </summary>
    public interface WFProcessSchemeIService
    {
        /// <summary>
        /// 获取实体对象
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        WFProcessSchemeEntity GetEntity(string keyValue);

        /// <summary>
        /// 保存实体数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        void SaveEntity(string keyValue, WFProcessSchemeEntity entity);
    }
}
