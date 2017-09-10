using System;
using LeaRun.WebBase;

namespace LeaRun.SystemManage.Entity
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 肖海根
    /// 创 建：admin
    /// 日 期：2017-03-12 07:58
    /// 描 述：数据库表
    /// </summary>
    public class DBTableEntity : LeaRun.Data.BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// Table_Id
        /// </summary>
        /// <returns></returns>
        public string Table_Id { get; set; }
        /// <summary>
        /// 数据库名
        /// </summary>
        /// <returns></returns>
        public string Table_DBName { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        /// <returns></returns>
        public string Table_Name { get; set; }
        /// <summary>
        /// 表说明
        /// </summary>
        /// <returns></returns>
        public string Table_DisplayName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Table_Desc { get; set; }
        /// <summary>
        /// 所属功能模块
        /// </summary>
        /// <returns></returns>
        public string Table_ModuleName { get; set; }
        /// <summary>
        /// 实体模型的命名空间
        /// </summary>
        /// <returns></returns>
        public string Table_NameSpace { get; set; }
        /// <summary>
        /// 默认实体的类名
        /// </summary>
        /// <returns></returns>
        public string Table_EntityClass { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        /// <returns></returns>
        public int? Table_DeleteFlag { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Table_Id = Guid.NewGuid().ToString();
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
            this.Table_Id = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}