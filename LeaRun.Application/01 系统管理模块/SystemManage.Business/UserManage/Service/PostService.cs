﻿using LeaRun.UserManage.Entity;
using LeaRun.AuthorizeManage.IService;
using LeaRun.UserManage.IService;
using LeaRun.AuthorizeManage.Service;
using LeaRun.Data;

using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace LeaRun.UserManage.Service
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.4 14:31
    /// 描 述：岗位管理
    /// </summary>
    public class PostService : Dao<RoleEntity>, IPostService
    {
        private IAuthorizeService<RoleEntity> iauthorizeservice = null;

        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public PostService(DbContextBase dbcontext) : base(dbcontext)
        {
            iauthorizeservice = new AuthorizeService<RoleEntity>(dbcontext);
        }

        #region 获取数据
        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList()
        {
            var expression = LinqExtensions.True<RoleEntity>();
            expression = expression.And(t => t.Category == 2).And(t => t.EnabledMark == 1).And(t => t.DeleteMark == 0);
            return base.Queryable(expression).OrderByDescending(t => t.CreateDate).ToList();
        }
        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<RoleEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "EnCode":            //岗位编号
                        expression = expression.And(t => t.EnCode.Contains(keyword));
                        break;
                    case "FullName":          //岗位名称
                        expression = expression.And(t => t.FullName.Contains(keyword));
                        break;
                    default:
                        break;
                }
            }
            expression = expression.And(t => t.Category == 2);
            return base.FindList(expression, pagination);
        }
        /// <summary>
        /// 岗位列表(ALL)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  r.RoleId ,
				                    o.FullName AS OrganizeId ,
				                    r.Category ,
				                    r.EnCode ,
				                    r.FullName ,
				                    r.SortCode ,
				                    r.EnabledMark ,
				                    r.Description ,
				                    r.CreateDate
                    FROM    Base_Role r
				                    LEFT JOIN Base_Organize o ON o.OrganizeId = r.OrganizeId
                    WHERE   o.FullName is not null and r.Category = 2 and r.EnabledMark =1
                    ORDER BY o.FullName, r.SortCode");
            return base.FindList(strSql.ToString());
        }
        /// <summary>
        /// 岗位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 岗位编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            var expression = LinqExtensions.True<RoleEntity>();
            expression = expression.And(t => t.EnCode == enCode).And(t => t.Category == 2);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.RoleId != keyValue);
            }
            return base.Queryable(expression).Count() == 0 ? true : false;
        }
        /// <summary>
        /// 岗位名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            var expression = LinqExtensions.True<RoleEntity>();
            expression = expression.And(t => t.FullName == fullName).And(t => t.Category == 2);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.RoleId != keyValue);
            }
            return base.Queryable(expression).Count() == 0 ? true : false;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            base.Delete(keyValue);
        }
        /// <summary>
        /// 保存岗位表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="postEntity">岗位实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, RoleEntity postEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                postEntity.Modify(keyValue);
                base.Update(postEntity);
            }
            else
            {
                postEntity.Create();
                postEntity.Category = 2;
                base.Insert(postEntity);
            }
        }
        #endregion
    }
}
