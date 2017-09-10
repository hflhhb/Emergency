using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.ComponentModel.DataAnnotations;

namespace LeaRun.SystemManage.Entity
{
    /// <summary>
    /// 应用系统：角色、代码表、单据号规则表都只区分到应用系统。
    /// 子系统： 从属于某一个应用，菜单可以区分到子系统级别，所以子系统有独立的顶部导航菜单。
    /// </summary>
    public class APP_Application : LeaRun.Data.BaseEntity
    {
        /// <summary>
        /// 自增长ID
        /// </summary>
        [Key]
        public int app_Id { get; set; }

        /// <summary>
        /// 子系统Code
        /// </summary>
        public string app_Code { get; set; }

        /// <summary>
        /// 子系统或应用
        /// </summary>
        public string app_Type { get; set; }

        /// <summary>
        /// 所属应用
        /// </summary>
        public string app_App { get; set; } 

        /// <summary>
        /// 子系统名称
        /// </summary>
        public string app_Name { get; set; }


        /// <summary>
        /// 子系统图标
        /// </summary>
        public string app_Icon { get; set; }

        /// <summary>
        /// 应用在桌面环境的打开方式  
        /// window  --打开浏览器 新窗口
        /// frame   --同窗口Frame打开
        /// </summary>
        public string app_OpenType { get; set; }

        /// <summary>
        /// 子系统主页URL
        /// </summary>
        public string app_Url { get; set; }

        /// <summary>
        ///  外挂子系统IP和端口号，用于WebAPI交互使用
        /// </summary>
        public string app_IP { get; set; }

        /// <summary>
        /// 子系统排序号，用户顶部导航菜单排序
        /// </summary>
        public int app_Rank { get; set; } 
    }
}
