using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic; 
using System.Data;
using System.Text;
using System.Web.Mvc;

namespace LeaRun.Util
{
    /// <summary>
    /// Json操作
    /// </summary>
    public static class Json
    {
        public static object ToJson(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject(Json);
        }
        public static string ToJson(this object obj)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }
        public static string ToJson(this object obj, string datetimeformats)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = datetimeformats };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }
        /// <summary>
        /// 转换成jquery.chained.remote.js需要的下拉数据源
        /// </summary>
        /// <param name="selectList"></param>
        /// <returns></returns>
        public static string ToChainedJson(this IList<SelectListItem> selectList)
        {
            StringBuilder sbOption = new StringBuilder();
            sbOption.AppendLine("{");
            sbOption.AppendLine("\"\" : \"\"");

            foreach(SelectListItem item in selectList)
            {
                sbOption.AppendFormat(",\"{0}\" : \"{1}\"",item.Value,item.Text).AppendLine();
            }

            sbOption.AppendLine("}");

            return sbOption.ToString();
        }

        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }
        public static List<T> ToList<T>(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json);
        }
        public static DataTable ToTable(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json);
        }
        public static JObject ToJObject(this string Json)
        {
            return Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
        }

        #region Json转换为其他数据类型

        /// <summary>
        /// 将json数据转换成Dictionary
        /// </summary>
        /// <param name="strJsonData"></param>
        /// <returns></returns>
        public static Dictionary<string, object> JsonToDictionary(string strJsonData)
        {
            Dictionary<string, object> dic = (Dictionary<string, object>)JsonConvert.DeserializeObject(strJsonData, typeof(Dictionary<string, object>));
            return dic;
        }
        /// <summary>
        /// 将json集合转换成JArray
        /// </summary>
        /// <param name="strJsonData"></param>
        /// <returns></returns>
        public static JArray JsonToJArray(string strJsonData)
        {
            JArray array = (JArray)JsonConvert.DeserializeObject(strJsonData, typeof(JArray));
            return array;
        }

        /// <summary>
        /// 将表格数据转换成Json
        /// </summary>
        /// <param name="jsonName">返回json的名称</param>
        /// <param name="dt">转换成json的表</param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("[");
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString().Trim() + "\":\"" + StringUtil.cEmpty(dt.Rows[i][j]).Trim() + "\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]");
            return Json.ToString();
        }



        /// <summary>
        /// 将表格数据转换成Json
        /// </summary>
        /// <param name="jsonName">返回json的名称</param>
        /// <param name="columns">需要转换的部分列名数组</param>
        /// <param name="dt">转换成json的表</param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt, string[] columns)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < columns.Length; j++)
                    {
                        string strColumnName = columns[j].Trim();
                        string strJsonColName = columns[j].Trim();
                        if (strColumnName.IndexOf(" as ") > 0)
                        {
                            string[] arr = strColumnName.Split(new string[] { " as " }, System.StringSplitOptions.RemoveEmptyEntries);
                            if (arr.Length == 2)
                            {
                                strColumnName = arr[0].Trim();
                                strJsonColName = arr[1].Trim();
                            }
                        }

                        if (dt.Columns.Contains(strColumnName))
                        {
                            Json.Append("\"" + strJsonColName + "\":\"" + StringUtil.cEmpty(dt.Rows[i][strColumnName]).Trim() + "\"");
                        }
                        else
                        {
                            Json.Append("\"" + strJsonColName + "\":\"\"");
                        }


                        if (j < columns[j].Length - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]");
            return Json.ToString();
        }
         
        #endregion
    }
}
