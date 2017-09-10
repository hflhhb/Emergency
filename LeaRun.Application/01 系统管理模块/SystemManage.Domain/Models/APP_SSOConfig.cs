using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace LeaRun.SystemManage.Entity
{
    /// <summary>
    /// 单点登录参数配置类。
    /// </summary>
    public class APP_SSOConfig : LeaRun.Data.BaseEntity
    {
        /// <summary>
        /// 自增长ID
        /// </summary>
        [Key]
        public int sso_Id { get; set; }


        /// <summary>
        /// 应用系统名
        /// </summary>
        public string sso_App { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public string pwd_UserType { get; set; }

        /// <summary>
        /// 系统管理链接Guid
        /// </summary>
        public Guid sso_SystemManageConn { get; set; }

        /// <summary>
        /// 应用是否开通了此用户SQL
        /// </summary>
        public string sso_ExistUserSQL { get; set; }

        /// <summary>
        /// 登录模式：空、Domain、Site、ProductLine
        /// </summary>
        public string sso_LoginMode { get; set; }


        /// <summary>
        /// 如果此字符不为空，则需要人工在登录界面输入随机校验码
        /// </summary>
        public string sso_VerifyCodeURL { get; set; }


        /// <summary>
        /// 提交登录URL参数字符串
        /// </summary>
        public string sso_LoginURL { get; set; }
         
    }
}
