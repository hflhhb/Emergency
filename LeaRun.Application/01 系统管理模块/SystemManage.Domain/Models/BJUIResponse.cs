// ***********************************************************************
// Assembly         : OpenAuth.Mvc
// Author           : yubaolee
// Created          : 11-05-2015
//
// Last Modified By : yubaolee
// Last Modified On : 11-05-2015
// ***********************************************************************
// <copyright file="BJUIResponse.cs" company="www.cnblogs.com/yubaolee">
//     Copyright (c) www.cnblogs.com/yubaolee. All rights reserved.
// </copyright>
// <summary>B-JUI框架返回</summary>
// ***********************************************************************

namespace LeaRun.SystemManage.Entity
{
    /// <summary>
    /// Ajax返回状态类
    /// </summary>
    public class BjuiResponse
    {
        /// <summary>
        /// statusCode
        /// </summary>
        public string statusCode
        {
            get; set;
        }

        /// <summary>
        /// message
        /// </summary>
        public string message
        {
            get; set;
            
        }

        /// <summary>
        /// 数据对象
        /// </summary>
        public object data
        {
            get;
            set;
        }


        /// <summary>
        /// tabid
        /// </summary>
        public string tabid
        {
            get; set; 
        }

        /// <summary>
        /// dialogid
        /// </summary>
        public string dialogid
        {
            get; set; 
        }

        /// <summary>
        /// divid
        /// </summary>
        public string divid
        {
            get;
            set;
        }

        /// <summary>
        /// closeCurrent
        /// </summary>
        public bool closeCurrent
        {
            get; set;
            
        }

        /// <summary>
        /// forward
        /// </summary>
        public string forward { get; set; }

        /// <summary>
        /// forwardConfirm
        /// </summary>
        public string forwardConfirm { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BjuiResponse()
        {
            statusCode = "200";
            message = "操作成功";
            tabid = "";
            dialogid = "";
            divid = "";
            closeCurrent = false;
            forward = "";
            forwardConfirm = "";
        }
    }
}