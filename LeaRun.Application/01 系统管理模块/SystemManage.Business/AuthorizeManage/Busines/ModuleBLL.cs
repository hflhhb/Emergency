﻿using System;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Data;
using LeaRun.Util;
using LeaRun.AuthorizeManage.Entity;
using LeaRun.AuthorizeManage.IService;
using LeaRun.UserManage.Service;

namespace LeaRun.AuthorizeManage.Business
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.10.27 09:16
    /// 描 述：系统功能
    /// </summary>
    public class ModuleBLL
    {
        private IModuleService service = new ModuleService(DbFactory.Base());

        #region 获取数据
        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public int GetSortCode()
        {
            return service.GetSortCode();
        }
        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <param name="parentId">父级主键</param>
        /// <returns></returns>
        public List<ModuleEntity> GetList(string parentId = "")
        {
            var data = service.GetList().ToList();
            if (!string.IsNullOrEmpty(parentId))
            {
                data = data.FindAll(t => t.ParentId == parentId);
            }
            return data;
        }

        /// <summary>
        /// 得到所有模块分类列表----非菜单
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetModuleList()
        {
            return service.GetModuleList();
        }

        /// <summary>
        /// 获取功能实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 功能编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            return service.ExistEnCode(enCode, keyValue);
        }
        /// <summary>
        /// 功能名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            return service.ExistFullName(fullName, keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除功能
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
        /// 保存表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonList">按钮实体列表</param>
        /// <param name="moduleColumnList">视图实体列表</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ModuleEntity moduleEntity, string moduleButtonListJson, string moduleColumnListJson)
        {
            try
            {
                var moduleButtonList = moduleButtonListJson.ToList<ModuleButtonEntity>();
                var moduleColumnList = moduleColumnListJson.ToList<ModuleColumnEntity>();
                service.SaveForm(keyValue, moduleEntity, moduleButtonList, moduleColumnList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
