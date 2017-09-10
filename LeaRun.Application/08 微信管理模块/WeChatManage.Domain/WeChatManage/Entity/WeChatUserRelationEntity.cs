﻿using LeaRun.WebBase;
using System;

namespace LeaRun.WeChatManage.Entity
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.12.23 11:31
    /// 描 述：企业号成员
    /// </summary>
    public class WeChatUserRelationEntity : LeaRun.Data.BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 部门对应关系主键
        /// </summary>		
        public string UserRelationId { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>		
        public string DeptId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>		
        public string DeptName { get; set; }
        /// <summary>
        /// 微信部门Id
        /// </summary>		
        public int? WeChatDeptId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>		
        public string UserId { get; set; }
        /// <summary>
        /// 同步状态
        /// </summary>		
        public string SyncState { get; set; }
        /// <summary>
        /// 同步日志
        /// </summary>		
        public string SyncLog { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>		
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>		
        public string CreateUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.UserRelationId = keyValue;
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}