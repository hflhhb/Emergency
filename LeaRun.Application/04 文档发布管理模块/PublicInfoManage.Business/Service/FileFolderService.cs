using LeaRun.PublicInfoManage.Entity;
using LeaRun.PublicInfoManage.IService;
using LeaRun.Data;
using LeaRun.Util.Extension;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.PublicInfoManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.12.15 10:56
    /// 描 述：文件夹
    /// </summary>
    public class FileFolderService : Dao<FileFolderEntity>, IFileFolderService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public FileFolderService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 文件夹列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<FileFolderEntity> GetList(string userId)
        {
            var expression = LinqExtensions.True<FileFolderEntity>();
            expression = expression.And(t => t.CreateUserId == userId);
            return base.Queryable(expression).ToList();
        }
        /// <summary>
        /// 文件夹实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public FileFolderEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 还原文件夹
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RestoreFile(string keyValue)
        {
            FileFolderEntity fileFolderEntity = new FileFolderEntity();
            fileFolderEntity.Modify(keyValue);
            fileFolderEntity.DeleteMark = 0;
            base.Update(fileFolderEntity);
        }
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            FileFolderEntity fileFolderEntity = new FileFolderEntity();
            fileFolderEntity.Modify(keyValue);
            fileFolderEntity.DeleteMark = 1;
            base.Update(fileFolderEntity);
        }
        /// <summary>
        /// 彻底删除文件夹
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void ThoroughRemoveForm(string keyValue)
        {
            base.Delete(keyValue);
        }
        /// <summary>
        /// 保存文件夹表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fileFolderEntity">文件夹实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, FileFolderEntity fileFolderEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                fileFolderEntity.Modify(keyValue);
                base.Update(fileFolderEntity);
            }
            else
            {
                fileFolderEntity.Create();
                base.Insert(fileFolderEntity);
            }
        }
        /// <summary>
        /// 共享文件夹
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="IsShare">是否共享：1-共享 0取消共享</param>
        public void ShareFolder(string keyValue, int IsShare)
        {
            FileFolderEntity fileFolderEntity = new FileFolderEntity();
            fileFolderEntity.FolderId = keyValue;
            fileFolderEntity.IsShare = IsShare;
            fileFolderEntity.ShareTime = DateTime.Now;
            base.Update(fileFolderEntity);
        }
        #endregion
    }
}
