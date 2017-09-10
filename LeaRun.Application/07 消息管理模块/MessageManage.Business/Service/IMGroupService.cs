using LeaRun.MessageManage.Entity;
using LeaRun.MessageManage.IService;
using LeaRun.Data; 
using LeaRun.Util.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace LeaRun.MessageManage.Service
{
    /// <summary>
    /// 版 本 V6.1
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.11.26 19:39
    /// 描 述：即时通信群组管理
    /// </summary>
    public class IMGroupService :  Dao<IMGroupEntity>, IMsgGroupService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public IMGroupService(DbContextBase dbcontext) : base(dbcontext){ }

        /// <summary>
        /// 获取群组列表（即时通信）
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IMGroupModel> GetList(string userId)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  g.GroupId ,
                                    g.FullName AS GroupName ,
                                    u.UserId ,
                                    u.UserGroupId
                            FROM    IM_UserGroup u
                                    LEFT JOIN IM_Group g ON u.GroupId = g.GroupId
                            WHERE   1 = 1");
            var parameter = new List<DbParameter>();
            //公司主键
            if (!userId.IsEmpty())
            {
                strSql.Append(" AND u.UserId = @UserId");
                parameter.Add(DbParameters.CreateDbParameter("@UserId", userId));
            }
            return base.db.FindList<IMGroupModel>(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// 获取群组里面的用户Id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public DataTable GetUserIdList(string groupId)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  t.GroupId ,
                                    t.UserId
                            FROM    IM_UserGroup t
                            WHERE   1 = 1");
            var parameter = new List<DbParameter>();
            //群组Id
            if (!groupId.IsEmpty())
            {
                strSql.Append(" AND u.GroupId = @GroupId");
                parameter.Add(DbParameters.CreateDbParameter("@GroupId", groupId));
            }
            return base.FindTable(strSql.ToString(), parameter.ToArray());
        }

        #region 提交数据
        /// <summary>
        /// 保存群组信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        public void Save(string keyValue, IMGroupEntity entity,List<string> userIdList)
        {
           
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                base.db.Update<IMGroupEntity>(entity);
            }
            else
            {
                DbContextBase db = (DbContextBase)DbFactory.Base();
                db.BeginTrans();
                try
                {
                    entity.Create();
                    db.Insert<IMGroupEntity>(entity);

                    foreach (string userOne in userIdList)
                    {
                        IMUserGroupEntity msgusergroupentity = new IMUserGroupEntity();
                        msgusergroupentity.GroupId = entity.GroupId;
                        msgusergroupentity.UserId = userOne;
                        msgusergroupentity.CreateUserId = entity.CreateUserId;
                        msgusergroupentity.CreateUserName = entity.CreateUserName;
                        db.Insert<IMUserGroupEntity>(msgusergroupentity);
                    }
                    db.Commit();
                }
                catch (Exception)
                {
                    db.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// 删除群组里的一个联系人
        /// </summary>
        /// <param name="UserGroupId"></param>
        public void RemoveUserId(string UserGroupId)
        {
            string keyValue = UserGroupId;
            base.db.Delete<IMUserGroupEntity>(keyValue);
        }
        /// <summary>
        /// 群里增加一个用户
        /// </summary>
        /// <param name="entity"></param>
        public void AddUserId(IMUserGroupEntity entity)
        {
            entity.Create();
            base.db.Insert<IMUserGroupEntity>(entity);
        }
        #endregion
    }
}
