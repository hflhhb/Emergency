﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.WebBase
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：刘晓雷
    /// 日 期：2016.03.28
    /// 描 述：用户数据权限
    /// </summary>
    public class AuthorizeDataModel
    {
        /// <summary>
        /// 功能模块主键
        /// </summary>
        public string ModuleId { get; set; }
        /// <summary>
        /// 获得有权限的数据列表SQL语句
        /// </summary>
        public string ReadAutorize { get; set; }
        /// <summary>
        /// 可读用户ID
        /// </summary>
        public string ReadAutorizeUserId { get; set; }
        /// <summary>
        /// 可写数据权限SQL语句
        /// </summary>
        public string WriteAutorize { get; set; }
        /// <summary>
        /// 可写数据权限
        /// </summary>
        public string WriteAutorizeUserId { get; set; }

        /// <summary>
        /// 可读部门ID
        /// </summary>
        public List<string> ReadAutorizeDeptIds { get; set; }

        /// <summary>
        /// 可写部门数据权限
        /// </summary>
        public List<string> WriteAutorizeDeptIds { get; set; }
    }
}
