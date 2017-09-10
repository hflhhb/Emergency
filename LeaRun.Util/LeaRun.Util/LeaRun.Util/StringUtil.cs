using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using LeaRun.Util.Extension;
using System.Web;
using Microsoft.JScript;
using System.Web.Mvc;

namespace LeaRun.Util
{
    /// <summary>
    /// 字符串操作 - 工具方法
    /// </summary>
    public sealed partial class StringUtil
    {
        #region 自己扩展的公用函数
        /// <summary>
        /// obiect转换为string并Trim
        /// 处理Null值,undefined特殊情况
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string cEmpty(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            else if ("NULL".Equals(value))
            {
                return string.Empty;
            }
            else if ("undefined".Equals(value))
            {
                return string.Empty;
            }
            else
            {
                return value.ToString().Trim();
            }
        }

        /// <summary>
        /// Escape, 并去除头尾空格
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string escape(object value)
        {
            string strReturn = cEmpty(value).Trim();
            strReturn = GlobalObject.escape(strReturn);

            return strReturn;
        }


        /// <summary>
        /// javascript  unescape的C#版本
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string unescape(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            else
            {
                return GlobalObject.unescape(value);
            }
        }

        /// <summary>
        /// 返回encode Request参数格式的URL
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static string encodeURL(System.Web.HttpRequestBase Request)
        {
            StringBuilder sbQueryString = new StringBuilder();
            foreach (string key in Request.QueryString)
            {   //系统的固有字段需要过滤
                if (!(key == "pageNo" || key == "orderField" || key == "orderDirection"))
                {
                    if (sbQueryString.Length > 0)
                    {
                        sbQueryString.Append("&");
                    }

                    String strParamValue = System.Web.HttpUtility.UrlEncode(cEmpty(Request.QueryString[key]), Encoding.GetEncoding("utf-8"));
                    sbQueryString.Append(key).Append("=").Append(strParamValue);
                }
            }

            if (sbQueryString.Length > 0)
            {
                return Request.Url.AbsoluteUri.ToString() + "?" + sbQueryString.ToString();
            }
            else
            {
                return Request.Url.AbsoluteUri.ToString();
            }
        }



        /// <summary>
        /// 返回encode Request参数格式的QueryString
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static string encodeQueryString(System.Web.HttpRequestBase Request, bool bClearPage = true)
        {
            StringBuilder sbQueryString = new StringBuilder();
            foreach (string key in Request.QueryString)
            {
                if (key == null) continue;
                if (key == string.Empty) continue;

                //系统的固有字段需要过滤
                if (bClearPage && (!(key == "pageNo" || key == "orderField" || key == "orderDirection")))
                {
                    if (sbQueryString.Length > 0)
                    {
                        sbQueryString.Append("&");
                    }

                    String strParamValue = System.Web.HttpUtility.UrlEncode(cEmpty(Request.QueryString[key]), Encoding.GetEncoding("utf-8"));
                    sbQueryString.Append(key).Append("=").Append(strParamValue);
                }
                else
                {
                    if (sbQueryString.Length > 0)
                    {
                        sbQueryString.Append("&");
                    }

                    String strParamValue = System.Web.HttpUtility.UrlEncode(cEmpty(Request.QueryString[key]), Encoding.GetEncoding("utf-8"));
                    sbQueryString.Append(key).Append("=").Append(strParamValue);
                }
            }

            return sbQueryString.ToString();
        }


        /// <summary>
        /// 单、双引号转义，这样才能存储单、双引号到数据库字段中
        /// </summary>
        /// <param name="strFieldValue"></param>
        /// <returns></returns>
        public static String SingleQuotesEscape(string strFieldValue)
        {
            return strFieldValue.Replace("'", "''").Replace("\"", "\"\"");
        }

        /// <summary>
        /// 返回一个字符串,格式为标准的时间格式加一个3位随机数。
        /// 可以用作生成不重复的文件名。
        /// </summary>
        /// <returns></returns>
        public static string getUniquelyString()
        {
            Random rnd = new Random();
            const int RANDOM_MAX_VALUE = 1000;
            string strTemp, strYear, strMonth, strDay, strHour, strMinute, strSecond, strMillisecond;

            DateTime dt = DateTime.Now;
            int rndNumber = rnd.Next(RANDOM_MAX_VALUE);
            strYear = dt.Year.ToString();
            strMonth = (dt.Month > 9) ? dt.Month.ToString() : "0" + dt.Month.ToString();
            strDay = (dt.Day > 9) ? dt.Day.ToString() : "0" + dt.Day.ToString();
            strHour = (dt.Hour > 9) ? dt.Hour.ToString() : "0" + dt.Hour.ToString();
            strMinute = (dt.Minute > 9) ? dt.Minute.ToString() : "0" + dt.Minute.ToString();
            strSecond = (dt.Second > 9) ? dt.Second.ToString() : "0" + dt.Second.ToString();
            strMillisecond = dt.Millisecond.ToString();

            strTemp = strYear + strMonth + strDay + "_" + strHour + strMinute + strSecond + "_" + strMillisecond + "_" + rndNumber.ToString();

            return strTemp;
        }

        #region 生成三位随机数

        /// <summary>
        ///     生成纯数字的随机数
        /// </summary>
        /// <param name="iBitNums">数字的位数</param>
        /// <returns></returns>
        public static string genRandomNumber(int iBitNums = 3)
        {
            char[] codearray = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int iNum = iBitNums;
            string VNum = "";
            Random randObj = new Random();
            for (int i = 0; i < iNum; i++)
                VNum += codearray[randObj.Next(codearray.Length)];

            return VNum;
        }
        #endregion

        #region 输出单列、双列字段值到明细区域
        /// <summary>
        /// 输出格式：title: value
        /// 如果iIsMemo为1，则把回车换行转化成<br>
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="strValue"></param>
        /// <param name="iIsMemo"></param>
        /// <returns></returns>
        public static string showFieldValue(string strTitle, string strValue, int iIsMemo)
        {
            string strReturn = "";
            strValue = strValue.Trim();
            if (strValue != "")
            {
                StringBuilder sbReturn = new StringBuilder();
                sbReturn.Append("<tr bgcolor='#FFFFFF'>");
                if (iIsMemo == 0)
                {
                    sbReturn.Append("<td width='120' align='right' bgcolor='#E1E6FD'>");
                    sbReturn.Append(strTitle + ":&nbsp;</td><td>");
                    sbReturn.Append(HttpUtility.HtmlEncode(strValue));
                }
                else if (iIsMemo == 3)
                {
                    sbReturn.Append("<td width='120' align='right' bgcolor='#E1E6FD'>");
                    sbReturn.Append(strTitle + ":&nbsp;</td><td colspan='3'>");
                    sbReturn.Append(HttpUtility.HtmlEncode(strValue));
                }
                else
                {
                    sbReturn.Append("<td width='120' align='right' bgcolor='#E1E6FD' valign='top'>");
                    sbReturn.Append(strTitle + ":&nbsp;</td><td>");
                    sbReturn.Append(HttpUtility.HtmlEncode(strValue).Replace("\r\n", "<br>"));
                }
                sbReturn.Append("</td></tr>");
                strReturn = sbReturn.ToString();
            }
            return strReturn;
        }

        /// <summary>
        /// 输出1行2列，格式为：title1: value1  title2: value2。
        /// 如果有一个title为空，则此title和value用空格代替。
        /// </summary>
        /// <param name="strTitle1"></param>
        /// <param name="strValue1"></param>
        /// <param name="strTitle2"></param>
        /// <param name="strValue2"></param>
        /// <returns></returns>
        public static string showFieldValue(string strTitle1, string strValue1, string strTitle2, string strValue2)
        {
            string strReturn = "";

            StringBuilder sbReturn = new StringBuilder();
            sbReturn.Append("<tr bgcolor='#FFFFFF'>");
            if (strTitle1.Length > 0)
            {
                sbReturn.Append("<td width='120' align='right' bgcolor='#E1E6FD'>").Append(strTitle1 + ":&nbsp;</td>");
                sbReturn.Append("<td width='300'>").Append(HttpUtility.HtmlEncode(StringUtil.cEmpty(strValue1))).Append("&nbsp;</td>");
            }
            else
            {
                sbReturn.Append("<td width='120' align='right' bgcolor='#E1E6FD'>&nbsp;</td>");
                sbReturn.Append("<td>&nbsp;</td>");
            }

            if (strTitle2.Length > 0)
            {
                sbReturn.Append("<td width='120' align='right' bgcolor='#E1E6FD'>").Append(strTitle2 + ":&nbsp;</td>");
                sbReturn.Append("<td>").Append(HttpUtility.HtmlEncode(StringUtil.cEmpty(strValue2))).Append("&nbsp;</td>");
            }
            else
            {
                sbReturn.Append("<td width='120' align='right' bgcolor='#E1E6FD'>&nbsp;</td>");
                sbReturn.Append("<td>&nbsp;</td>");
            }

            sbReturn.Append("</tr>");
            strReturn = sbReturn.ToString();

            return strReturn;
        }
        #endregion

        #region 基本数据类型转换函数
        /// <summary>
        /// 如果是null,返回空字符串，否则返回对象本身
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object getObj(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {

                return obj;
            }
        }

        /// <summary>
        /// object转换为string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string getStr(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {
                string strTemp = System.Convert.ToString(obj);
                ////删除特殊字符。
                //strTemp = replaceSpecialChar(strTemp);
                return strTemp;
            }
        }

        /// <summary>
        /// object转换为Boolean
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool getBool(object val)
        {
            try
            {
                if (System.Convert.IsDBNull(val) || val == null)
                {
                    return false;
                }

                string strVal = val.ToString();
                if (strVal == "1" || strVal == "true")
                {
                    return true;
                }
                else if (strVal == "0" || strVal == "false")
                {
                    return false;
                }
                else
                {
                    return System.Convert.ToBoolean(val);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// object转换为int(如果是true，返回1；如果是false，返回2；如果是空，返回0；其余的话直接转换)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int getInt(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else if (obj.ToString().ToLower() == "true")
                {
                    return 1;
                }
                else if (obj.ToString().ToLower() == "false")
                {
                    return 0;
                }
                else if (obj.ToString().Trim() == "")
                {
                    return 0;
                }
                else
                {
                    return Int32.Parse(obj.ToString().Trim());
                }
            }
            catch (Exception err)
            {
                return 0;
            }

        }

        /// <summary>
        /// object转换为float(如果对象不存在或者对象转为字符串显示为空，返回0；其他情况直接转换)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float getFloat(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else if (System.Convert.ToString(obj).Equals(""))
                {
                    return 0;
                }
                else
                {
                    return Single.Parse(obj.ToString().Trim());
                }
            }
            catch (Exception err)
            {
                return 0;
            }
        }

        /// <summary>
        /// 将对象转换成double类型，对象为空或者出异常的话返回0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double getDouble(object obj)
        {
            try
            {
                if (obj == null) return 0d;
                else if (obj.ToString() == "") return 0d;
                else return double.Parse(obj.ToString().Trim());
            }
            catch (Exception ex)
            {
                return 0d;
            }
        }



        /// <summary>
        /// 将对象转换成decimal类型，对象为空或者出异常的话返回0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal getDecimal(object obj)
        {
            try
            {
                if (obj == null) return 0;
                else if (obj.ToString() == "") return 0;
                else return decimal.Parse(obj.ToString().Trim());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static System.DateTime getDate(object val)
        {
            try
            {
                if (System.Convert.IsDBNull(val) || val == null)
                {
                    return System.DateTime.MinValue;
                }
                else
                {
                    return System.Convert.ToDateTime(val);
                }
            }
            catch (Exception)
            {
                return System.DateTime.MinValue;
            }
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static System.DateTime getDate(object val,DateTime defaultValue)
        {
            try
            {
                if (System.Convert.IsDBNull(val) || val == null)
                {
                    return defaultValue;
                }
                else
                {
                    return System.Convert.ToDateTime(val);
                }
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        #endregion


        #region 日期相关公用函数。
        //得到月份的第一天
        public static System.DateTime getFirstDay(DateTime now)
        {
            //DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            return d1;
        }

        //得到月份的最后一天
        public static System.DateTime getLastDay(DateTime now)
        {
            //DateTime now = DateTime.Now;
            DateTime d1 = new DateTime(now.Year, now.Month, 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);
            return d2;
        }

        /// <summary>
        /// 把object型日期转化成指定的格式
        /// </summary>
        /// <param name="_DataTime">日期</param>
        /// <param name="formateStr">要转化的格式</param>
        /// <returns></returns>
        public static string getFormateDateTime(object _DataTime, string formateStr)
        {
            string _ReturnData = cEmpty(_DataTime);
            if (!"".Equals(formateStr) && !"".Equals(_ReturnData))
            {
                _ReturnData = DateTime.Parse(_ReturnData).ToString(formateStr);
            }
            return _ReturnData;
        }

        /// <summary>
        /// 变换日期格式 yyyy-MM-dd 
        /// </summary>
        /// <param name="_DataTime"></param>
        /// <returns></returns>
        public static string getStandardDate(object _DataTime)
        {
            return getFormateDateTime(_DataTime, "yyyy-MM-dd");
        }

        /// <summary>
        /// 变换日期格式 yyyy-MM-dd HH:mm:ss 
        /// </summary>
        /// <param name="_DataTime"></param>
        /// <returns></returns>
        public static string getStandardDateTime(object _DataTime)
        {
            return getFormateDateTime(_DataTime, "yyyy-MM-dd HH:mm:ss");
        }


        /// <summary>
        /// 把日期格式转化成 年-月-日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string formateShortDate(System.DateTime date)
        {
            bool en = false;
            if (en)
            {
                string strNow;
                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
                strNow = date.ToString("dd-MMMM-yyyy", ci);
                //Console.WriteLine(strNow);
                return strNow;
            }
            else
            {
                string strNow = date.ToString("yyyy-MM-dd");
                return strNow;
            }
        }

        /// <summary>
        /// 把日期格式转化成 年-月-日 时:分:秒
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string formateLongDate(System.DateTime date)
        {
            bool en = false;
            if (en)
            {
                string strNow;
                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
                strNow = date.ToString("dd-MMMM-yyyy HH:mm:ss", ci);
                //Console.WriteLine(strNow);
                return strNow;
            }
            else
            {
                string strNow = date.ToString("yyyy-MM-dd HH:mm:ss");
                return strNow;
            }
        }
        #endregion

        #region 年月下拉框、Boolean下拉框、Dictionary下拉框辅助类
        //获得年份下拉框
        public static string getYearOptionString(int iBeginYear, int iSelectedYear)
        {
            String strYearList = "";
            int iCurYear = int.Parse(System.DateTime.Now.Year.ToString());
            if (iBeginYear < 2000)
            {
                iBeginYear = iBeginYear - 5;
            }

            for (int i = iBeginYear; i <= iCurYear + 5; i++)
            {
                string sSelected = (iSelectedYear.ToString() == i.ToString() ? "selected" : "");
                strYearList = strYearList + "<option " + sSelected + " value='" + i.ToString() + "'>" + i.ToString() + "</option>";
            }
            return strYearList;
        }

        //获得月份下拉框
        public static string getMonthOptionString(int iSelectedMonth)
        {
            String strMonthList = "";
            for (int i = 1; i <= 12; i++)
            {
                if (iSelectedMonth == i)
                    strMonthList = strMonthList + "<option selected value='" + i.ToString() + "'>" + i.ToString() + "</option>";
                else
                    strMonthList = strMonthList + "<option value='" + i.ToString() + "'>" + i.ToString() + "</option>";
            }

            return strMonthList;
        }


        /// <summary>
        /// 获得Boolean下拉框,注意：如果是空字符串或NULL值，则不选择。
        /// </summary>
        /// <param name="boolValue"></param>
        /// <returns></returns>
        public static string getBooleanOptionString(object boolValue)
        {
            String strBooleanList = "";
            String strSelected = "selected";
            //如果是空字符串或NULL值，则不选择。
            if (boolValue == null || boolValue == "")
            {
                strSelected = "";
            }

            if (StringUtil.getBool(boolValue))
            {
                strBooleanList = strBooleanList + "<option " + strSelected + " value='1'>是</option>";
                strBooleanList = strBooleanList + "<option value='0'>否</option>";
            }
            else
            {
                strBooleanList = strBooleanList + "<option  value='1'>是</option>";
                strBooleanList = strBooleanList + "<option  " + strSelected + " value='0'>否</option>";
            }

            return strBooleanList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string getDictValue(Dictionary<string, object> dic, string strKey)
        {
            if (dic == null)
            {
                throw new ApplicationException("函数StringUtil.getDictValue的参数dic不能为null值");
            }

            if (!dic.ContainsKey(strKey))
            {
                throw new ApplicationException("字典Dictionary中没有键:" + strKey + "的值");
            }
            else
            {
                return StringUtil.cEmpty(dic[strKey]);
            }
        }

        /// <summary>
        /// 按固定的Dictionary输出下列列表
        /// </summary>
        /// <param name="dic">字典表</param>
        /// <param name="sSelectedValue">当前值</param>
        /// <returns></returns>
        public static string genSelectHTML(Dictionary<string, string> dic, string sSelectedValue)
        {
            StringBuilder sbSet = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in dic)
            {
                string sSelected = (String.Compare(kvp.Key, sSelectedValue, true) == 0 ? "selected" : "");
                sbSet.Append(string.Format("<option value='{0}' {1}>{2}</option>", kvp.Key, sSelected, kvp.Value));
            }
            return sbSet.ToString();
        }

        /// <summary>
        /// 按固定的Dictionary输出下列列表
        /// </summary>
        /// <param name="dic">字典表</param>
        /// <param name="sSelectedValue">当前值</param>
        /// <returns></returns>
        public static string genSelectHTML(IList<SelectListItem> list, string sSelectedValue)
        {
            StringBuilder sbSet = new StringBuilder();
            foreach (SelectListItem item in list)
            {
                string sSelected = (String.Compare(item.Value , sSelectedValue, true) == 0 ? "selected" : "");
                if (item.Selected) sSelected = "selected";
                sbSet.Append(string.Format("<option value='{0}' {1}>{2}</option>", item.Value, sSelected, item.Text));
            }
            return sbSet.ToString();
        }
        #endregion



        /// <summary>
        /// 经过处理后的JSON字符串，才能被javascript: eval(jsonString)正确解析，不会报错
        /// </summary>
        /// <param name="s">替换前字符串</param>
        /// <returns></returns>
        public static String replaceJsonSpecialChar(string s)
        {
            //首先将回车换行符号替换成<br>，否则eval(jsonString),解析出错。 
            //s=s.Replace("\r\n","<br>");

            s = cEmpty(s);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                char c = arr[i];
                switch (c)
                {
                    case '\'':
                        sb.Append("\\'");   //去除单引号。
                        break;
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\': //如果不处理单引号，可以释放此段代码，若结合下面的方法处理单引号就必须注释掉该段代码 
                        sb.Append("\\\\");
                        break;
                    case '/':
                        sb.Append("\\/");
                        break;
                    case '\b': //退格 
                        sb.Append("\\b");
                        break;
                    case '\f': //走纸换页 
                        sb.Append("\\f");
                        break;
                    case '\n':
                        //sb.Append("\\n"); //换行 
                        sb.Append(" ");     //回车换行用空格取代
                        break;
                    case '\r': //回车 
                        //sb.Append("\\r");
                        sb.Append(" ");    //回车换行用空格取代
                        break;
                    case '\t': //横向跳格 
                        sb.Append("\\t");
                        break;

                    default:
                        sb.Append(c);
                        break;
                }
            }

            return sb.ToString();
        }


        #region   根据字符串数字得到页号
        /// <summary>
        /// 获取翻页号
        /// 翻页号不存在的话，置为1
        /// </summary>
        /// <param name="strnPage"></param>
        /// <returns></returns>
        public static int getPageNo(string strnPage)
        {
            int iPage = 1;
            if (strnPage != "")
            {
                try
                {
                    iPage = Int32.Parse(strnPage);
                    if (iPage < 1) iPage = 1;
                }
                catch
                {
                    iPage = 1;
                }
            }
            return iPage;
        }
        #endregion

        #endregion
         
        #region 从Web.config中得的配置参数
        public static string getWebKey(string strKey)
        {
            return (System.Configuration.ConfigurationManager.AppSettings[strKey]).Trim();
        } 
        #endregion

        #region PinYin(获取汉字的拼音简码)
        /// <summary>
        /// 获取汉字的拼音简码，即首字母缩写,范例：中国,返回zg
        /// </summary>
        /// <param name="chineseText">汉字文本,范例： 中国</param>
        public static string PinYin(string chineseText)
        {
            if (string.IsNullOrWhiteSpace(chineseText))
                return string.Empty;
            var result = new StringBuilder();
            foreach (char text in chineseText)
                result.AppendFormat("{0}", ResolvePinYin(text));
            return result.ToString().ToLower();
        }

        /// <summary>
        /// 解析单个汉字的拼音简码
        /// </summary>
        /// <param name="text">单个汉字</param>
        private static string ResolvePinYin(char text)
        {
            byte[] charBytes = Encoding.Default.GetBytes(text.ToString());
            if (charBytes[0] <= 127)
                return text.ToString();
            var unicode = (ushort)(charBytes[0] * 256 + charBytes[1]);
            string pinYin = ResolvePinYinByCode(unicode);
            if (!string.IsNullOrWhiteSpace(pinYin))
                return pinYin;
            return ResolvePinYinByFile(text.ToString());
        }

        /// <summary>
        /// 使用字符编码方式获取拼音简码
        /// </summary>
        private static string ResolvePinYinByCode(ushort unicode)
        {
            if (unicode >= '\uB0A1' && unicode <= '\uB0C4')
                return "A";
            if (unicode >= '\uB0C5' && unicode <= '\uB2C0' && unicode != 45464)
                return "B";
            if (unicode >= '\uB2C1' && unicode <= '\uB4ED')
                return "C";
            if (unicode >= '\uB4EE' && unicode <= '\uB6E9')
                return "D";
            if (unicode >= '\uB6EA' && unicode <= '\uB7A1')
                return "E";
            if (unicode >= '\uB7A2' && unicode <= '\uB8C0')
                return "F";
            if (unicode >= '\uB8C1' && unicode <= '\uB9FD')
                return "G";
            if (unicode >= '\uB9FE' && unicode <= '\uBBF6')
                return "H";
            if (unicode >= '\uBBF7' && unicode <= '\uBFA5')
                return "J";
            if (unicode >= '\uBFA6' && unicode <= '\uC0AB')
                return "K";
            if (unicode >= '\uC0AC' && unicode <= '\uC2E7')
                return "L";
            if (unicode >= '\uC2E8' && unicode <= '\uC4C2')
                return "M";
            if (unicode >= '\uC4C3' && unicode <= '\uC5B5')
                return "N";
            if (unicode >= '\uC5B6' && unicode <= '\uC5BD')
                return "O";
            if (unicode >= '\uC5BE' && unicode <= '\uC6D9')
                return "P";
            if (unicode >= '\uC6DA' && unicode <= '\uC8BA')
                return "Q";
            if (unicode >= '\uC8BB' && unicode <= '\uC8F5')
                return "R";
            if (unicode >= '\uC8F6' && unicode <= '\uCBF9')
                return "S";
            if (unicode >= '\uCBFA' && unicode <= '\uCDD9')
                return "T";
            if (unicode >= '\uCDDA' && unicode <= '\uCEF3')
                return "W";
            if (unicode >= '\uCEF4' && unicode <= '\uD188')
                return "X";
            if (unicode >= '\uD1B9' && unicode <= '\uD4D0')
                return "Y";
            if (unicode >= '\uD4D1' && unicode <= '\uD7F9')
                return "Z";
            return string.Empty;
        }

        /// <summary>
        /// 从拼音简码文件获取
        /// </summary>
        /// <param name="text">单个汉字</param>
        private static string ResolvePinYinByFile(string text)
        {
            int index = Const.ChinesePinYin.IndexOf(text, StringComparison.Ordinal);
            if (index < 0)
                return string.Empty;
            return Const.ChinesePinYin.Substring(index + 1, 1);
        }

        #endregion

        #region Splice(拼接集合元素)

        /// <summary>
        /// 拼接集合元素
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="quotes">引号，默认不带引号，范例：单引号 "'"</param>
        /// <param name="separator">分隔符，默认使用逗号分隔</param>
        public static string Splice<T>(IEnumerable<T> list, string quotes = "", string separator = ",")
        {
            if (list == null)
                return string.Empty;
            var result = new StringBuilder();
            foreach (var each in list)
                result.AppendFormat("{0}{1}{0}{2}", quotes, each, separator);
            return result.ToString().TrimEnd(separator.ToCharArray());
        }

        #endregion

        #region FirstUpper(将值的首字母大写)

        /// <summary>
        /// 将值的首字母大写
        /// </summary>
        /// <param name="value">值</param>
        public static string FirstUpper(string value)
        {
            string firstChar = value.Substring(0, 1).ToUpper();
            return firstChar + value.Substring(1, value.Length - 1);
        }

        #endregion

        #region ToCamel(将字符串转成驼峰形式)

        /// <summary>
        /// 将字符串转成驼峰形式
        /// </summary>
        /// <param name="value">原始字符串</param>
        public static string ToCamel(string value)
        {
            return FirstUpper(value.ToLower());
        }

        #endregion

        #region ContainsChinese(是否包含中文)

        /// <summary>
        /// 是否包含中文
        /// </summary>
        /// <param name="text">文本</param>
        public static bool ContainsChinese(string text)
        {
            const string pattern = "[\u4e00-\u9fa5]+";
            return Regex.IsMatch(text, pattern);
        }

        #endregion

        #region ContainsNumber(是否包含数字)

        /// <summary>
        /// 是否包含数字
        /// </summary>
        /// <param name="text">文本</param>
        public static bool ContainsNumber(string text)
        {
            const string pattern = "[0-9]+";
            return Regex.IsMatch(text, pattern);
        }

        #endregion

        #region Distinct(去除重复)

        /// <summary>
        /// 去除重复
        /// </summary>
        /// <param name="value">值，范例1："5555",返回"5",范例2："4545",返回"45"</param>
        public static string Distinct(string value)
        {
            var array = value.ToCharArray();
            return new string(array.Distinct().ToArray());
        }

        #endregion

        #region Truncate(截断字符串)

        /// <summary>
        /// 截断字符串
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="length">返回长度</param>
        /// <param name="endCharCount">添加结束符号的个数，默认0，不添加</param>
        /// <param name="endChar">结束符号，默认为省略号</param>
        public static string Truncate(string text, int length, int endCharCount = 0, string endChar = ".")
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            if (text.Length < length)
                return text;
            return text.Substring(0, length) + GetEndString(endCharCount, endChar);
        }

        /// <summary>
        /// 获取结束字符串
        /// </summary>
        private static string GetEndString(int endCharCount, string endChar)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < endCharCount; i++)
                result.Append(endChar);
            return result.ToString();
        }

        #endregion

        #region ToSimplifiedChinese(转换为简体中文)

        /// <summary>
        /// 转换为简体中文
        /// </summary>
        /// <param name="text">繁体中文</param>
        public static string ToSimplifiedChinese(string text)
        {
            return Strings.StrConv(text, VbStrConv.SimplifiedChinese);
        }

        #endregion

        #region ToSimplifiedChinese(转换为繁体中文)

        /// <summary>
        /// 转换为繁体中文
        /// </summary>
        /// <param name="text">简体中文</param>
        public static string ToTraditionalChinese(string text)
        {
            return Strings.StrConv(text, VbStrConv.TraditionalChinese);
        }

        #endregion

        #region Unique(获取全局唯一值)

        /// <summary>
        /// 获取全局唯一值
        /// </summary>
        public static string Unique()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        #endregion

        #region GetLastProperty(获取最后一个属性)

        /// <summary>
        /// 获取最后一个属性
        /// </summary>
        /// <param name="propertyName">属性名，范例，A.B.C,返回"C"</param>
        public static string GetLastProperty(string propertyName)
        {
            if (propertyName.IsEmpty())
                return string.Empty;
            var lastIndex = propertyName.LastIndexOf(".", StringComparison.Ordinal) + 1;
            return propertyName.Substring(lastIndex);
        }

        #endregion
    }
}
