using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LeaRun.SystemManage.Entity
{
    /// <summary>
    /// 统一密码设置类。
    /// </summary>
    public class APP_SSOPwd : LeaRun.Data.BaseEntity
    {
        /// <summary>
        /// 自增长ID
        /// </summary>
        [Key]
        public int pwd_Id { get; set; }


        /// <summary>
        /// 工号
        /// </summary>
        public string pwd_Account { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public string pwd_UserType { get; set; }

        /// <summary>
        /// 饭卡号
        /// </summary>
        public string pwd_CardNo { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string pwd_Password { get; set; }

        /// <summary>
        /// Window域账号
        /// </summary>
        public string pwd_DomainAccount { get; set; }


        /// <summary>
        /// 找回密码时需要的手机号码
        /// </summary>
        public string pwd_Mobile { get; set; }


        /// <summary>
        /// 找回密码时需要的邮箱号码
        /// </summary>
        public string pwd_Email { get; set; }

        /// <summary>
        /// 上次修改密码的时间
        /// </summary>
        public DateTime pwd_ChangePwdTime { get; set; }


        /// <summary>
        /// 保留最后三次修改的密码，不能重复设置相同的密码。
        /// </summary>
        public string pwd_LastPassword { get; set; }
        
    }
}
