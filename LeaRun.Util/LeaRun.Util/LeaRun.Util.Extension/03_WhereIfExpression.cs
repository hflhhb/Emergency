using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LeaRun.Util.Extension
{
    /// <summary>
    ///     WhereIF扩展
    /// </summary>
    public static class WhereIfExtensions
    {
        /// <summary>
        /// 如果条件不为空，则过滤查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate,
            bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// 如果过滤表达式本身不为空，则过滤查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
        {
            return predicate != null ? source.Where(predicate) : source;
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, int, bool>> predicate,
            bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, int, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        ///     如果value的值不为null、空
        /// </summary>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate,
            string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? source.Where(predicate) : source;
        }
        ///// <summary>
        /////     values有值
        ///// </summary>
        //public static IQueryable<T> WhereIf<T, L>(this IQueryable<T> source, Expression<Func<T, bool>> predicate,
        //    IEnumerable<L> values)
        //{
        //    return values.IsAny() ? source.Where(predicate) : source;
        //}
        /// <summary>
        ///     如果value的值不为null、空
        /// </summary>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? source.Where(predicate) : source;
        }



    }
}
