using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace LeaRun.Util.Offices
{
    /// <summary>
    /// 导出列定义
    /// </summary>
    public class ExportColumn
    {
        private string strColumnName = "";

        public string ColumnName
        {
            get { return strColumnName; }
            set { strColumnName = value; }
        }

        private string strCaption = "";

        public string Caption
        {
            get { return strCaption; }
            set { strCaption = value; }
        }

        //两级列头时的组列头名。
        private string strGroupColName = ""; 
        public string GroupColName
        {
            get { return strGroupColName; }
            set { strGroupColName = value; }
        }

        //是否允许导入
        public bool AllowImport { get; set; }

        //SQL数据类型
        public string FieldType { get; set; }
        
        //数据长度
        public string FieldLength { get; set; }

        //枚举值翻译
        public Dictionary<string, string> ValueDictionary { get; set; }

        public ExportColumn()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public ExportColumn(string columnName, string caption)
        {
             strColumnName=columnName;
             strCaption=caption;
        }


        public ExportColumn(string columnName, string caption,string groupColName)
        {
            strColumnName = columnName;
            strCaption = caption;
            strGroupColName = groupColName;
        }

        public ExportColumn(string columnName, string caption, Dictionary<string, string> dict)
        {
            strColumnName = columnName;
            strCaption = caption;

            this.ValueDictionary = dict;
        }

        

    }

}