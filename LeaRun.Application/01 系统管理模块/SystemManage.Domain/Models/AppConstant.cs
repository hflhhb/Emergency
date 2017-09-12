using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using LeaRun.Util;

namespace LeaRun.SystemManage.Entity
{
    public partial class AppConstant : LeaRun.Data.BaseEntity
    {

        public static string AppPlatformDB = Config.GetValue("Platform_DBName"); //"LeaRunFramework_Base_2016";  //数据库名或数据库连接名  AppPlatform。 
    }
}