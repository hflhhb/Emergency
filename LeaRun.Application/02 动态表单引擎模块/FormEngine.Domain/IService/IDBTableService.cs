using LeaRun.SystemManage.Entity; 
using System.Collections.Generic;

namespace LeaRun.SystemManage.IService
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创 建：admin
    /// 日 期：2017-03-12 07:00
    /// 描 述：数据库表DAO
    /// </summary>
    public interface IDBTableService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<DBTableEntity> GetList(string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        DBTableEntity GetEntity(string keyValue);

        /// <summary>
        /// 根据数据库名和表名获取表实体
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        DBTableEntity GetDBTable(string dbName, string tableName);
        #endregion

        #region 提交数据
         

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void SaveForm(string keyValue, DBTableEntity entity);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);

        #endregion
    }
}
