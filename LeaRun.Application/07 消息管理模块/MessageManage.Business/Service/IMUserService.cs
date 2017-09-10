using LeaRun.MessageManage.Entity;
using LeaRun.MessageManage.IService;
using LeaRun.Data; 
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace LeaRun.MessageManage.Service
{
    /// <summary>
    /// 版 本 V6.1
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.11.26 11:14
    /// 描 述：即时通信用户管理
    /// </summary>
    public class IMUserService : Dao<IMUserModel>, IMsgUserService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public IMUserService(DbContextBase dbcontext) : base(dbcontext){ }

        /// <summary>
        /// 获取联系人列表（即时通信）
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IMUserModel> GetList(string OrganizeId)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT  u.UserId ,
                                    u.RealName ,
                                    o.FullName AS OrganizeId ,
                                    d.FullName AS DepartmentId ,
                                    u.HeadIcon  
                            FROM    Base_User u
                                    LEFT JOIN Base_Organize o ON o.OrganizeId = u.OrganizeId
                                    LEFT JOIN Base_Department d ON d.DepartmentId = u.DepartmentId
                            WHERE   1=1");
            var parameter = new List<DbParameter>();
            //公司主键
            if (!OrganizeId.IsEmpty())
            {
                strSql.Append(" AND u.OrganizeId = @OrganizeId");
                parameter.Add(DbParameters.CreateDbParameter("@OrganizeId", OrganizeId));
            }
            strSql.Append(" AND u.UserId <> 'System'");
            strSql.Append(" order by d.FullName");
            return base.db.FindList<IMUserModel>(strSql.ToString(), parameter.ToArray());
        }
    }
}
