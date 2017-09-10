using LeaRun.SystemManage.Entity;
using LeaRun.SystemManage.IService;
using LeaRun.Data;
using LeaRun.Util.Extension;
using LeaRun.Util;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.SystemManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.25 11:02
    /// 描 述：数据库备份
    /// </summary>
    public class DataBaseBackupService : Dao<DatabaseBackupEntity>, IDataBaseBackupService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public DataBaseBackupService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 库备份列表
        /// </summary>
        /// <param name="dataBaseLinkId">连接库Id</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DatabaseBackupEntity> GetList(string dataBaseLinkId, string queryJson)
        {
            var expression = LinqExtensions.True<DatabaseBackupEntity>();
            if (!string.IsNullOrEmpty(dataBaseLinkId))
            {
                expression = expression.And(t => t.DatabaseLinkId == dataBaseLinkId);
            }
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "EnCode":            //计划编号
                        expression = expression.And(t => t.EnCode.Contains(keyword));
                        break;
                    case "FullName":          //计划名称
                        expression = expression.And(t => t.FullName.Contains(keyword));
                        break;
                    default:
                        break;
                }
            }
            return base.Queryable(expression).OrderByDescending(t => t.CreateDate).ToList();
        }
        /// <summary>
        /// 库备份文件路径列表
        /// </summary>
        /// <param name="databaseBackupId">计划Id</param>
        /// <returns></returns>
        public IEnumerable<DatabaseBackupEntity> GetPathList(string databaseBackupId)
        {
            return base.Queryable(t => t.ParentId == databaseBackupId).OrderByDescending(t => t.CreateDate).ToList();
        }
        /// <summary>
        /// 库备份实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DatabaseBackupEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除库备份
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            base.Delete(keyValue);
        }
        /// <summary>
        /// 保存库备份表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="DatabaseBackupEntity">库备份实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DatabaseBackupEntity DatabaseBackupEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                DatabaseBackupEntity.Modify(keyValue);
                base.Update(DatabaseBackupEntity);
            }
            else
            {
                DatabaseBackupEntity.Create();
                base.Insert(DatabaseBackupEntity);
            }
        }
        #endregion
    }
}
