using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.CodeGenerator.Model
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.1.15 9:54
    /// 描 述：表单信息
    /// </summary>
    public class FormModel
    {
        /// <summary>
        /// 显示类型（一列、二列）
        /// </summary>
        public int? FormType { get; set; }
        /// <summary>
        /// 表单宽度
        /// </summary>
        public int? width { get; set; }
        /// <summary>
        /// 表单高度
        /// </summary>
        public int? height { get; set; }
    }
}
