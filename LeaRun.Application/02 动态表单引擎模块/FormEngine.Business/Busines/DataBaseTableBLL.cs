using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using LeaRun.Util;
using LeaRun.Data;
using LeaRun.Util.Web;
using LeaRun.SystemManage.Service;
using LeaRun.SystemManage.IService;
using LeaRun.SystemManage.Entity;

namespace LeaRun.SystemManage.Business
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.18 11:02
    /// 描 述：数据库管理
    /// </summary>
    public class DataBaseTableBLL
    {
        private IDataBaseTableService service = new DataBaseTableService(DbFactory.Base());

        #region 获取数据
        /// <summary>
        /// 得到同一服务器上的数据库列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>  
        /// <returns></returns>
        public IEnumerable<DatabaseEntity> GetDBNameList(string dataBaseLinkId)
        {
            return service.GetDBNameList(dataBaseLinkId);
        }

        /// <summary>
        /// 数据表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="dbName">数据库名</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public IEnumerable<DatabaseTableEntity> GetTableInfoList(string dataBaseLinkId, string dbName,string tableName)
        {
            return service.GetTableInfoList(dataBaseLinkId, dbName, tableName);
        }

        /// <summary>
        /// 根据数据库名和表名获取表实体
        /// </summary> 
        /// <param name="dbName">数据库名</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public DBTableEntity GetDBTable(string dbName, string tableName)
        {
 
            //根据物理数据表,插入或删除Base_DBTable 数据模型--表信息表
            service.SyncFieldConfigByTableName( AppConstant.AppPlatformDB, dbName, tableName);
             
            IDBTableService dtService = new DBTableService(DbFactory.Base());
            return dtService.GetDBTable(dbName, tableName);
        }

        /// <summary>
        /// 根据数据库名、表名、字段名获取字段实体
        /// </summary> 
        /// <param name="dbName">数据库名</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <returns></returns>
        public DBTableFieldEntity GetDBTableField( string dbName, string tableName, string fieldName)
        {
            //根据物理数据表,插入或删除Base_DBTable 数据模型--表信息表
            service.SyncFieldConfigByTableName( AppConstant.AppPlatformDB, dbName, tableName);

            IDBTableFieldService fieldService = new DBTableFieldService(DbFactory.Base());
            return fieldService.GetDBTableField(dbName, tableName, fieldName);
        }
          
        /// <summary>
        /// 数据表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">数据库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        public IEnumerable<DatabaseFieldEntity> GetTableFiledList(string dataBaseLinkId, string tableName = "")
        {
            return service.GetTableFiledList(dataBaseLinkId, tableName);
        }
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
        public DataTable GetTableDataList(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, Pagination pagination)
        {
            return service.GetTableDataList(dataBaseLinkId, tableName, switchWhere, logic, keyword, pagination);
        }


        #endregion

        #region 提交数据
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
        /// <param name="fieldListJson">字段列表Json</param>
        public void CreateTable(string dataBaseLinkId, string tableName,string tableDisplayName, string tableModuleName, string tableNameSpace, string tableEntityClass, string tableDesc, string fieldListJson)
        {
            try
            {
                DataBaseLinkBLL dbLinkService = new DataBaseLinkBLL();
                DataBaseLinkEntity dataBaseLinkEntity = dbLinkService.GetEntity(dataBaseLinkId);
                 
                IEnumerable<DatabaseFieldEntity> fieldList = fieldListJson.ToList<DatabaseFieldEntity>();
                service.CreateTable(dataBaseLinkId, tableName, tableDisplayName , fieldList);
                  
                //创建表扩展信息实体
                IDBTableService dbTableService = new DBTableService(DbFactory.Base());
                DBTableEntity tableEntity = new DBTableEntity();
                tableEntity.Table_DBName = dataBaseLinkEntity.DBName;
                tableEntity.Table_Name = tableName ;
                tableEntity.Table_DisplayName = tableDisplayName;
                tableEntity.Table_ModuleName = tableModuleName;
                tableEntity.Table_NameSpace = tableNameSpace;
                tableEntity.Table_EntityClass = tableEntityClass;
                tableEntity.Table_Desc = tableDesc;
                tableEntity.Create();
                dbTableService.SaveForm(string.Empty, tableEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改表扩展信息及表描述
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDisplayName">表说明</param>
        /// <param name="tableModuleName">所属模块名</param>
        /// <param name="tableNameSpace">实体模型的命名空间</param>
        /// <param name="tableEntityClass">默认实体的类名</param>
        /// <param name="tableDesc">备注</param>
        public void ModifyTableInfo(string dataBaseLinkId, string tableName, string tableDisplayName, string tableModuleName, string tableNameSpace, string tableEntityClass, string tableDesc)
        {
            try
            {
                DataBaseLinkBLL dbLinkService = new DataBaseLinkBLL();
                DataBaseLinkEntity dataBaseLinkEntity = dbLinkService.GetEntity(dataBaseLinkId);
                //根据数据库名和表名获取表实体
                IDBTableService dbTableService = new DBTableService(DbFactory.Base());
                DBTableEntity tableEntity = dbTableService.GetDBTable(dataBaseLinkEntity.DBName, tableName);
                tableEntity.Table_DisplayName = tableDisplayName;
                tableEntity.Table_ModuleName = tableModuleName;
                tableEntity.Table_NameSpace = tableNameSpace;
                tableEntity.Table_EntityClass = tableEntityClass;
                tableEntity.Table_Desc = tableDesc;
                tableEntity.Modify(tableEntity.Table_Id);
                dbTableService.SaveForm(tableEntity.Table_Id, tableEntity);
                
                //修改物理表说明
                service.ModifyTableDesc(dataBaseLinkId, tableName, tableDisplayName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除物理表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        public void DeleteTable(string dataBaseLinkId, string tableName)
        {
            DataBaseLinkBLL dbLinkService = new DataBaseLinkBLL();
            DataBaseLinkEntity dataBaseLinkEntity = dbLinkService.GetEntity(dataBaseLinkId); 
            string strDBName = dataBaseLinkEntity.DBName;

            IDBTableService serviceTable = new DBTableService(DbFactory.Base());
            DBTableEntity tableEntity = serviceTable.GetDBTable(strDBName, tableName);

            IDBTableFieldService serviceField = new DBTableFieldService(DbFactory.Base());
            IEnumerable<DBTableFieldEntity> fieldList= serviceField.GetList(string.Empty).Where(t => t.Field_DBName ==  strDBName && t.Field_TableName == tableName);

            foreach(DBTableFieldEntity field in fieldList)
            {
                serviceField.RemoveForm(field.Field_Id);
            }

            if (tableEntity != null)  serviceTable.RemoveForm(tableEntity.Table_Id);

            // 删除物理表
            service.DeleteTable(dataBaseLinkId, tableName);
            
        }

        /// <summary>
        /// 新增字段
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldEntity">物理字段实体</param>
        public bool CreateField(string dataBaseLinkId, string tableName, DatabaseFieldEntity fieldEntity)
        {
            return service.CreateField(dataBaseLinkId, tableName, fieldEntity);
        }

        /// <summary>
        /// 调整字段
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldEntity">物理字段实体</param>
        public bool SaveField(string dataBaseLinkId, string tableName, DatabaseFieldEntity fieldEntity)
        {
            return service.SaveField(dataBaseLinkId, tableName, fieldEntity);
        }

        /// <summary>
        /// 调整字段
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        public bool DeleteField(string dataBaseLinkId, string tableName, string fieldName)
        {
            return service.DeleteField(dataBaseLinkId, tableName, fieldName);
        }

        /// <summary>
        /// 保持字段扩展信息实体
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="field">字段扩展信息实体</param> 
        /// <returns></returns>
        public void SaveFieldRelation(string dataBaseLinkId, string tableName, string fieldName, DBTableFieldEntity field)
        {
            service.ModifyFieldDesc(dataBaseLinkId, tableName, fieldName, field.Field_Desc);

            IDBTableFieldService fieldService = new DBTableFieldService(DbFactory.Base());
            fieldService.SaveForm(field.Field_Id, field);
        }
        
        #endregion
    }
}
