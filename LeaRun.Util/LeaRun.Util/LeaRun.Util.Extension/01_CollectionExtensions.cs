using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using System;

namespace LeaRun.Util.Extension
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            if (items == null)
            {
                return;
            }
            foreach (var item in items)
            {
                source.Add(item);
            }
        }
        public static bool IsNull<T>(this List<T> Value)
        {
            if (Value == null) { return true; } 
            return false;
        }

        public static bool IsNullOrEmpty<T>(this List<T> Value)
        {
            if (Value == null) { return true; }
            if (Value.Count == 0) { return true; }
            return false; 
        }

        /// <summary>
        /// 确定序列是否包含任何元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns>如果源序列包含任何元素，则为 true；否则为 false。</returns>
        public static bool IsAny<T>(this IEnumerable<T> t, Func<T, bool> predicate = null)
        {
            if (t == null) return false;
            if (predicate == null)
            {
                return t.Any();
            }
            else
            {
                return t.Any(predicate);
            }
        }

        public static string StringJoin<T>(this IEnumerable<T> source, string separator = ",")
        {
            if (!source.IsAny())
            {
                return "";
            }
            return string.Join(separator, source);
        }

        /// <summary>
        /// 得到List&lt;T&gt;,如果本身是List,不需要转化返回List，否则调用ToList()
        /// </summary>
        public static List<T> AsList<T>(this IEnumerable<T> source)
        {
            return (source == null || source is List<T>) ? (List<T>)source : source.ToList();
        }


        ///// <summary>
        ///// 将集合类转换成DataTable
        ///// </summary>
        ///// <param name="list">集合</param>
        ///// <returns></returns>
        //public static DataTable ToDataTable(this IList list)
        //{
        //    DataTable result = new DataTable();
        //    if (list.Count > 0)
        //    {
        //        PropertyInfo[] propertys = list[0].GetType().GetProperties();
        //        foreach (PropertyInfo pi in propertys)
        //        {
        //            result.Columns.Add(pi.Name, pi.PropertyType);
        //        }

        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            ArrayList tempList = new ArrayList();
        //            foreach (PropertyInfo pi in propertys)
        //            {
        //                object obj = pi.GetValue(list[i], null);
        //                tempList.Add(obj);
        //            }
        //            object[] array = tempList.ToArray();
        //            result.LoadDataRow(array, true);
        //        }
        //    }
        //    return result;
        //}

        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(this IList<T> list)
        {
            return CollectionExtensions.ToDataTable<T>(list, null);
        }

        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="propertyName">需要返回的列的列名</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(this IList<T> list, params string[] propertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (propertyName != null)
                propertyNameList.AddRange(propertyName);

            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                            result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(list[i], null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
    }
}
