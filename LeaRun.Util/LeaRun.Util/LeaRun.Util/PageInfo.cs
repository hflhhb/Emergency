using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.Util
{
    public class PageInfo
    {

        /// <summary>
        /// 页号
        /// </summary>
        public int PageIndex {get;set;}
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize{get;set;}

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 记录数
        /// </summary>
        public int RowCount { get; set; }

        public PageInfo()
        {
            RowCount = 0;
            PageIndex = 1;
            PageSize = 20;
            PageCount = 0;
        }
    }
}
