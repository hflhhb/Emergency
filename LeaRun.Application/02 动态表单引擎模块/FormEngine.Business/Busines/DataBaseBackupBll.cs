using LeaRun.SystemManage.Entity;
using LeaRun.SystemManage.IService;
using LeaRun.SystemManage.Service;
using System;
using System.Collections.Generic;
using LeaRun.Data;

namespace LeaRun.SystemManage.Business
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.25 11:02
    /// 描 述：数据库备份
    /// </summary>
    public class DataBaseBackupBLL
    {
        private IDataBaseBackupService service = new DataBaseBackupService(DbFactory.Base());

        #region 获取数据
        /// <summary>
        /// 库备份列表
        /// </summary>
        /// <param name="dataBaseLinkId">连接库Id</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DatabaseBackupEntity> GetList(string dataBaseLinkId, string queryJson)
        {
            return service.GetList(dataBaseLinkId, queryJson);
        }
        /// <summary>
        /// 库备份文件路径列表
        /// </summary>
        /// <param name="databaseBackupId">计划Id</param>
        /// <returns></returns>
        public IEnumerable<DatabaseBackupEntity> GetPathList(string databaseBackupId)
        {
            return service.GetPathList(databaseBackupId);
        }
        /// <summary>
        /// 库备份实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DatabaseBackupEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除库备份
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存库备份表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="DatabaseBackupEntity">库备份实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DatabaseBackupEntity DatabaseBackupEntity)
        {
            try
            {
                service.SaveForm(keyValue, DatabaseBackupEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
