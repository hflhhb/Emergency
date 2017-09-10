using LeaRun.SystemManage.Entity;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System.Data;

namespace LeaRun.SystemManage.IService
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.18 11:02
    /// 描 述：数据库管理
    /// </summary>
    public interface IDataBaseTableService
    {
        #region 获取数据
        /// <summary>
        /// 得到同一服务器上的数据库列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>  
        /// <returns></returns>
        IEnumerable<DatabaseEntity> GetDBNameList(string dataBaseLinkId);

        /// <summary>
        /// 数据表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="dbName">数据库名</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        IEnumerable<DatabaseTableEntity> GetTableInfoList(string dataBaseLinkId, string dbName, string tableName);

        /// <summary>
        /// 数据表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        IEnumerable<DatabaseFieldEntity> GetTableFiledList(string dataBaseLinkId, string tableName);
        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接</param>
        /// <param name="tableName">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        DataTable GetTableDataList(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, Pagination pagination);
        #endregion

        #region 提交数据

        /// <summary>
        /// 修改物理表说明
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDisplayName">表说明</param>
        /// <returns></returns>
        void ModifyTableDesc(string dataBaseLinkId, string tableName, string tableDisplayName);

        /// <summary>
        /// 保存数据库表表单（新增、修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDisplayName">表说明</param>
        /// <param name="tableModuleName">所属模块名</param>
        /// <param name="tableNameSpace">实体模型的命名空间</param>
        /// <param name="tableEntityClass">默认实体的类名</param>
        /// <param name="tableDesc">备注</param>
        /// <param name="fieldList">字段列表</param>
        void CreateTable(string dataBaseLinkId,string tableName, string tableDisplayName , IEnumerable<DatabaseFieldEntity> fieldList);

        /// <summary>
        /// 删除物理表
        /// </summary>
        /// <param name="dataBaseLinkId"></param>
        /// <param name="tableName"></param>
        void DeleteTable(string dataBaseLinkId, string tableName);

        /// <summary>
        /// 新增字段
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldEntity">物理字段实体</param>
        bool CreateField(string dataBaseLinkId, string tableName, DatabaseFieldEntity fieldEntity);

        /// <summary>
        /// 调整字段
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldEntity">物理字段实体</param>
        bool SaveField(string dataBaseLinkId, string tableName, DatabaseFieldEntity fieldEntity);

        /// <summary>
        /// 修改物理字段说明
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldDescription">字段说明</param>
        /// <returns></returns>
        bool ModifyFieldDesc(string dataBaseLinkId, string tableName, string fieldName, string fieldDescription);

        /// <summary>
        /// 调整字段
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        bool DeleteField(string dataBaseLinkId, string tableName, string fieldName);
        #endregion

        /// <summary>
        /// 根据物理数据表,插入或删除Base_DBTable 数据模型--表信息表
        /// </summary>
        /// <param name="dataBaseLinkId">数据库连接ID</param> 
        /// <param name="strPlatform_DBName">平台数据库名</param>
        /// <param name="strDBName">数据库名</param>
        bool SyncDataTable(string dataBaseLinkId, string strPlatform_DBName, string strDBName);

        /// <summary>
        /// 将数据库的字段信息先补充到DBTableField表
        /// 然后在DBTableField字段信息配置表中，根据表名获得字段信息
        /// </summary>
        /// <param name="strPlatform_DBName">平台数据库名</param>
        /// <param name="strDBName">数据库名</param>
        /// <param name="strTableName">表名</param>
        /// <returns></returns>
        bool SyncFieldConfigByTableName( string strPlatform_DBName, string strDBName, string strTableName);
    }
}
