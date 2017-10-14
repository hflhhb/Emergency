using LeaRun.WebBase;
using LeaRun.AuthorizeManage.Entity;
using LeaRun.AuthorizeManage.Entity.ViewModel;
using LeaRun.UserManage.Entity;
using LeaRun.AuthorizeManage.IService;
using LeaRun.Data; 
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using LeaRun.Util.Extension;

namespace LeaRun.AuthorizeManage.Service
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2016-2020 贵州数人科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.12.5 22:35
    /// 描 述：授权认证
    /// </summary>
    public class AuthorizeService : Dao<AuthorizeEntity>, IAuthorizeService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public AuthorizeService(DbContextBase dbcontext) : base(dbcontext){ }

        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_Module
                            WHERE   ModuleId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) 
                                            OR ObjectId = @UserId 
                                            ))
                            AND EnabledMark = 1  AND DeleteMark = 0 Order By SortCode");
            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@UserId",userId)
            };
            return base.db.FindList<ModuleEntity>(strSql.ToString(), parameter);
        }
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_ModuleButton
                            WHERE   ModuleButtonId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId ) Order By SortCode");
            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@UserId",userId)
            };
            return base.db.FindList<ModuleButtonEntity>(strSql.ToString(), parameter);
        }
        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_ModuleColumn
                            WHERE   ModuleColumnId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 3
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )  Order By SortCode");
            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@UserId",userId)
            };
            return base.db.FindList<ModuleColumnEntity>(strSql.ToString(), parameter);
        }
        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeUrlModel> GetUrlList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  ModuleId AS AuthorizeId ,
                                    ModuleId ,
                                    UrlAddress ,
                                    FullName
                            FROM    Base_Module
                            WHERE   ModuleId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )
                                    AND EnabledMark = 1
                                    AND DeleteMark = 0
                           
                                    AND UrlAddress IS NOT NULL
                            UNION
                            SELECT  ModuleButtonId AS AuthorizeId ,
                                    ModuleId ,
                                    ActionAddress AS UrlAddress ,
                                    FullName
                            FROM    Base_ModuleButton
                            WHERE   ModuleButtonId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )
                                    AND ActionAddress IS NOT NULL");
            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@UserId",userId)
            };
            return base.db.FindList<AuthorizeUrlModel>(strSql.ToString(), parameter);
        }
        /// <summary>
        /// 获取关联用户关系
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<UserRelationEntity> GetUserRelationList(string userId)
        {
            return base.db.Queryable<UserRelationEntity>(t => t.UserId == userId);
        }
        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthorUserId(Operator operators, bool isWrite = false)
        {
            string userIdList = GetDataAuthor(operators, isWrite);
            if (userIdList == "")
            {
                return "";
            } 

            string userId = operators.UserId;
            List<UserEntity> userList = base.db.FindList<UserEntity>(userIdList).ToList();
            StringBuilder userSb = new StringBuilder("");
            if (userList != null)
            {
                foreach (var item in userList)
                {
                    userSb.Append(item.UserId);
                    userSb.Append(",");
                }
            }
            return userSb.ToString();
        }
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthor(Operator operators, bool isWrite = false)
        {
            //如果是系统管理员直接给所有数据权限
            if (operators.IsSystem)
            {
                return "";
            } 

            string userId = operators.UserId;
            StringBuilder whereSb = new StringBuilder(" select UserId FROM Base_user where 1=1 ");
            string strAuthorData = "";
            if (isWrite)
            {
                strAuthorData = @"   SELECT    *
                                        FROM      Base_AuthorizeData
                                        WHERE     IsRead=0 AND
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    Base_UserRelation
                                                WHERE   UserId =@UserId)";
            }
            else
            {
                strAuthorData = @"   SELECT    *
                                        FROM      Base_AuthorizeData
                                        WHERE     
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    Base_UserRelation
                                                WHERE   UserId =@UserId)";
            }
            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@UserId",userId),
            };
            whereSb.Append(string.Format("AND( UserId ='{0}'", userId));
            IEnumerable<AuthorizeDataEntity> listAuthorizeData = db.FindList<AuthorizeDataEntity>(strAuthorData, parameter);
            foreach (AuthorizeDataEntity item in listAuthorizeData)
            {
                switch (item.AuthorizeType)
                {
                    //0代表最大权限
                    case 0://
                        return "";
                    //本人及下属
                    case -2://
                        whereSb.Append("  OR ManagerId ='{0}'");
                        break;
                    case -3:
                        whereSb.Append(@"  OR DepartmentId = (  SELECT  DepartmentId
                                                                    FROM    Base_User
                                                                    WHERE   UserId ='{0}'
                                                                  )");
                        break;
                    case -4:
                        whereSb.Append(@"  OR OrganizeId = (    SELECT  OrganizeId
                                                                    FROM    Base_User
                                                                    WHERE   UserId ='{0}'
                                                                  )");
                        break;
                    case -5:
                        whereSb.Append(string.Format(@"  OR DepartmentId='{1}' OR OrganizeId='{1}'", userId, item.ResourceId));
                        break;
                }
            }
            whereSb.Append(")");
            return whereSb.ToString();
        }


        #region Emergency使用, 以部门ID为基础的场合,没有用户ID数据的场合

        /// <summary>
        /// 获得权限范围部门ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public List<string> GetDataAuthorDeptIds(Operator operators, bool isWrite = false)
        {
            //如果是系统管理员直接给所有数据权限
            if (operators.IsSystem)
            {
                return null;
            }

            string userId = operators.UserId;

            string strAuthorData = "";
            if (isWrite)
            {
                strAuthorData = @"   SELECT    *
                                        FROM      Base_AuthorizeData
                                        WHERE     IsRead=0 AND
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    Base_UserRelation
                                                WHERE   UserId =@UserId)";
            }
            else
            {
                strAuthorData = @"   SELECT    *
                                        FROM      Base_AuthorizeData
                                        WHERE     
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    Base_UserRelation
                                                WHERE   UserId =@UserId)";
            }
            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter("@UserId",userId),
            };

            var lstDeptIds = new List<string>();
            var listAuthorizeData = db.FindList<AuthorizeDataEntity>(strAuthorData, parameter);
            //
            foreach (AuthorizeDataEntity item in listAuthorizeData)
            {
                switch (item.AuthorizeType)
                {
                    //0代表最大权限
                    case 0://
                        return null;
                    //本人及下属, 在部门选择上不支持
                    case -2://
                        break;
                    //所在部门
                    case -3:
                        lstDeptIds.Add(operators.DepartmentId);
                        break;
                    //所在公司 在部门选择上不支持
                    case -4:
                        break;
                    //自由选择部门
                    case -5:
                        //把部门ID添加到权限集合中
                        lstDeptIds.Add(item.ResourceId);
                        break;
                }
            }
            if (lstDeptIds.Count == 0)
            {
                //如果没有权限的场合，默认为0000,这样可以和最大权限的空区分开
                lstDeptIds.Add("0000");
            }

            return lstDeptIds;
        }
        #endregion

    }
}
